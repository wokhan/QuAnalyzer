namespace System.Windows.Media.TextFormatting
{
    using Uno.UI.Generic;

    public class CharacterBufferReference : Proxy<global::Windows.UI.Xaml.Media.TextFormatting.CharacterBufferReference>
    {
        public CharacterBufferReference(System.Char[] @characterArray, System.Int32 @offsetToFirstChar): base(@characterArray, @offsetToFirstChar)
        {
        }

        public CharacterBufferReference(System.String @characterString, System.Int32 @offsetToFirstChar): base(@characterString, @offsetToFirstChar)
        {
        }

        public CharacterBufferReference(System.Char* @unsafeCharacterString, System.Int32 @characterLength): base(@unsafeCharacterString, @characterLength)
        {
        }

        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public System.Boolean Equals(System.Windows.Media.TextFormatting.CharacterBufferReference value) => __ProxyValue.Equals(@value);
        public static System.Boolean op_Equality(System.Windows.Media.TextFormatting.CharacterBufferReference left, System.Windows.Media.TextFormatting.CharacterBufferReference right) => Windows.UI.Xaml.Media.TextFormatting.CharacterBufferReference.op_Equality(@left, @right);
        public static System.Boolean op_Inequality(System.Windows.Media.TextFormatting.CharacterBufferReference left, System.Windows.Media.TextFormatting.CharacterBufferReference right) => Windows.UI.Xaml.Media.TextFormatting.CharacterBufferReference.op_Inequality(@left, @right);
        public override System.String ToString() => __ProxyValue.ToString();
    }
}