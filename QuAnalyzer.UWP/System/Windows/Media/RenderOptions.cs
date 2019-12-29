namespace System.Windows.Media
{
    using Uno.UI.Generic;

    public class RenderOptions : Proxy<global::Windows.UI.Xaml.Media.RenderOptions>
    {
        public static System.Windows.Interop.RenderMode ProcessRenderMode
        {
            get => __ProxyValue.ProcessRenderMode;
            set => __ProxyValue.ProcessRenderMode = value;
        }

        public static System.Windows.Media.EdgeMode GetEdgeMode(System.Windows.DependencyObject target) => Windows.UI.Xaml.Media.RenderOptions.GetEdgeMode(@target);
        public static void SetEdgeMode(System.Windows.DependencyObject target, System.Windows.Media.EdgeMode edgeMode) => Windows.UI.Xaml.Media.RenderOptions.SetEdgeMode(@target, @edgeMode);
        public static System.Windows.Media.BitmapScalingMode GetBitmapScalingMode(System.Windows.DependencyObject target) => Windows.UI.Xaml.Media.RenderOptions.GetBitmapScalingMode(@target);
        public static void SetBitmapScalingMode(System.Windows.DependencyObject target, System.Windows.Media.BitmapScalingMode bitmapScalingMode) => Windows.UI.Xaml.Media.RenderOptions.SetBitmapScalingMode(@target, @bitmapScalingMode);
        public static System.Windows.Media.ClearTypeHint GetClearTypeHint(System.Windows.DependencyObject target) => Windows.UI.Xaml.Media.RenderOptions.GetClearTypeHint(@target);
        public static void SetClearTypeHint(System.Windows.DependencyObject target, System.Windows.Media.ClearTypeHint clearTypeHint) => Windows.UI.Xaml.Media.RenderOptions.SetClearTypeHint(@target, @clearTypeHint);
        public static System.Windows.Media.CachingHint GetCachingHint(System.Windows.DependencyObject target) => Windows.UI.Xaml.Media.RenderOptions.GetCachingHint(@target);
        public static void SetCachingHint(System.Windows.DependencyObject target, System.Windows.Media.CachingHint cachingHint) => Windows.UI.Xaml.Media.RenderOptions.SetCachingHint(@target, @cachingHint);
        public static System.Double GetCacheInvalidationThresholdMinimum(System.Windows.DependencyObject target) => Windows.UI.Xaml.Media.RenderOptions.GetCacheInvalidationThresholdMinimum(@target);
        public static void SetCacheInvalidationThresholdMinimum(System.Windows.DependencyObject target, System.Double cacheInvalidationThresholdMinimum) => Windows.UI.Xaml.Media.RenderOptions.SetCacheInvalidationThresholdMinimum(@target, @cacheInvalidationThresholdMinimum);
        public static System.Double GetCacheInvalidationThresholdMaximum(System.Windows.DependencyObject target) => Windows.UI.Xaml.Media.RenderOptions.GetCacheInvalidationThresholdMaximum(@target);
        public static void SetCacheInvalidationThresholdMaximum(System.Windows.DependencyObject target, System.Double cacheInvalidationThresholdMaximum) => Windows.UI.Xaml.Media.RenderOptions.SetCacheInvalidationThresholdMaximum(@target, @cacheInvalidationThresholdMaximum);
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}