namespace System.Windows.Markup.Localizer
{
    using Uno.UI.Generic;

    public class BamlLocalizableResourceKey : Proxy<global::Windows.UI.Xaml.Markup.Localizer.BamlLocalizableResourceKey>
    {
        public System.String Uid
        {
            get => __ProxyValue.Uid;
        }

        public System.String ClassName
        {
            get => __ProxyValue.ClassName;
        }

        public System.String PropertyName
        {
            get => __ProxyValue.PropertyName;
        }

        public System.String AssemblyName
        {
            get => __ProxyValue.AssemblyName;
        }

        public BamlLocalizableResourceKey(System.String @uid, System.String @className, System.String @propertyName): base(@uid, @className, @propertyName)
        {
        }

        public System.Boolean Equals(System.Windows.Markup.Localizer.BamlLocalizableResourceKey other) => __ProxyValue.Equals(@other);
        public override System.Boolean Equals(System.Object other) => __ProxyValue.Equals(@other);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
        public override System.String ToString() => __ProxyValue.ToString();
    }
}