namespace System.Windows.Media.Imaging
{
    using Uno.UI.Generic;

    public class BitmapCodecInfo : Proxy<global::Windows.UI.Xaml.Media.Imaging.BitmapCodecInfo>
    {
        public System.Guid ContainerFormat
        {
            get => __ProxyValue.ContainerFormat;
        }

        public System.String Author
        {
            get => __ProxyValue.Author;
        }

        public System.Version Version
        {
            get => __ProxyValue.Version;
        }

        public System.Version SpecificationVersion
        {
            get => __ProxyValue.SpecificationVersion;
        }

        public System.String FriendlyName
        {
            get => __ProxyValue.FriendlyName;
        }

        public System.String DeviceManufacturer
        {
            get => __ProxyValue.DeviceManufacturer;
        }

        public System.String DeviceModels
        {
            get => __ProxyValue.DeviceModels;
        }

        public System.String MimeTypes
        {
            get => __ProxyValue.MimeTypes;
        }

        public System.String FileExtensions
        {
            get => __ProxyValue.FileExtensions;
        }

        public System.Boolean SupportsAnimation
        {
            get => __ProxyValue.SupportsAnimation;
        }

        public System.Boolean SupportsLossless
        {
            get => __ProxyValue.SupportsLossless;
        }

        public System.Boolean SupportsMultipleFrames
        {
            get => __ProxyValue.SupportsMultipleFrames;
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}