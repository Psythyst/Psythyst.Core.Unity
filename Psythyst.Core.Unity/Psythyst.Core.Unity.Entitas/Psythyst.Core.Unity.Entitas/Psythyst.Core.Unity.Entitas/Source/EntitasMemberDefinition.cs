using System;

using Psythyst.Data.Entitas;

namespace Psythyst.Core.Unity.Entitas
{
    /// <summary>
    /// EntitasMemberDefinition Class. 
    /// </summary>
    [Serializable]
    public class EntitasMemberDefinition
    {
        public StringReference Type;
        public StringReference Name;
        public EntityIndexType Index;
    }
}