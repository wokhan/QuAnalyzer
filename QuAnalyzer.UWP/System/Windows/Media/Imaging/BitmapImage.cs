namespace System.Windows.Media.Imaging
{
    using Uno.UI.Generic;

    public class BitmapImage : Proxy<global::Windows.UI.Xaml.Media.Imaging.BitmapImage>
    {
        public System.Uri BaseUri
        {
            get => __ProxyValue.BaseUri;
            set => __ProxyValue.BaseUri = value;
        }

        public System.Boolean IsDownloading
        {
            get => __ProxyValue.IsDownloading;
        }

        public System.Windows.Media.ImageMetadata Metadata
        {
            get => __ProxyValue.Metadata;
        }

        public System.Net.Cache.RequestCachePolicy UriCachePolicy
        {
            get => __ProxyValue.UriCachePolicy;
            set => __ProxyValue.UriCachePolicy = value;
        }

        public System.Uri UriSource
        {
            get => __ProxyValue.UriSource;
            set => __ProxyValue.UriSource = value;
        }

        public System.IO.Stream StreamSource
        {
            get => __ProxyValue.StreamSource;
            set => __ProxyValue.StreamSource = value;
        }

        public System.Int32 DecodePixelWidth
        {
            get => __ProxyValue.DecodePixelWidth;
            set => __ProxyValue.DecodePixelWidth = value;
        }

        public System.Int32 DecodePixelHeight
        {
            get => __ProxyValue.DecodePixelHeight;
            set => __ProxyValue.DecodePixelHeight = value;
        }

        public System.Windows.Media.Imaging.Rotation Rotation
        {
            get => __ProxyValue.Rotation;
            set => __ProxyValue.Rotation = value;
        }

        public System.Windows.Int32Rect SourceRect
        {
            get => __ProxyValue.SourceRect;
            set => __ProxyValue.SourceRect = value;
        }

        public System.Windows.Media.Imaging.BitmapCreateOptions CreateOptions
        {
            get => __ProxyValue.CreateOptions;
            set => __ProxyValue.CreateOptions = value;
        }

        public System.Windows.Media.Imaging.BitmapCacheOption CacheOption
        {
            get => __ProxyValue.CacheOption;
            set => __ProxyValue.CacheOption = value;
        }

        public System.Windows.Media.PixelFormat Format
        {
            get => __ProxyValue.Format;
        }

        public System.Int32 PixelWidth
        {
            get => __ProxyValue.PixelWidth;
        }

        public System.Int32 PixelHeight
        {
            get => __ProxyValue.PixelHeight;
        }

        public System.Double DpiX
        {
            get => __ProxyValue.DpiX;
        }

        public System.Double DpiY
        {
            get => __ProxyValue.DpiY;
        }

        public System.Windows.Media.Imaging.BitmapPalette Palette
        {
            get => __ProxyValue.Palette;
        }

        public System.Double Width
        {
            get => __ProxyValue.Width;
        }

        public System.Double Height
        {
            get => __ProxyValue.Height;
        }

        public System.Boolean HasAnimatedProperties
        {
            get => __ProxyValue.HasAnimatedProperties;
        }

        public System.Boolean CanFreeze
        {
            get => __ProxyValue.CanFreeze;
        }

        public System.Boolean IsFrozen
        {
            get => __ProxyValue.IsFrozen;
        }

        public System.Windows.DependencyObjectType DependencyObjectType
        {
            get => __ProxyValue.DependencyObjectType;
        }

        public System.Boolean IsSealed
        {
            get => __ProxyValue.IsSealed;
        }

        public System.Windows.Threading.Dispatcher Dispatcher
        {
            get => __ProxyValue.Dispatcher;
        }

        public BitmapImage(): base()
        {
        }

        public BitmapImage(System.Uri @uriSource): base(@uriSource)
        {
        }

        public BitmapImage(System.Uri @uriSource, System.Net.Cache.RequestCachePolicy @uriCachePolicy): base(@uriSource, @uriCachePolicy)
        {
        }

        public void BeginInit() => __ProxyValue.BeginInit();
        public void EndInit() => __ProxyValue.EndInit();
        public System.Windows.Media.Imaging.BitmapImage Clone() => __ProxyValue.Clone();
        public System.Windows.Media.Imaging.BitmapImage CloneCurrentValue() => __ProxyValue.CloneCurrentValue();
        public void add_DownloadCompleted(System.EventHandler value) => __ProxyValue.add_DownloadCompleted(@value);
        public void remove_DownloadCompleted(System.EventHandler value) => __ProxyValue.remove_DownloadCompleted(@value);
        public void add_DownloadProgress(System.EventHandler<System.Windows.Media.Imaging.DownloadProgressEventArgs> value) => __ProxyValue.add_DownloadProgress(@value);
        public void remove_DownloadProgress(System.EventHandler<System.Windows.Media.Imaging.DownloadProgressEventArgs> value) => __ProxyValue.remove_DownloadProgress(@value);
        public void add_DownloadFailed(System.EventHandler<System.Windows.Media.ExceptionEventArgs> value) => __ProxyValue.add_DownloadFailed(@value);
        public void remove_DownloadFailed(System.EventHandler<System.Windows.Media.ExceptionEventArgs> value) => __ProxyValue.remove_DownloadFailed(@value);
        public void add_DecodeFailed(System.EventHandler<System.Windows.Media.ExceptionEventArgs> value) => __ProxyValue.add_DecodeFailed(@value);
        public void remove_DecodeFailed(System.EventHandler<System.Windows.Media.ExceptionEventArgs> value) => __ProxyValue.remove_DecodeFailed(@value);
        public void CopyPixels(System.Windows.Int32Rect sourceRect, System.Array pixels, System.Int32 stride, System.Int32 offset) => __ProxyValue.CopyPixels(@sourceRect, @pixels, @stride, @offset);
        public void CopyPixels(System.Array pixels, System.Int32 stride, System.Int32 offset) => __ProxyValue.CopyPixels(@pixels, @stride, @offset);
        public void CopyPixels(System.Windows.Int32Rect sourceRect, System.IntPtr buffer, System.Int32 bufferSize, System.Int32 stride) => __ProxyValue.CopyPixels(@sourceRect, @buffer, @bufferSize, @stride);
        public override System.String ToString() => __ProxyValue.ToString();
        public System.String ToString(System.IFormatProvider provider) => __ProxyValue.ToString(@provider);
        public void ApplyAnimationClock(System.Windows.DependencyProperty dp, System.Windows.Media.Animation.AnimationClock clock) => __ProxyValue.ApplyAnimationClock(@dp, @clock);
        public void ApplyAnimationClock(System.Windows.DependencyProperty dp, System.Windows.Media.Animation.AnimationClock clock, System.Windows.Media.Animation.HandoffBehavior handoffBehavior) => __ProxyValue.ApplyAnimationClock(@dp, @clock, @handoffBehavior);
        public void BeginAnimation(System.Windows.DependencyProperty dp, System.Windows.Media.Animation.AnimationTimeline animation) => __ProxyValue.BeginAnimation(@dp, @animation);
        public void BeginAnimation(System.Windows.DependencyProperty dp, System.Windows.Media.Animation.AnimationTimeline animation, System.Windows.Media.Animation.HandoffBehavior handoffBehavior) => __ProxyValue.BeginAnimation(@dp, @animation, @handoffBehavior);
        public System.Object GetAnimationBaseValue(System.Windows.DependencyProperty dp) => __ProxyValue.GetAnimationBaseValue(@dp);
        public System.Windows.Freezable GetAsFrozen() => __ProxyValue.GetAsFrozen();
        public System.Windows.Freezable GetCurrentValueAsFrozen() => __ProxyValue.GetCurrentValueAsFrozen();
        public void Freeze() => __ProxyValue.Freeze();
        public void add_Changed(System.EventHandler value) => __ProxyValue.add_Changed(@value);
        public void remove_Changed(System.EventHandler value) => __ProxyValue.remove_Changed(@value);
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
        public System.Object GetValue(System.Windows.DependencyProperty dp) => __ProxyValue.GetValue(@dp);
        public void SetValue(System.Windows.DependencyProperty dp, System.Object value) => __ProxyValue.SetValue(@dp, @value);
        public void SetCurrentValue(System.Windows.DependencyProperty dp, System.Object value) => __ProxyValue.SetCurrentValue(@dp, @value);
        public void SetValue(System.Windows.DependencyPropertyKey key, System.Object value) => __ProxyValue.SetValue(@key, @value);
        public void ClearValue(System.Windows.DependencyProperty dp) => __ProxyValue.ClearValue(@dp);
        public void ClearValue(System.Windows.DependencyPropertyKey key) => __ProxyValue.ClearValue(@key);
        public void CoerceValue(System.Windows.DependencyProperty dp) => __ProxyValue.CoerceValue(@dp);
        public void InvalidateProperty(System.Windows.DependencyProperty dp) => __ProxyValue.InvalidateProperty(@dp);
        public System.Object ReadLocalValue(System.Windows.DependencyProperty dp) => __ProxyValue.ReadLocalValue(@dp);
        public System.Windows.LocalValueEnumerator GetLocalValueEnumerator() => __ProxyValue.GetLocalValueEnumerator();
        public System.Boolean CheckAccess() => __ProxyValue.CheckAccess();
        public void VerifyAccess() => __ProxyValue.VerifyAccess();
    }
}