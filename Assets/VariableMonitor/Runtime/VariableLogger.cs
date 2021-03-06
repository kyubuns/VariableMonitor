using System;
using System.Collections.Generic;
using System.Diagnostics;
using UniRx;
using UnityEngine;

namespace VariableMonitor
{
    public static class VariableLogger
    {
        public static IReadOnlyDictionary<string, string> Values => _values;
        public static Action<string, string> OnUpdate { get; set; }

        private static Dictionary<string, string> _values;

        [RuntimeInitializeOnLoadMethod]
        private static void Init()
        {
            OnUpdate = null;
            _values = new Dictionary<string, string>();
        }

        [Conditional("UNITY_EDITOR")]
        public static void Log(string name, object value)
        {
            var text = value.ToString();
            _values[name] = text;
            OnUpdate?.Invoke(name, text);
        }

#if SUPPORT_UNIRX
        [Conditional("UNITY_EDITOR")]
        public static void Register<T>(string name, IObservable<T> reactiveProperty)
        {
            reactiveProperty.Subscribe(x =>
            {
                Log(name, x);
            });
        }
#endif
    }
}
