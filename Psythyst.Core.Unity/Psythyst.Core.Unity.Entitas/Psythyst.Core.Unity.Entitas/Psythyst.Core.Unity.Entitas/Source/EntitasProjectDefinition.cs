using System.Linq;
using System.Collections.Generic;

using UnityEngine;
using UnityEditor;

using Psythyst.Data.Entitas;

namespace Psythyst.Core.Unity.Entitas
{
    /// <summary>
    /// EntitasProjectDefinition Class.
    /// </summary>
    [CreateAssetMenu(fileName = "New Project Definition", menuName = "Psythyst/Entitas/Project Definition")]
    public class EntitasProjectDefinition : ScriptableObject
    {
        public List<EntitasContextDefinition> ContextDefinitionList;

        public List<EntitasComponentDefinition> ComponentDefinitionList;

        public EntitasProjectUnitDefinition ProjectUnitDefinition;

        public ProjectModel GetModel()
        {
            var _ContextList = ContextDefinitionList.Select(x => x.GetModel());
            var _ComponentList = ComponentDefinitionList.Select(x => x.GetModel());

            var CustomEntityIndexList = Enumerable.Empty<CustomEntityIndexModel>();

            return new ProjectModel(_ContextList.ToArray(), _ComponentList.ToArray(), CustomEntityIndexList.ToArray());
        }

        public void Generate()
        {
            if (ProjectUnitDefinition != null) {
                ProjectUnitDefinition.Generate(GetModel());
            }
        }

        [MenuItem("Tools/Psythyst/Generate")]
        static void GenerateAll()
        {
            var AssetGuids = AssetDatabase.FindAssets("t:EntitasProjectDefinition");

            foreach (var AssetGuid in AssetGuids)
            {
                var AssetPath = AssetDatabase.GUIDToAssetPath(AssetGuid);
                var Asset = AssetDatabase.LoadAssetAtPath<EntitasProjectDefinition>(AssetPath);

                if (Asset.ProjectUnitDefinition != null)
                    Asset.ProjectUnitDefinition.Generate(Asset.GetModel());
            }
        }
    }
}