using System.Linq;
using System.Collections.Generic;

using UnityEngine;

using Psythyst.Data.Entitas;

namespace Psythyst.Core.Unity.Entitas
{
    /// <summary>
    /// EntitasComponentDefinition Class.
    /// </summary>
    [CreateAssetMenu(fileName = "New Component Definition", menuName = "Psythyst/Entitas/Component Definition")]
    public class EntitasComponentDefinition : ScriptableObject
    {
        public string ComponentName;

        public bool Unique;
        public string UniquePrefix;

        public List<EntitasContextDefinition> ContextDefinitionList;

        public List<EntitasMemberDefinition> MemberDefinitionList;

        public ComponentModel GetModel()
        {
            var ContextList = ContextDefinitionList.Select(x => x.ContextName);
            var AttributeList = MemberDefinitionList.Select(x => new ComponentMemberModel(x.Type, x.Name, x.Index));

            return new ComponentModel(
                ComponentName, 
                ContextList.ToArray(), 
                UniquePrefix, 
                Unique,
                AttributeList.ToArray());
        }
    }
}