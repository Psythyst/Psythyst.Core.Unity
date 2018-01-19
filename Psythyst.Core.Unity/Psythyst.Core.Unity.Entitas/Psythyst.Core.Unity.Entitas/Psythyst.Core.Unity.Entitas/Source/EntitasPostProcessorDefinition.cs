using System;

using UnityEngine;

using Psythyst.Data.Entitas;

namespace Psythyst.Core.Unity.Entitas
{
    /// <summary>
    /// EntitasPostProcessorDefinition Class.
    /// </summary>
    [Serializable]
    public abstract class EntitasPostProcessorDefinition : PostProcessorDefinition<OutputModel> { }

    /// <summary>
    /// EntitasPostProcessorDefinition Class.
    /// </summary>
    [Serializable]
    public abstract class EntitasPostProcessorDefinition<TPostProcessor> : EntitasPostProcessorDefinition where TPostProcessor : IPostProcessor<OutputModel> 
    { 
        public override IPostProcessor<OutputModel> GetPostProcessor()
        {
            return Activator.CreateInstance<TPostProcessor>();
        }
    }
}