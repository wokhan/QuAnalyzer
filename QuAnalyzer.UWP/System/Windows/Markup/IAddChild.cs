namespace System.Windows.Markup
{
    using Uno.UI.Generic;

    public class IAddChild : Proxy<global::Windows.UI.Xaml.Markup.IAddChild>
    {
        public void AddChild(System.Object value) => __ProxyValue.AddChild(@value);
        public void AddText(System.String text) => __ProxyValue.AddText(@text);
    }
}