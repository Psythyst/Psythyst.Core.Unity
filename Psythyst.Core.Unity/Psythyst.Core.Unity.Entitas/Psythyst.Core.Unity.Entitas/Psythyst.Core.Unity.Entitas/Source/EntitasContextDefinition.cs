using System;
using UnityEngine;

using Psythyst.Data.Entitas;

namespace Psythyst.Core.Unity.Entitas
{
    /// <summary>
    /// EntitasContextDefinition Class.
    /// </summary>
    [CreateAssetMenu(fileName = "New Context Definition", menuName = "Psythyst/Entitas/Context Definition")]
    public class EntitasContextDefinition : ScriptableObject
    {
        public string ContextName;

        public ContextModel GetModel()
        {
            return new ContextModel(ContextName);
        }
    }
}