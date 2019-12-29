namespace System.Windows.Media
{
    using Uno.UI.Generic;

    public class VisualTreeHelper : Proxy<global::Windows.UI.Xaml.Media.VisualTreeHelper>
    {
        public static System.Int32 GetChildrenCount(System.Windows.DependencyObject reference) => Windows.UI.Xaml.Media.VisualTreeHelper.GetChildrenCount(@reference);
        public static System.Windows.DependencyObject GetChild(System.Windows.DependencyObject reference, System.Int32 childIndex) => Windows.UI.Xaml.Media.VisualTreeHelper.GetChild(@reference, @childIndex);
        public static System.Windows.DpiScale GetDpi(System.Windows.Media.Visual visual) => Windows.UI.Xaml.Media.VisualTreeHelper.GetDpi(@visual);
        public static void SetRootDpi(System.Windows.Media.Visual visual, System.Windows.DpiScale dpiInfo) => Windows.UI.Xaml.Media.VisualTreeHelper.SetRootDpi(@visual, @dpiInfo);
        public static System.Windows.DependencyObject GetParent(System.Windows.DependencyObject reference) => Windows.UI.Xaml.Media.VisualTreeHelper.GetParent(@reference);
        public static System.Windows.Media.Geometry GetClip(System.Windows.Media.Visual reference) => Windows.UI.Xaml.Media.VisualTreeHelper.GetClip(@reference);
        public static System.Double GetOpacity(System.Windows.Media.Visual reference) => Windows.UI.Xaml.Media.VisualTreeHelper.GetOpacity(@reference);
        public static System.Windows.Media.Brush GetOpacityMask(System.Windows.Media.Visual reference) => Windows.UI.Xaml.Media.VisualTreeHelper.GetOpacityMask(@reference);
        public static System.Windows.Vector GetOffset(System.Windows.Media.Visual reference) => Windows.UI.Xaml.Media.VisualTreeHelper.GetOffset(@reference);
        public static System.Windows.Media.Transform GetTransform(System.Windows.Media.Visual reference) => Windows.UI.Xaml.Media.VisualTreeHelper.GetTransform(@reference);
        public static System.Windows.Media.DoubleCollection GetXSnappingGuidelines(System.Windows.Media.Visual reference) => Windows.UI.Xaml.Media.VisualTreeHelper.GetXSnappingGuidelines(@reference);
        public static System.Windows.Media.DoubleCollection GetYSnappingGuidelines(System.Windows.Media.Visual reference) => Windows.UI.Xaml.Media.VisualTreeHelper.GetYSnappingGuidelines(@reference);
        public static System.Windows.Media.DrawingGroup GetDrawing(System.Windows.Media.Visual reference) => Windows.UI.Xaml.Media.VisualTreeHelper.GetDrawing(@reference);
        public static System.Windows.Rect GetContentBounds(System.Windows.Media.Visual reference) => Windows.UI.Xaml.Media.VisualTreeHelper.GetContentBounds(@reference);
        public static System.Windows.Media.Media3D.Rect3D GetContentBounds(System.Windows.Media.Media3D.Visual3D reference) => Windows.UI.Xaml.Media.VisualTreeHelper.GetContentBounds(@reference);
        public static System.Windows.Rect GetDescendantBounds(System.Windows.Media.Visual reference) => Windows.UI.Xaml.Media.VisualTreeHelper.GetDescendantBounds(@reference);
        public static System.Windows.Media.Media3D.Rect3D GetDescendantBounds(System.Windows.Media.Media3D.Visual3D reference) => Windows.UI.Xaml.Media.VisualTreeHelper.GetDescendantBounds(@reference);
        public static System.Windows.Media.Effects.BitmapEffect GetBitmapEffect(System.Windows.Media.Visual reference) => Windows.UI.Xaml.Media.VisualTreeHelper.GetBitmapEffect(@reference);
        public static System.Windows.Media.Effects.BitmapEffectInput GetBitmapEffectInput(System.Windows.Media.Visual reference) => Windows.UI.Xaml.Media.VisualTreeHelper.GetBitmapEffectInput(@reference);
        public static System.Windows.Media.Effects.Effect GetEffect(System.Windows.Media.Visual reference) => Windows.UI.Xaml.Media.VisualTreeHelper.GetEffect(@reference);
        public static System.Windows.Media.CacheMode GetCacheMode(System.Windows.Media.Visual reference) => Windows.UI.Xaml.Media.VisualTreeHelper.GetCacheMode(@reference);
        public static System.Windows.Media.EdgeMode GetEdgeMode(System.Windows.Media.Visual reference) => Windows.UI.Xaml.Media.VisualTreeHelper.GetEdgeMode(@reference);
        public static System.Windows.Media.HitTestResult HitTest(System.Windows.Media.Visual reference, System.Windows.Point point) => Windows.UI.Xaml.Media.VisualTreeHelper.HitTest(@reference, @point);
        public static void HitTest(System.Windows.Media.Visual reference, System.Windows.Media.HitTestFilterCallback filterCallback, System.Windows.Media.HitTestResultCallback resultCallback, System.Windows.Media.HitTestParameters hitTestParameters) => Windows.UI.Xaml.Media.VisualTreeHelper.HitTest(@reference, @filterCallback, @resultCallback, @hitTestParameters);
        public static void HitTest(System.Windows.Media.Media3D.Visual3D reference, System.Windows.Media.HitTestFilterCallback filterCallback, System.Windows.Media.HitTestResultCallback resultCallback, System.Windows.Media.Media3D.HitTestParameters3D hitTestParameters) => Windows.UI.Xaml.Media.VisualTreeHelper.HitTest(@reference, @filterCallback, @resultCallback, @hitTestParameters);
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}