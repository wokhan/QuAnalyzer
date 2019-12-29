namespace System.Windows.Documents.Serialization
{
    using Uno.UI.Generic;

    public class SerializerDescriptor : Proxy<global::Windows.UI.Xaml.Documents.Serialization.SerializerDescriptor>
    {
        public System.String DisplayName
        {
            get => __ProxyValue.DisplayName;
        }

        public System.String ManufacturerName
        {
            get => __ProxyValue.ManufacturerName;
        }

        public System.Uri ManufacturerWebsite
        {
            get => __ProxyValue.ManufacturerWebsite;
        }

        public System.String DefaultFileExtension
        {
            get => __ProxyValue.DefaultFileExtension;
        }

        public System.String AssemblyName
        {
            get => __ProxyValue.AssemblyName;
        }

        public System.String AssemblyPath
        {
            get => __ProxyValue.AssemblyPath;
        }

        public System.String FactoryInterfaceName
        {
            get => __ProxyValue.FactoryInterfaceName;
        }

        public System.Version AssemblyVersion
        {
            get => __ProxyValue.AssemblyVersion;
        }

        public System.Version WinFXVersion
        {
            get => __ProxyValue.WinFXVersion;
        }

        public System.Boolean IsLoadable
        {
            get => __ProxyValue.IsLoadable;
        }

        public static System.Windows.Documents.Serialization.SerializerDescriptor CreateFromFactoryInstance(System.Windows.Documents.Serialization.ISerializerFactory factoryInstance) => Windows.UI.Xaml.Documents.Serialization.SerializerDescriptor.CreateFromFactoryInstance(@factoryInstance);
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
        public override System.String ToString() => __ProxyValue.ToString();
    }
}