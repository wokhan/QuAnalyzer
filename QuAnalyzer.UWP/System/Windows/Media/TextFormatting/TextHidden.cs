namespace System.Windows.Media.TextFormatting
{
    using Uno.UI.Generic;

    public class TextHidden : Proxy<global::Windows.UI.Xaml.Media.TextFormatting.TextHidden>
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

        public TextHidden(System.Int32 @length): base(@length)
        {
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}