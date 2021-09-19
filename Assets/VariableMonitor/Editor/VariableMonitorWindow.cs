using System.Collections.Generic;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

namespace VariableMonitor.Editor
{
    public class VariableMonitorWindow : EditorWindow
    {
        private IReadOnlyDictionary<string, string> _values;
        private List<Item> _items;
        private ReorderableList _reorderableList;

        [MenuItem("Window/Variable Monitor")]
        public static void ShowWindow()
        {
            GetWindow<VariableMonitorWindow>("Variable Monitor");
        }

        public void OnEnable()
        {
            EditorApplication.playModeStateChanged += PlayModeStateChanged;

            _items = new List<Item>();
            _reorderableList = new ReorderableList(
                elements: _items,
                elementType: typeof(string),
                draggable: false,
                displayHeader: false,
                displayAddButton: false,
                displayRemoveButton: false
            );
            _reorderableList.draggable = true;
            _reorderableList.drawElementCallback += DrawElementCallback;
        }

        public void OnDisable()
        {
            VariableLogger.OnUpdate -= OnUpdate;
            EditorApplication.playModeStateChanged -= PlayModeStateChanged;
        }

        private void PlayModeStateChanged(PlayModeStateChange playModeStateChange)
        {
            if (playModeStateChange == PlayModeStateChange.EnteredPlayMode)
            {
                _values = VariableLogger.Values;
                VariableLogger.OnUpdate += OnUpdate;
                OnUpdate();
            }
        }

        private void OnUpdate(string key, string value)
        {
            OnUpdate();
        }

        private void OnUpdate()
        {
            _items.Clear();
            foreach (var v in _values)
            {
                _items.Add(new Item(v.Key, v.Value));
            }
            Repaint();
        }

        public void OnGUI()
        {
            _reorderableList.DoLayoutList();
        }

        private void DrawElementCallback(Rect rect, int index, bool isActive, bool isFocused)
        {
            var v = _items[index];

            {
                var skinLabel = GUI.skin.label;
                skinLabel.alignment = TextAnchor.MiddleLeft;
                EditorGUI.LabelField(rect, v.Key, skinLabel);
            }

            {
                var skinLabel = GUI.skin.label;
                skinLabel.alignment = TextAnchor.MiddleRight;
                EditorGUI.LabelField(rect, v.Value, skinLabel);
            }
        }

        private class Item
        {
            public string Key { get; }
            public string Value { get; }

            public Item(string key, string value)
            {
                Key = key;
                Value = value;
            }
        }
    }
}
