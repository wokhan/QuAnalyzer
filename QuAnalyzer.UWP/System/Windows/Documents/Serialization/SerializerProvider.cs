namespace System.Windows.Documents.Serialization
{
    using Uno.UI.Generic;

    public class SerializerProvider : Proxy<global::Windows.UI.Xaml.Documents.Serialization.SerializerProvider>
    {
        public System.Collections.ObjectModel.ReadOnlyCollection<System.Windows.Documents.Serialization.SerializerDescriptor> InstalledSerializers
        {
            get => __ProxyValue.InstalledSerializers;
        }

        public SerializerProvider(): base()
        {
        }

        public static void RegisterSerializer(System.Windows.Documents.Serialization.SerializerDescriptor serializerDescriptor, System.Boolean overwrite) => Windows.UI.Xaml.Documents.Serialization.SerializerProvider.RegisterSerializer(@serializerDescriptor, @overwrite);
        public static void UnregisterSerializer(System.Windows.Documents.Serialization.SerializerDescriptor serializerDescriptor) => Windows.UI.Xaml.Documents.Serialization.SerializerProvider.UnregisterSerializer(@serializerDescriptor);
        public System.Windows.Documents.Serialization.SerializerWriter CreateSerializerWriter(System.Windows.Documents.Serialization.SerializerDescriptor serializerDescriptor, System.IO.Stream stream) => __ProxyValue.CreateSerializerWriter(@serializerDescriptor, @stream);
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}