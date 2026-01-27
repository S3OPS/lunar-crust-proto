using UnityEngine;
using System;

namespace MiddleEarth.Core
{
    /// <summary>
    /// Runtime assertions and contract validation.
    /// Helps catch bugs early in development.
    /// Can be disabled in production builds for performance.
    /// </summary>
    public static class GameAssert
    {
        private static bool _assertionsEnabled = true;
        
        /// <summary>
        /// Enable or disable assertions globally.
        /// In production builds, consider disabling for performance.
        /// </summary>
        public static void SetAssertionsEnabled(bool enabled)
        {
            _assertionsEnabled = enabled;
        }
        
        /// <summary>
        /// Assert that a condition is true.
        /// Logs an error if the condition is false.
        /// </summary>
        public static void IsTrue(bool condition, string message = "Assertion failed")
        {
            if (!_assertionsEnabled) return;
            
            if (!condition)
            {
                Debug.LogError($"[ASSERT] {message}");
                #if UNITY_EDITOR
                Debug.Break(); // Pause in editor
                #endif
            }
        }
        
        /// <summary>
        /// Assert that a condition is false.
        /// </summary>
        public static void IsFalse(bool condition, string message = "Assertion failed")
        {
            IsTrue(!condition, message);
        }
        
        /// <summary>
        /// Assert that an object is not null.
        /// </summary>
        public static void IsNotNull<T>(T obj, string message = "Object is null") where T : class
        {
            if (!_assertionsEnabled) return;
            
            if (obj == null)
            {
                Debug.LogError($"[ASSERT] {message}");
                #if UNITY_EDITOR
                Debug.Break();
                #endif
            }
        }
        
        /// <summary>
        /// Assert that an object is null.
        /// </summary>
        public static void IsNull<T>(T obj, string message = "Object should be null") where T : class
        {
            if (!_assertionsEnabled) return;
            
            if (obj != null)
            {
                Debug.LogError($"[ASSERT] {message}");
                #if UNITY_EDITOR
                Debug.Break();
                #endif
            }
        }
        
        /// <summary>
        /// Assert that a value is within a range.
        /// </summary>
        public static void InRange(float value, float min, float max, string message = "Value out of range")
        {
            if (!_assertionsEnabled) return;
            
            if (value < min || value > max)
            {
                Debug.LogError($"[ASSERT] {message}. Value: {value}, Expected: [{min}, {max}]");
                #if UNITY_EDITOR
                Debug.Break();
                #endif
            }
        }
        
        /// <summary>
        /// Assert that a value is within a range (integer).
        /// </summary>
        public static void InRange(int value, int min, int max, string message = "Value out of range")
        {
            if (!_assertionsEnabled) return;
            
            if (value < min || value > max)
            {
                Debug.LogError($"[ASSERT] {message}. Value: {value}, Expected: [{min}, {max}]");
                #if UNITY_EDITOR
                Debug.Break();
                #endif
            }
        }
        
        /// <summary>
        /// Assert that a value is positive.
        /// </summary>
        public static void IsPositive(float value, string message = "Value must be positive")
        {
            if (!_assertionsEnabled) return;
            
            if (value <= 0f)
            {
                Debug.LogError($"[ASSERT] {message}. Value: {value}");
                #if UNITY_EDITOR
                Debug.Break();
                #endif
            }
        }
        
        /// <summary>
        /// Assert that a value is not NaN or Infinity.
        /// </summary>
        public static void IsFinite(float value, string message = "Value is NaN or Infinity")
        {
            if (!_assertionsEnabled) return;
            
            if (float.IsNaN(value) || float.IsInfinity(value))
            {
                Debug.LogError($"[ASSERT] {message}. Value: {value}");
                #if UNITY_EDITOR
                Debug.Break();
                #endif
            }
        }
        
        /// <summary>
        /// Assert that a GameObject has a component.
        /// </summary>
        public static void HasComponent<T>(GameObject obj, string message = null) where T : Component
        {
            if (!_assertionsEnabled) return;
            
            if (obj == null)
            {
                Debug.LogError($"[ASSERT] GameObject is null when checking for {typeof(T).Name}");
                #if UNITY_EDITOR
                Debug.Break();
                #endif
                return;
            }
            
            if (obj.GetComponent<T>() == null)
            {
                string msg = message ?? $"GameObject '{obj.name}' missing component {typeof(T).Name}";
                Debug.LogError($"[ASSERT] {msg}");
                #if UNITY_EDITOR
                Debug.Break();
                #endif
            }
        }
        
        /// <summary>
        /// Assert that a string is not null or empty.
        /// </summary>
        public static void IsNotNullOrEmpty(string str, string message = "String is null or empty")
        {
            if (!_assertionsEnabled) return;
            
            if (string.IsNullOrEmpty(str))
            {
                Debug.LogError($"[ASSERT] {message}");
                #if UNITY_EDITOR
                Debug.Break();
                #endif
            }
        }
        
        /// <summary>
        /// Assert that a collection is not null or empty.
        /// </summary>
        public static void IsNotEmpty<T>(System.Collections.Generic.ICollection<T> collection, string message = "Collection is null or empty")
        {
            if (!_assertionsEnabled) return;
            
            if (collection == null || collection.Count == 0)
            {
                Debug.LogError($"[ASSERT] {message}");
                #if UNITY_EDITOR
                Debug.Break();
                #endif
            }
        }
        
        /// <summary>
        /// Fail assertion unconditionally.
        /// Use when code path should never be reached.
        /// </summary>
        public static void Fail(string message = "Unreachable code executed")
        {
            if (!_assertionsEnabled) return;
            
            Debug.LogError($"[ASSERT] {message}");
            #if UNITY_EDITOR
            Debug.Break();
            #endif
        }
    }
}
