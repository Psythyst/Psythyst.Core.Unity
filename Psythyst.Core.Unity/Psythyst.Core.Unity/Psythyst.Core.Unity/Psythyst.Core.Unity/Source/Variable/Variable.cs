using System;

using UnityEngine;

namespace Psythyst.Core.Unity
{
    /// <summary>
    /// Variable Class.
    /// </summary>
    [Serializable]
    public class Variable<T> : ScriptableObject
    {
        public T Value;

        public void SetValue(T value) => Value = value;
        public void SetValue(Variable<T> value) => Value = value.Value;
    }
}