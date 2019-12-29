namespace System.Windows.Documents.Serialization
{
    using Uno.UI.Generic;

    public class ISerializerFactory : Proxy<global::Windows.UI.Xaml.Documents.Serialization.ISerializerFactory>
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

        public System.Windows.Documents.Serialization.SerializerWriter CreateSerializerWriter(System.IO.Stream stream) => __ProxyValue.CreateSerializerWriter(@stream);
    }
}