namespace System.Windows.Media
{
    using Uno.UI.Generic;

    public class Visual : Proxy<global::Windows.UI.Xaml.Media.Visual>
    {
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

        public System.Boolean IsAncestorOf(System.Windows.DependencyObject descendant) => __ProxyValue.IsAncestorOf(@descendant);
        public System.Boolean IsDescendantOf(System.Windows.DependencyObject ancestor) => __ProxyValue.IsDescendantOf(@ancestor);
        public System.Windows.DependencyObject FindCommonVisualAncestor(System.Windows.DependencyObject otherVisual) => __ProxyValue.FindCommonVisualAncestor(@otherVisual);
        public System.Windows.Media.GeneralTransform TransformToAncestor(System.Windows.Media.Visual ancestor) => __ProxyValue.TransformToAncestor(@ancestor);
        public System.Windows.Media.Media3D.GeneralTransform2DTo3D TransformToAncestor(System.Windows.Media.Media3D.Visual3D ancestor) => __ProxyValue.TransformToAncestor(@ancestor);
        public System.Windows.Media.GeneralTransform TransformToDescendant(System.Windows.Media.Visual descendant) => __ProxyValue.TransformToDescendant(@descendant);
        public System.Windows.Media.GeneralTransform TransformToVisual(System.Windows.Media.Visual visual) => __ProxyValue.TransformToVisual(@visual);
        public System.Windows.Point PointToScreen(System.Windows.Point point) => __ProxyValue.PointToScreen(@point);
        public System.Windows.Point PointFromScreen(System.Windows.Point point) => __ProxyValue.PointFromScreen(@point);
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