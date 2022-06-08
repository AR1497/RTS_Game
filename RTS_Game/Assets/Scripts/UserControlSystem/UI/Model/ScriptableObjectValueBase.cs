using System;
using UnityEngine;

namespace UserControlSystem
{
    public sealed class ScriptableObjectValueBase<T> : ScriptableObject
    {
        public T CurrentValue { get; private set; }
        public Action<T> Value;

        public void SetValue(T value)
        {
            CurrentValue = value;
            Value?.Invoke(value);
        }
    }
}