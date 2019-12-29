namespace System.Windows.Media.Imaging
{
    using Uno.UI.Generic;

    public class WmpBitmapEncoder : Proxy<global::Windows.UI.Xaml.Media.Imaging.WmpBitmapEncoder>
    {
        public System.Single ImageQualityLevel
        {
            get => __ProxyValue.ImageQualityLevel;
            set => __ProxyValue.ImageQualityLevel = value;
        }

        public System.Boolean Lossless
        {
            get => __ProxyValue.Lossless;
            set => __ProxyValue.Lossless = value;
        }

        public System.Windows.Media.Imaging.Rotation Rotation
        {
            get => __ProxyValue.Rotation;
            set => __ProxyValue.Rotation = value;
        }

        public System.Boolean FlipHorizontal
        {
            get => __ProxyValue.FlipHorizontal;
            set => __ProxyValue.FlipHorizontal = value;
        }

        public System.Boolean FlipVertical
        {
            get => __ProxyValue.FlipVertical;
            set => __ProxyValue.FlipVertical = value;
        }

        public System.Boolean UseCodecOptions
        {
            get => __ProxyValue.UseCodecOptions;
            set => __ProxyValue.UseCodecOptions = value;
        }

        public System.Byte QualityLevel
        {
            get => __ProxyValue.QualityLevel;
            set => __ProxyValue.QualityLevel = value;
        }

        public System.Byte SubsamplingLevel
        {
            get => __ProxyValue.SubsamplingLevel;
            set => __ProxyValue.SubsamplingLevel = value;
        }

        public System.Byte OverlapLevel
        {
            get => __ProxyValue.OverlapLevel;
            set => __ProxyValue.OverlapLevel = value;
        }

        public System.Int16 HorizontalTileSlices
        {
            get => __ProxyValue.HorizontalTileSlices;
            set => __ProxyValue.HorizontalTileSlices = value;
        }

        public System.Int16 VerticalTileSlices
        {
            get => __ProxyValue.VerticalTileSlices;
            set => __ProxyValue.VerticalTileSlices = value;
        }

        public System.Boolean FrequencyOrder
        {
            get => __ProxyValue.FrequencyOrder;
            set => __ProxyValue.FrequencyOrder = value;
        }

        public System.Boolean InterleavedAlpha
        {
            get => __ProxyValue.InterleavedAlpha;
            set => __ProxyValue.InterleavedAlpha = value;
        }

        public System.Byte AlphaQualityLevel
        {
            get => __ProxyValue.AlphaQualityLevel;
            set => __ProxyValue.AlphaQualityLevel = value;
        }

        public System.Boolean CompressedDomainTranscode
        {
            get => __ProxyValue.CompressedDomainTranscode;
            set => __ProxyValue.CompressedDomainTranscode = value;
        }

        public System.Byte ImageDataDiscardLevel
        {
            get => __ProxyValue.ImageDataDiscardLevel;
            set => __ProxyValue.ImageDataDiscardLevel = value;
        }

        public System.Byte AlphaDataDiscardLevel
        {
            get => __ProxyValue.AlphaDataDiscardLevel;
            set => __ProxyValue.AlphaDataDiscardLevel = value;
        }

        public System.Boolean IgnoreOverlap
        {
            get => __ProxyValue.IgnoreOverlap;
            set => __ProxyValue.IgnoreOverlap = value;
        }

        public System.Collections.ObjectModel.ReadOnlyCollection<System.Windows.Media.ColorContext> ColorContexts
        {
            get => __ProxyValue.ColorContexts;
            set => __ProxyValue.ColorContexts = value;
        }

        public System.Windows.Media.Imaging.BitmapSource Thumbnail
        {
            get => __ProxyValue.Thumbnail;
            set => __ProxyValue.Thumbnail = value;
        }

        public System.Windows.Media.Imaging.BitmapMetadata Metadata
        {
            get => __ProxyValue.Metadata;
            set => __ProxyValue.Metadata = value;
        }

        public System.Windows.Media.Imaging.BitmapSource Preview
        {
            get => __ProxyValue.Preview;
            set => __ProxyValue.Preview = value;
        }

        public System.Windows.Media.Imaging.BitmapCodecInfo CodecInfo
        {
            get => __ProxyValue.CodecInfo;
        }

        public System.Windows.Media.Imaging.BitmapPalette Palette
        {
            get => __ProxyValue.Palette;
            set => __ProxyValue.Palette = value;
        }

        public System.Collections.Generic.IList<System.Windows.Media.Imaging.BitmapFrame> Frames
        {
            get => __ProxyValue.Frames;
            set => __ProxyValue.Frames = value;
        }

        public System.Windows.Threading.Dispatcher Dispatcher
        {
            get => __ProxyValue.Dispatcher;
        }

        public WmpBitmapEncoder(): base()
        {
        }

        public void Save(System.IO.Stream stream) => __ProxyValue.Save(@stream);
        public System.Boolean CheckAccess() => __ProxyValue.CheckAccess();
        public void VerifyAccess() => __ProxyValue.VerifyAccess();
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}