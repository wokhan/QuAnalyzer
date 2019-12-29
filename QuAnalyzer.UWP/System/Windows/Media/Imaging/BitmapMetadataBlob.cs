namespace System.Windows.Media.Imaging
{
    using Uno.UI.Generic;

    public class BitmapMetadataBlob : Proxy<global::Windows.UI.Xaml.Media.Imaging.BitmapMetadataBlob>
    {
        public BitmapMetadataBlob(System.Byte[] @blob): base(@blob)
        {
        }

        public System.Byte[] GetBlobValue() => __ProxyValue.GetBlobValue();
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}