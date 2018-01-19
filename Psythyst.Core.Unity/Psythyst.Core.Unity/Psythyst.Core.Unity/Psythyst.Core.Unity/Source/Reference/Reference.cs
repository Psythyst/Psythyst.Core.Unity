using System;

namespace Psythyst.Core.Unity
{
    /// <summary>
    /// Reference Class.
    /// </summary>
    [Serializable]
    public abstract class Reference { }

    /// <summary>
    /// Reference Class.
    /// </summary>
    [Serializable]
    public class Reference<TReference, TVariable> : Reference where TVariable : Variable<TReference>
    {
        public bool UseConstant = true;

        public TReference ConstantValue;
        public TVariable Variable;

        public Reference() { }
        public Reference(TReference value)
        {
            UseConstant = true;
            ConstantValue = value;
        }

        public TReference Value
        {
            get { return UseConstant ? ConstantValue : Variable.Value; }
        }

        public static implicit operator TReference(Reference<TReference, TVariable> Reference)
        {
            return Reference.Value;
        }

        public static implicit operator Reference<TReference, TVariable>(TReference Value)
        {
            return new Reference<TReference, TVariable>(Value);
        }
    }
}