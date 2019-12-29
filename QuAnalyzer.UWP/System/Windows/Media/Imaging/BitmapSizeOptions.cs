namespace System.Windows.Media.Imaging
{
    using Uno.UI.Generic;

    public class BitmapSizeOptions : Proxy<global::Windows.UI.Xaml.Media.Imaging.BitmapSizeOptions>
    {
        public System.Boolean PreservesAspectRatio
        {
            get => __ProxyValue.PreservesAspectRatio;
        }

        public System.Int32 PixelWidth
        {
            get => __ProxyValue.PixelWidth;
        }

        public System.Int32 PixelHeight
        {
            get => __ProxyValue.PixelHeight;
        }

        public System.Windows.Media.Imaging.Rotation Rotation
        {
            get => __ProxyValue.Rotation;
        }

        public static System.Windows.Media.Imaging.BitmapSizeOptions FromEmptyOptions() => Windows.UI.Xaml.Media.Imaging.BitmapSizeOptions.FromEmptyOptions();
        public static System.Windows.Media.Imaging.BitmapSizeOptions FromHeight(System.Int32 pixelHeight) => Windows.UI.Xaml.Media.Imaging.BitmapSizeOptions.FromHeight(@pixelHeight);
        public static System.Windows.Media.Imaging.BitmapSizeOptions FromWidth(System.Int32 pixelWidth) => Windows.UI.Xaml.Media.Imaging.BitmapSizeOptions.FromWidth(@pixelWidth);
        public static System.Windows.Media.Imaging.BitmapSizeOptions FromWidthAndHeight(System.Int32 pixelWidth, System.Int32 pixelHeight) => Windows.UI.Xaml.Media.Imaging.BitmapSizeOptions.FromWidthAndHeight(@pixelWidth, @pixelHeight);
        public static System.Windows.Media.Imaging.BitmapSizeOptions FromRotation(System.Windows.Media.Imaging.Rotation rotation) => Windows.UI.Xaml.Media.Imaging.BitmapSizeOptions.FromRotation(@rotation);
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}