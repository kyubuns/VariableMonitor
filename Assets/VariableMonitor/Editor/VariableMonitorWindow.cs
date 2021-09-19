using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace VariableMonitor.Editor
{
    public class VariableMonitorWindow : EditorWindow
    {
        private IReadOnlyDictionary<string, string> _values;

        [MenuItem("Window/Variable Monitor")]
        public static void ShowWindow()
        {
            GetWindow<VariableMonitorWindow>("Variable Monitor");
        }

        public void OnEnable()
        {
            Debug.Log("OnEnable");
            EditorApplication.playModeStateChanged += PlayModeStateChanged;
        }

        public void OnDisable()
        {
            Debug.Log("OnDisable");
            VariableLogger.OnUpdate -= OnUpdate;
            EditorApplication.playModeStateChanged -= PlayModeStateChanged;
        }

        private void PlayModeStateChanged(PlayModeStateChange playModeStateChange)
        {
            if (playModeStateChange == PlayModeStateChange.EnteredPlayMode)
            {
                _values = VariableLogger.Values;
                VariableLogger.OnUpdate += OnUpdate;
                Repaint();
            }
        }

        private void OnUpdate(string key, string value)
        {
            Repaint();
        }

        public void OnGUI()
        {
            if (_values == null) return;
            foreach (var variable in _values)
            {
                using (new GUILayout.HorizontalScope())
                {
                    GUILayout.Label(variable.Key);
                    GUILayout.FlexibleSpace();
                    GUILayout.Label(variable.Value);
                }
            }
        }
    }
}
