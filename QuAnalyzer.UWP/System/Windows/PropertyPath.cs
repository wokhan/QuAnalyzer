namespace System.Windows
{
    using Uno.UI.Generic;

    public class PropertyPath : Proxy<global::Windows.UI.Xaml.PropertyPath>
    {
        public System.String Path
        {
            get => __ProxyValue.Path;
            set => __ProxyValue.Path = value;
        }

        public System.Collections.ObjectModel.Collection<System.Object> PathParameters
        {
            get => __ProxyValue.PathParameters;
        }

        public PropertyPath(System.String @path, System.Object[] @pathParameters): base(@path, @pathParameters)
        {
        }

        public PropertyPath(System.Object @parameter): base(@parameter)
        {
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}