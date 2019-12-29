namespace System.Windows.Media.TextFormatting
{
    using Uno.UI.Generic;

    public class TextCharacters : Proxy<global::Windows.UI.Xaml.Media.TextFormatting.TextCharacters>
    {
        public System.Windows.Media.TextFormatting.CharacterBufferReference CharacterBufferReference
        {
            get => __ProxyValue.CharacterBufferReference;
        }

        public System.Int32 Length
        {
            get => __ProxyValue.Length;
        }

        public System.Windows.Media.TextFormatting.TextRunProperties Properties
        {
            get => __ProxyValue.Properties;
        }

        public TextCharacters(System.Char[] @characterArray, System.Int32 @offsetToFirstChar, System.Int32 @length, System.Windows.Media.TextFormatting.TextRunProperties @textRunProperties): base(@characterArray, @offsetToFirstChar, @length, @textRunProperties)
        {
        }

        public TextCharacters(System.String @characterString, System.Windows.Media.TextFormatting.TextRunProperties @textRunProperties): base(@characterString, @textRunProperties)
        {
        }

        public TextCharacters(System.String @characterString, System.Int32 @offsetToFirstChar, System.Int32 @length, System.Windows.Media.TextFormatting.TextRunProperties @textRunProperties): base(@characterString, @offsetToFirstChar, @length, @textRunProperties)
        {
        }

        public TextCharacters(System.Char* @unsafeCharacterString, System.Int32 @length, System.Windows.Media.TextFormatting.TextRunProperties @textRunProperties): base(@unsafeCharacterString, @length, @textRunProperties)
        {
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}