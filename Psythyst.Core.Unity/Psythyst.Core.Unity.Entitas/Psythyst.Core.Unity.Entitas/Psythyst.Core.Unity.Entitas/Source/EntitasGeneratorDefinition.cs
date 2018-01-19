using System;

using Psythyst.Data.Entitas;

namespace Psythyst.Core.Unity.Entitas
{
    /// <summary>
    /// EntitasGeneratorDefinition Class.
    /// </summary>
    [Serializable]
    public abstract class EntitasGeneratorDefinition : GeneratorDefinition<ProjectModel, OutputModel>  { }
    
    /// <summary>
    /// EntitasGeneratorDefinition Class.
    /// </summary>
    [Serializable]
    public abstract class EntitasGeneratorDefinition<TGenerator> : EntitasGeneratorDefinition where TGenerator : IGenerator<ProjectModel, OutputModel>
    { 
        public override IGenerator<ProjectModel, OutputModel> GetGenerator()
        {
            return Activator.CreateInstance<TGenerator>();
        }
    }
}