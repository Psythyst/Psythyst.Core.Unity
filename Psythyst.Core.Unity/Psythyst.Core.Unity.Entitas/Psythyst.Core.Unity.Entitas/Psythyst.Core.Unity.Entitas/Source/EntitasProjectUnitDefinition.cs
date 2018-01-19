using UnityEngine;

using Psythyst.Data.Entitas;

namespace Psythyst.Core.Unity.Entitas
{
    /// <summary>
    /// EntitasProjectUnitDefinition Class.
    /// </summary>
    [CreateAssetMenu(fileName = "New ProjectUnit Definition", menuName = "Psythyst/Entitas/ProjectUnit Definition")]
    public class EntitasProjectUnitDefinition : ProjectUnitDefinition<ProjectModel, OutputModel, EntitasGeneratorDefinition, EntitasPostProcessorDefinition> { }
}