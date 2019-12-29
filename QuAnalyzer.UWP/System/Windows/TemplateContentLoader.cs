namespace System.Windows
{
    using Uno.UI.Generic;

    public class TemplateContentLoader : Proxy<global::Windows.UI.Xaml.TemplateContentLoader>
    {
        public TemplateContentLoader(): base()
        {
        }

        public System.Object Load(System.Xaml.XamlReader xamlReader, System.IServiceProvider serviceProvider) => __ProxyValue.Load(@xamlReader, @serviceProvider);
        public System.Xaml.XamlReader Save(System.Object value, System.IServiceProvider serviceProvider) => __ProxyValue.Save(@value, @serviceProvider);
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}