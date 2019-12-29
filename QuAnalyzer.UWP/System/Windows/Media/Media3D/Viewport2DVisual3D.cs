namespace System.Windows.Media.Media3D
{
    using Uno.UI.Generic;

    public class Viewport2DVisual3D : Proxy<global::Windows.UI.Xaml.Media.Media3D.Viewport2DVisual3D>
    {
        public System.Windows.Media.Visual Visual
        {
            get => __ProxyValue.Visual;
            set => __ProxyValue.Visual = value;
        }

        public System.Windows.Media.Media3D.Geometry3D Geometry
        {
            get => __ProxyValue.Geometry;
            set => __ProxyValue.Geometry = value;
        }

        public System.Windows.Media.Media3D.Material Material
        {
            get => __ProxyValue.Material;
            set => __ProxyValue.Material = value;
        }

        public System.Windows.Media.CacheMode CacheMode
        {
            get => __ProxyValue.CacheMode;
            set => __ProxyValue.CacheMode = value;
        }

        public System.Windows.Media.Media3D.Transform3D Transform
        {
            get => __ProxyValue.Transform;
            set => __ProxyValue.Transform = value;
        }

        public System.Boolean HasAnimatedProperties
        {
            get => __ProxyValue.HasAnimatedProperties;
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

        public Viewport2DVisual3D(): base()
        {
        }

        public static void SetIsVisualHostMaterial(System.Windows.Media.Media3D.Material element, System.Boolean value) => Windows.UI.Xaml.Media.Media3D.Viewport2DVisual3D.SetIsVisualHostMaterial(@element, @value);
        public static System.Boolean GetIsVisualHostMaterial(System.Windows.Media.Media3D.Material element) => Windows.UI.Xaml.Media.Media3D.Viewport2DVisual3D.GetIsVisualHostMaterial(@element);
        public void ApplyAnimationClock(System.Windows.DependencyProperty dp, System.Windows.Media.Animation.AnimationClock clock) => __ProxyValue.ApplyAnimationClock(@dp, @clock);
        public void ApplyAnimationClock(System.Windows.DependencyProperty dp, System.Windows.Media.Animation.AnimationClock clock, System.Windows.Media.Animation.HandoffBehavior handoffBehavior) => __ProxyValue.ApplyAnimationClock(@dp, @clock, @handoffBehavior);
        public void BeginAnimation(System.Windows.DependencyProperty dp, System.Windows.Media.Animation.AnimationTimeline animation) => __ProxyValue.BeginAnimation(@dp, @animation);
        public void BeginAnimation(System.Windows.DependencyProperty dp, System.Windows.Media.Animation.AnimationTimeline animation, System.Windows.Media.Animation.HandoffBehavior handoffBehavior) => __ProxyValue.BeginAnimation(@dp, @animation, @handoffBehavior);
        public System.Object GetAnimationBaseValue(System.Windows.DependencyProperty dp) => __ProxyValue.GetAnimationBaseValue(@dp);
        public System.Boolean IsAncestorOf(System.Windows.DependencyObject descendant) => __ProxyValue.IsAncestorOf(@descendant);
        public System.Boolean IsDescendantOf(System.Windows.DependencyObject ancestor) => __ProxyValue.IsDescendantOf(@ancestor);
        public System.Windows.DependencyObject FindCommonVisualAncestor(System.Windows.DependencyObject otherVisual) => __ProxyValue.FindCommonVisualAncestor(@otherVisual);
        public System.Windows.Media.Media3D.GeneralTransform3D TransformToAncestor(System.Windows.Media.Media3D.Visual3D ancestor) => __ProxyValue.TransformToAncestor(@ancestor);
        public System.Windows.Media.Media3D.GeneralTransform3D TransformToDescendant(System.Windows.Media.Media3D.Visual3D descendant) => __ProxyValue.TransformToDescendant(@descendant);
        public System.Windows.Media.Media3D.GeneralTransform3DTo2D TransformToAncestor(System.Windows.Media.Visual ancestor) => __ProxyValue.TransformToAncestor(@ancestor);
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
        public override System.String ToString() => __ProxyValue.ToString();
    }
}