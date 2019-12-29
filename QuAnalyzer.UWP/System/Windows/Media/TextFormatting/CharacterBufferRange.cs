namespace System.Windows.Media.TextFormatting
{
    using Uno.UI.Generic;

    public class CharacterBufferRange : Proxy<global::Windows.UI.Xaml.Media.TextFormatting.CharacterBufferRange>
    {
        public System.Windows.Media.TextFormatting.CharacterBufferReference CharacterBufferReference
        {
            get => __ProxyValue.CharacterBufferReference;
        }

        public System.Int32 Length
        {
            get => __ProxyValue.Length;
        }

        public static System.Windows.Media.TextFormatting.CharacterBufferRange Empty
        {
            get => __ProxyValue.Empty;
        }

        public CharacterBufferRange(System.Char[] @characterArray, System.Int32 @offsetToFirstChar, System.Int32 @characterLength): base(@characterArray, @offsetToFirstChar, @characterLength)
        {
        }

        public CharacterBufferRange(System.String @characterString, System.Int32 @offsetToFirstChar, System.Int32 @characterLength): base(@characterString, @offsetToFirstChar, @characterLength)
        {
        }

        public CharacterBufferRange(System.Char* @unsafeCharacterString, System.Int32 @characterLength): base(@unsafeCharacterString, @characterLength)
        {
        }

        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public System.Boolean Equals(System.Windows.Media.TextFormatting.CharacterBufferRange value) => __ProxyValue.Equals(@value);
        public static System.Boolean op_Equality(System.Windows.Media.TextFormatting.CharacterBufferRange left, System.Windows.Media.TextFormatting.CharacterBufferRange right) => Windows.UI.Xaml.Media.TextFormatting.CharacterBufferRange.op_Equality(@left, @right);
        public static System.Boolean op_Inequality(System.Windows.Media.TextFormatting.CharacterBufferRange left, System.Windows.Media.TextFormatting.CharacterBufferRange right) => Windows.UI.Xaml.Media.TextFormatting.CharacterBufferRange.op_Inequality(@left, @right);
        public override System.String ToString() => __ProxyValue.ToString();
    }
}