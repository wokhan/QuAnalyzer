namespace System.Windows
{
    using Uno.UI.Generic;

    public class ComponentResourceKey : Proxy<global::Windows.UI.Xaml.ComponentResourceKey>
    {
        public System.Type TypeInTargetAssembly
        {
            get => __ProxyValue.TypeInTargetAssembly;
            set => __ProxyValue.TypeInTargetAssembly = value;
        }

        public System.Reflection.Assembly Assembly
        {
            get => __ProxyValue.Assembly;
        }

        public System.Object ResourceId
        {
            get => __ProxyValue.ResourceId;
            set => __ProxyValue.ResourceId = value;
        }

        public ComponentResourceKey(): base()
        {
        }

        public ComponentResourceKey(System.Type @typeInTargetAssembly, System.Object @resourceId): base(@typeInTargetAssembly, @resourceId)
        {
        }

        public override System.Boolean Equals(System.Object o) => __ProxyValue.Equals(@o);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
        public override System.String ToString() => __ProxyValue.ToString();
        public System.Object ProvideValue(System.IServiceProvider serviceProvider) => __ProxyValue.ProvideValue(@serviceProvider);
    }
}