namespace System.Windows.Media.TextFormatting
{
    using Uno.UI.Generic;

    public class TextModifier : Proxy<global::Windows.UI.Xaml.Media.TextFormatting.TextModifier>
    {
        public System.Windows.Media.TextFormatting.CharacterBufferReference CharacterBufferReference
        {
            get => __ProxyValue.CharacterBufferReference;
        }

        public System.Boolean HasDirectionalEmbedding
        {
            get => __ProxyValue.HasDirectionalEmbedding;
        }

        public System.Windows.FlowDirection FlowDirection
        {
            get => __ProxyValue.FlowDirection;
        }

        public System.Int32 Length
        {
            get => __ProxyValue.Length;
        }

        public System.Windows.Media.TextFormatting.TextRunProperties Properties
        {
            get => __ProxyValue.Properties;
        }

        public System.Windows.Media.TextFormatting.TextRunProperties ModifyProperties(System.Windows.Media.TextFormatting.TextRunProperties properties) => __ProxyValue.ModifyProperties(@properties);
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}