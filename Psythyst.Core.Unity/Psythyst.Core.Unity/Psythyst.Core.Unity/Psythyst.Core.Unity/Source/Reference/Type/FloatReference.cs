using System;

namespace Psythyst.Core.Unity
{
    /// <summary>
    /// FloatReference Class.
    /// </summary>
    [Serializable]
    public class FloatReference : Reference<float, FloatVariable>
    {
        public FloatReference(float Value) : base(Value) { }
        public FloatReference() { }

        /* CONVERSION OPERATION(S). */
        public static implicit operator float(FloatReference Reference) => Reference.Value;
        public static implicit operator FloatReference(float Value) => new FloatReference(Value);

        /* MULTIPLICATIVE OPERATOR(S). */
        public static FloatReference operator *(FloatReference A, FloatReference B) => new FloatReference(A.Value * B.Value);
        public static FloatReference operator /(FloatReference A, FloatReference B) => new FloatReference(A.Value / B.Value);
        public static FloatReference operator %(FloatReference A, FloatReference B) => new FloatReference(A.Value % B.Value);

        /* ADDITIVE OPERATOR(S). */
        public static FloatReference operator +(FloatReference A, FloatReference B) => new FloatReference(A.Value + B.Value);
        public static FloatReference operator -(FloatReference A, FloatReference B) => new FloatReference(A.Value - B.Value);

        /* RELATIONAL OPERATOR(S). */
        public static bool operator < (FloatReference A, FloatReference B) => A.Value < B.Value;
        public static bool operator <=(FloatReference A, FloatReference B) => A.Value <= B.Value;
        public static bool operator > (FloatReference A, FloatReference B) => A.Value > B.Value;
        public static bool operator >=(FloatReference A, FloatReference B) => A.Value >= B.Value;

        /* EQUALITY OPERATOR(S). */
        public static bool operator ==(FloatReference A, FloatReference B) => A.Value == B.Value;
        public static bool operator !=(FloatReference A, FloatReference B) => A.Value != B.Value;

        public override bool Equals(object Object)
        {
            return Value.Equals(Object);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
    }
}