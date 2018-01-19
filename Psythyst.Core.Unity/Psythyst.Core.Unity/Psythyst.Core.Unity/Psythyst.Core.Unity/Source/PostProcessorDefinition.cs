using System;

using UnityEngine;

using Psythyst;

namespace Psythyst.Core.Unity
{
    /// <summary>
    /// PostProcessorDefinition Class.
    /// </summary>
    [Serializable]
    public abstract class PostProcessorDefinition : ScriptableObject
    {
        public bool Enabled = true;
    }

    /// <summary>
    /// PostProcessorDefinition Class.
    /// </summary>
    [Serializable]
    public abstract class PostProcessorDefinition<TResult> : PostProcessorDefinition
    {
        public abstract IPostProcessor<TResult> GetPostProcessor();
    }
}