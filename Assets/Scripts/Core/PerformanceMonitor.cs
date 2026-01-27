using UnityEngine;
using System.Collections.Generic;
using System.Text;

namespace MiddleEarth.Core
{
    /// <summary>
    /// Performance monitoring utility for tracking frame times and memory usage.
    /// Useful for identifying performance bottlenecks during development.
    /// </summary>
    public class PerformanceMonitor : MonoBehaviour
    {
        private static PerformanceMonitor _instance;
        public static PerformanceMonitor Instance
        {
            get
            {
                if (_instance == null)
                {
                    GameObject go = new GameObject("PerformanceMonitor");
                    _instance = go.AddComponent<PerformanceMonitor>();
                    DontDestroyOnLoad(go);
                }
                return _instance;
            }
        }
        
        [Header("Settings")]
        [SerializeField] private bool _showOnScreen = false;
        [SerializeField] private int _framesSampleSize = 60;
        
        private Queue<float> _frameTimes = new Queue<float>();
        private float _currentFPS;
        private float _averageFPS;
        private float _minFPS = float.MaxValue;
        private float _maxFPS = 0f;
        private long _totalMemoryAllocated;
        private StringBuilder _displayText = new StringBuilder(256);
        
        private void Update()
        {
            UpdateFPSTracking();
        }
        
        private void UpdateFPSTracking()
        {
            float deltaTime = Time.unscaledDeltaTime;
            _frameTimes.Enqueue(deltaTime);
            
            if (_frameTimes.Count > _framesSampleSize)
            {
                _frameTimes.Dequeue();
            }
            
            // Calculate current FPS
            _currentFPS = deltaTime > 0f ? 1f / deltaTime : 0f;
            
            // Calculate average FPS
            float totalTime = 0f;
            foreach (float time in _frameTimes)
            {
                totalTime += time;
            }
            _averageFPS = _frameTimes.Count > 0 ? _frameTimes.Count / totalTime : 0f;
            
            // Track min/max
            if (_currentFPS < _minFPS && _currentFPS > 0f) _minFPS = _currentFPS;
            if (_currentFPS > _maxFPS) _maxFPS = _currentFPS;
            
            // Track memory
            _totalMemoryAllocated = System.GC.GetTotalMemory(false);
        }
        
        private void OnGUI()
        {
            if (!_showOnScreen) return;
            
            _displayText.Clear();
            _displayText.AppendLine("=== Performance Monitor ===");
            _displayText.AppendLine($"FPS: {_currentFPS:F1} (Avg: {_averageFPS:F1})");
            _displayText.AppendLine($"Min: {_minFPS:F1} | Max: {_maxFPS:F1}");
            _displayText.AppendLine($"Frame Time: {Time.deltaTime * 1000f:F2}ms");
            _displayText.AppendLine($"Memory: {_totalMemoryAllocated / 1024f / 1024f:F2} MB");
            _displayText.AppendLine($"Time Scale: {Time.timeScale:F2}");
            
            GUI.Label(new Rect(10, 10, 300, 150), _displayText.ToString());
        }
        
        public void EnableDisplay(bool enable)
        {
            _showOnScreen = enable;
        }
        
        public void ResetStats()
        {
            _frameTimes.Clear();
            _minFPS = float.MaxValue;
            _maxFPS = 0f;
        }
        
        public float GetCurrentFPS() => _currentFPS;
        public float GetAverageFPS() => _averageFPS;
        public float GetMinFPS() => _minFPS;
        public float GetMaxFPS() => _maxFPS;
        public long GetMemoryUsage() => _totalMemoryAllocated;
    }
}
