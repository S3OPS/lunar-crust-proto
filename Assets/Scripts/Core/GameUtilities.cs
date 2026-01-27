using UnityEngine;

namespace MiddleEarth.Core
{
    /// <summary>
    /// Collection of utility methods for common game operations.
    /// Implements best practices for performance and safety.
    /// </summary>
    public static class GameUtilities
    {
        /// <summary>
        /// Safely get a component, logging an error if not found.
        /// </summary>
        public static T SafeGetComponent<T>(GameObject obj, string context = "") where T : Component
        {
            if (obj == null)
            {
                Debug.LogError($"[GameUtilities] Cannot get component {typeof(T).Name} - GameObject is null. Context: {context}");
                return null;
            }
            
            T component = obj.GetComponent<T>();
            if (component == null)
            {
                Debug.LogError($"[GameUtilities] Component {typeof(T).Name} not found on {obj.name}. Context: {context}");
            }
            return component;
        }
        
        /// <summary>
        /// Safely destroy a GameObject, checking for null first.
        /// </summary>
        public static void SafeDestroy(Object obj, float delay = 0f)
        {
            if (obj != null)
            {
                Object.Destroy(obj, delay);
            }
        }
        
        /// <summary>
        /// Calculate damage with clamping to prevent negative or excessive values.
        /// </summary>
        public static float ClampDamage(float damage, float min = 0f, float max = 9999f)
        {
            return Mathf.Clamp(damage, min, max);
        }
        
        /// <summary>
        /// Normalize a value between 0 and 1 with safety checks.
        /// </summary>
        public static float SafeNormalize(float value, float max)
        {
            if (max <= 0f)
            {
                Debug.LogWarning($"[GameUtilities] SafeNormalize called with max <= 0: {max}");
                return 0f;
            }
            return Mathf.Clamp01(value / max);
        }
        
        /// <summary>
        /// Check if a Vector3 contains NaN or Infinity values.
        /// </summary>
        public static bool IsValidPosition(Vector3 position)
        {
            return !float.IsNaN(position.x) && !float.IsNaN(position.y) && !float.IsNaN(position.z) &&
                   !float.IsInfinity(position.x) && !float.IsInfinity(position.y) && !float.IsInfinity(position.z);
        }
        
        /// <summary>
        /// Lerp with delta time in a framerate-independent way.
        /// </summary>
        public static float SmoothDamp(float current, float target, float smoothTime)
        {
            return Mathf.Lerp(current, target, 1f - Mathf.Exp(-smoothTime * Time.deltaTime));
        }
        
        /// <summary>
        /// Convert world position to screen position with validation.
        /// </summary>
        public static Vector3 WorldToScreenSafe(Camera camera, Vector3 worldPosition)
        {
            if (camera == null)
            {
                Debug.LogWarning("[GameUtilities] WorldToScreenSafe called with null camera");
                return Vector3.zero;
            }
            
            return camera.WorldToScreenPoint(worldPosition);
        }
        
        /// <summary>
        /// Format a number with appropriate suffix (K, M, etc.).
        /// </summary>
        public static string FormatNumber(int number)
        {
            if (number >= 1000000)
                return (number / 1000000f).ToString("0.#") + "M";
            if (number >= 1000)
                return (number / 1000f).ToString("0.#") + "K";
            return number.ToString();
        }
        
        /// <summary>
        /// Format time in seconds to MM:SS format.
        /// </summary>
        public static string FormatTime(float seconds)
        {
            int minutes = Mathf.FloorToInt(seconds / 60f);
            int secs = Mathf.FloorToInt(seconds % 60f);
            return $"{minutes:00}:{secs:00}";
        }
        
        /// <summary>
        /// Generate a random color with specified alpha.
        /// </summary>
        public static Color RandomColor(float alpha = 1f)
        {
            return new Color(Random.value, Random.value, Random.value, alpha);
        }
        
        /// <summary>
        /// Check if two objects are roughly at the same position (within threshold).
        /// Uses squared distance for performance.
        /// </summary>
        public static bool IsNearPosition(Vector3 pos1, Vector3 pos2, float threshold = 0.1f)
        {
            float sqrThreshold = threshold * threshold;
            return (pos1 - pos2).sqrMagnitude < sqrThreshold;
        }
    }
}
