using System;

namespace Psythyst.Core.Unity
{
    /// <summary>
    /// StringReference Class.
    /// </summary>
    [Serializable]
    public class StringReference : Reference<string, StringVariable>
    {
        public StringReference(string Value) : base(Value) { }
        public StringReference() { }

        /* CONVERSION OPERATION(S). */
        public static implicit operator string(StringReference Reference) => Reference.Value;
        public static implicit operator StringReference(string Value) => new StringReference(Value);

        /* EQUALITY OPERATOR(S). */
        public static bool operator ==(StringReference A, StringReference B) => A.Value == B.Value;
        public static bool operator !=(StringReference A, StringReference B) => A.Value != B.Value;

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