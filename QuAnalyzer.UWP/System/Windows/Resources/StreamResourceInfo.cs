namespace System.Windows.Resources
{
    using Uno.UI.Generic;

    public class StreamResourceInfo : Proxy<global::Windows.UI.Xaml.Resources.StreamResourceInfo>
    {
        public System.String ContentType
        {
            get => __ProxyValue.ContentType;
        }

        public System.IO.Stream Stream
        {
            get => __ProxyValue.Stream;
        }

        public StreamResourceInfo(): base()
        {
        }

        public StreamResourceInfo(System.IO.Stream @stream, System.String @contentType): base(@stream, @contentType)
        {
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}