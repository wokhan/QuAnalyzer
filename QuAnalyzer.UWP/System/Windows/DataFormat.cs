namespace System.Windows
{
    using Uno.UI.Generic;

    public class DataFormat : Proxy<global::Windows.UI.Xaml.DataFormat>
    {
        public System.String Name
        {
            get => __ProxyValue.Name;
        }

        public System.Int32 Id
        {
            get => __ProxyValue.Id;
        }

        public DataFormat(System.String @name, System.Int32 @id): base(@name, @id)
        {
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}