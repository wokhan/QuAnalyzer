namespace System.Windows
{
    using Uno.UI.Generic;

    public class TemplatePartAttribute : Proxy<global::Windows.UI.Xaml.TemplatePartAttribute>
    {
        public System.String Name
        {
            get => __ProxyValue.Name;
            set => __ProxyValue.Name = value;
        }

        public System.Type Type
        {
            get => __ProxyValue.Type;
            set => __ProxyValue.Type = value;
        }

        public System.Object TypeId
        {
            get => __ProxyValue.TypeId;
        }

        public TemplatePartAttribute(): base()
        {
        }

        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
        public System.Boolean Match(System.Object obj) => __ProxyValue.Match(@obj);
        public System.Boolean IsDefaultAttribute() => __ProxyValue.IsDefaultAttribute();
        public override System.String ToString() => __ProxyValue.ToString();
    }
}