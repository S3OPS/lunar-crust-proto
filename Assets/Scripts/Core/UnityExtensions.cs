using UnityEngine;

namespace MiddleEarth.Core
{
    /// <summary>
    /// Extensions for Unity components to provide additional functionality.
    /// Implements defensive programming and convenience methods.
    /// </summary>
    public static class UnityExtensions
    {
        /// <summary>
        /// Safely get or add a component to a GameObject.
        /// If the component exists, returns it. Otherwise, adds and returns it.
        /// </summary>
        public static T GetOrAddComponent<T>(this GameObject gameObject) where T : Component
        {
            T component = gameObject.GetComponent<T>();
            if (component == null)
            {
                component = gameObject.AddComponent<T>();
            }
            return component;
        }
        
        /// <summary>
        /// Check if a GameObject has a component without creating garbage.
        /// </summary>
        public static bool HasComponent<T>(this GameObject gameObject) where T : Component
        {
            return gameObject.GetComponent<T>() != null;
        }
        
        /// <summary>
        /// Destroy all children of a transform.
        /// Useful for clearing dynamic UI or procedural content.
        /// </summary>
        public static void DestroyAllChildren(this Transform transform)
        {
            for (int i = transform.childCount - 1; i >= 0; i--)
            {
                Object.Destroy(transform.GetChild(i).gameObject);
            }
        }
        
        /// <summary>
        /// Destroy all children of a transform immediately (editor-safe).
        /// </summary>
        public static void DestroyAllChildrenImmediate(this Transform transform)
        {
            for (int i = transform.childCount - 1; i >= 0; i--)
            {
                #if UNITY_EDITOR
                if (!Application.isPlaying)
                {
                    Object.DestroyImmediate(transform.GetChild(i).gameObject);
                }
                else
                #endif
                {
                    Object.Destroy(transform.GetChild(i).gameObject);
                }
            }
        }
        
        /// <summary>
        /// Set the layer recursively for a GameObject and all its children.
        /// </summary>
        public static void SetLayerRecursively(this GameObject gameObject, int layer)
        {
            gameObject.layer = layer;
            foreach (Transform child in gameObject.transform)
            {
                child.gameObject.SetLayerRecursively(layer);
            }
        }
        
        /// <summary>
        /// Reset a transform to default values (position 0,0,0, rotation identity, scale 1,1,1).
        /// </summary>
        public static void Reset(this Transform transform)
        {
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            transform.localScale = Vector3.one;
        }
        
        /// <summary>
        /// Copy transform values from another transform.
        /// </summary>
        public static void CopyFrom(this Transform transform, Transform other)
        {
            transform.position = other.position;
            transform.rotation = other.rotation;
            transform.localScale = other.localScale;
        }
        
        /// <summary>
        /// Find child by name recursively.
        /// Returns null if not found.
        /// </summary>
        public static Transform FindDeep(this Transform transform, string name)
        {
            Transform result = transform.Find(name);
            if (result != null)
                return result;
            
            foreach (Transform child in transform)
            {
                result = child.FindDeep(name);
                if (result != null)
                    return result;
            }
            
            return null;
        }
        
        /// <summary>
        /// Set active state for multiple GameObjects at once.
        /// </summary>
        public static void SetActiveAll(bool active, params GameObject[] gameObjects)
        {
            foreach (GameObject go in gameObjects)
            {
                if (go != null)
                {
                    go.SetActive(active);
                }
            }
        }
        
        /// <summary>
        /// Clamp a vector's magnitude.
        /// </summary>
        public static Vector3 ClampMagnitude(this Vector3 vector, float maxMagnitude)
        {
            if (vector.sqrMagnitude > maxMagnitude * maxMagnitude)
            {
                return vector.normalized * maxMagnitude;
            }
            return vector;
        }
        
        /// <summary>
        /// Get the direction to another transform.
        /// </summary>
        public static Vector3 DirectionTo(this Transform from, Transform to)
        {
            return (to.position - from.position).normalized;
        }
        
        /// <summary>
        /// Get the distance to another transform using sqrMagnitude (faster).
        /// </summary>
        public static float SqrDistanceTo(this Transform from, Transform to)
        {
            return (to.position - from.position).sqrMagnitude;
        }
        
        /// <summary>
        /// Check if a position is within a certain distance (using sqrMagnitude).
        /// </summary>
        public static bool IsWithinDistance(this Transform from, Vector3 position, float distance)
        {
            float sqrDistance = distance * distance;
            return (position - from.position).sqrMagnitude <= sqrDistance;
        }
    }
}
