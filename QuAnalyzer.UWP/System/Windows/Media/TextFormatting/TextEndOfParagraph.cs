namespace System.Windows.Media.TextFormatting
{
    using Uno.UI.Generic;

    public class TextEndOfParagraph : Proxy<global::Windows.UI.Xaml.Media.TextFormatting.TextEndOfParagraph>
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

        public TextEndOfParagraph(System.Int32 @length): base(@length)
        {
        }

        public TextEndOfParagraph(System.Int32 @length, System.Windows.Media.TextFormatting.TextRunProperties @textRunProperties): base(@length, @textRunProperties)
        {
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}