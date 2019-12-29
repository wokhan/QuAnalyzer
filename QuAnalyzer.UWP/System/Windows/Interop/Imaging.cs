namespace System.Windows.Interop
{
    using Uno.UI.Generic;

    public class Imaging : Proxy<global::Windows.UI.Xaml.Interop.Imaging>
    {
        public static System.Windows.Media.Imaging.BitmapSource CreateBitmapSourceFromHBitmap(System.IntPtr bitmap, System.IntPtr palette, System.Windows.Int32Rect sourceRect, System.Windows.Media.Imaging.BitmapSizeOptions sizeOptions) => Windows.UI.Xaml.Interop.Imaging.CreateBitmapSourceFromHBitmap(@bitmap, @palette, @sourceRect, @sizeOptions);
        public static System.Windows.Media.Imaging.BitmapSource CreateBitmapSourceFromHIcon(System.IntPtr icon, System.Windows.Int32Rect sourceRect, System.Windows.Media.Imaging.BitmapSizeOptions sizeOptions) => Windows.UI.Xaml.Interop.Imaging.CreateBitmapSourceFromHIcon(@icon, @sourceRect, @sizeOptions);
        public static System.Windows.Media.Imaging.BitmapSource CreateBitmapSourceFromMemorySection(System.IntPtr section, System.Int32 pixelWidth, System.Int32 pixelHeight, System.Windows.Media.PixelFormat format, System.Int32 stride, System.Int32 offset) => Windows.UI.Xaml.Interop.Imaging.CreateBitmapSourceFromMemorySection(@section, @pixelWidth, @pixelHeight, @format, @stride, @offset);
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}