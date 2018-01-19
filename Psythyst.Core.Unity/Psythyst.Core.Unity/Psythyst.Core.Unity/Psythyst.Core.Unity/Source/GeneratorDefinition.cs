using System;

using UnityEngine;

using Psythyst;

namespace Psythyst.Core.Unity
{
    /// <summary>
    /// GeneratorDefinition Class.
    /// </summary>
    [Serializable]
    public abstract class GeneratorDefinition : ScriptableObject
    {
        public bool Enabled = true;
    }

    /// <summary>
    /// GeneratorDefinition Class.
    /// </summary>
    [Serializable]
    public abstract class GeneratorDefinition<TSource, TResult> : GeneratorDefinition
    {
        public abstract IGenerator<TSource, TResult> GetGenerator();
    }
}