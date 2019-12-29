namespace System.Windows.Media.Imaging
{
    using Uno.UI.Generic;

    public class BitmapDecoder : Proxy<global::Windows.UI.Xaml.Media.Imaging.BitmapDecoder>
    {
        public System.Windows.Media.Imaging.BitmapPalette Palette
        {
            get => __ProxyValue.Palette;
        }

        public System.Collections.ObjectModel.ReadOnlyCollection<System.Windows.Media.ColorContext> ColorContexts
        {
            get => __ProxyValue.ColorContexts;
        }

        public System.Windows.Media.Imaging.BitmapSource Thumbnail
        {
            get => __ProxyValue.Thumbnail;
        }

        public System.Windows.Media.Imaging.BitmapMetadata Metadata
        {
            get => __ProxyValue.Metadata;
        }

        public System.Windows.Media.Imaging.BitmapCodecInfo CodecInfo
        {
            get => __ProxyValue.CodecInfo;
        }

        public System.Collections.ObjectModel.ReadOnlyCollection<System.Windows.Media.Imaging.BitmapFrame> Frames
        {
            get => __ProxyValue.Frames;
        }

        public System.Windows.Media.Imaging.BitmapSource Preview
        {
            get => __ProxyValue.Preview;
        }

        public System.Boolean IsDownloading
        {
            get => __ProxyValue.IsDownloading;
        }

        public System.Windows.Threading.Dispatcher Dispatcher
        {
            get => __ProxyValue.Dispatcher;
        }

        public static System.Windows.Media.Imaging.BitmapDecoder Create(System.Uri bitmapUri, System.Windows.Media.Imaging.BitmapCreateOptions createOptions, System.Windows.Media.Imaging.BitmapCacheOption cacheOption) => Windows.UI.Xaml.Media.Imaging.BitmapDecoder.Create(@bitmapUri, @createOptions, @cacheOption);
        public static System.Windows.Media.Imaging.BitmapDecoder Create(System.Uri bitmapUri, System.Windows.Media.Imaging.BitmapCreateOptions createOptions, System.Windows.Media.Imaging.BitmapCacheOption cacheOption, System.Net.Cache.RequestCachePolicy uriCachePolicy) => Windows.UI.Xaml.Media.Imaging.BitmapDecoder.Create(@bitmapUri, @createOptions, @cacheOption, @uriCachePolicy);
        public static System.Windows.Media.Imaging.BitmapDecoder Create(System.IO.Stream bitmapStream, System.Windows.Media.Imaging.BitmapCreateOptions createOptions, System.Windows.Media.Imaging.BitmapCacheOption cacheOption) => Windows.UI.Xaml.Media.Imaging.BitmapDecoder.Create(@bitmapStream, @createOptions, @cacheOption);
        public void add_DownloadCompleted(System.EventHandler value) => __ProxyValue.add_DownloadCompleted(@value);
        public void remove_DownloadCompleted(System.EventHandler value) => __ProxyValue.remove_DownloadCompleted(@value);
        public void add_DownloadProgress(System.EventHandler<System.Windows.Media.Imaging.DownloadProgressEventArgs> value) => __ProxyValue.add_DownloadProgress(@value);
        public void remove_DownloadProgress(System.EventHandler<System.Windows.Media.Imaging.DownloadProgressEventArgs> value) => __ProxyValue.remove_DownloadProgress(@value);
        public void add_DownloadFailed(System.EventHandler<System.Windows.Media.ExceptionEventArgs> value) => __ProxyValue.add_DownloadFailed(@value);
        public void remove_DownloadFailed(System.EventHandler<System.Windows.Media.ExceptionEventArgs> value) => __ProxyValue.remove_DownloadFailed(@value);
        public System.Windows.Media.Imaging.InPlaceBitmapMetadataWriter CreateInPlaceBitmapMetadataWriter() => __ProxyValue.CreateInPlaceBitmapMetadataWriter();
        public override System.String ToString() => __ProxyValue.ToString();
        public System.Boolean CheckAccess() => __ProxyValue.CheckAccess();
        public void VerifyAccess() => __ProxyValue.VerifyAccess();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}