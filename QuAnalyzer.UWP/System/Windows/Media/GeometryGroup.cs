namespace System.Windows.Media
{
    using Uno.UI.Generic;

    public class GeometryGroup : Proxy<global::Windows.UI.Xaml.Media.GeometryGroup>
    {
        public System.Windows.Media.FillRule FillRule
        {
            get => __ProxyValue.FillRule;
            set => __ProxyValue.FillRule = value;
        }

        public System.Windows.Media.GeometryCollection Children
        {
            get => __ProxyValue.Children;
            set => __ProxyValue.Children = value;
        }

        public System.Windows.Rect Bounds
        {
            get => __ProxyValue.Bounds;
        }

        public System.Windows.Media.Transform Transform
        {
            get => __ProxyValue.Transform;
            set => __ProxyValue.Transform = value;
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

        public GeometryGroup(): base()
        {
        }

        public System.Boolean IsEmpty() => __ProxyValue.IsEmpty();
        public System.Boolean MayHaveCurves() => __ProxyValue.MayHaveCurves();
        public System.Windows.Media.GeometryGroup Clone() => __ProxyValue.Clone();
        public System.Windows.Media.GeometryGroup CloneCurrentValue() => __ProxyValue.CloneCurrentValue();
        public System.Windows.Rect GetRenderBounds(System.Windows.Media.Pen pen, System.Double tolerance, System.Windows.Media.ToleranceType type) => __ProxyValue.GetRenderBounds(@pen, @tolerance, @type);
        public System.Windows.Rect GetRenderBounds(System.Windows.Media.Pen pen) => __ProxyValue.GetRenderBounds(@pen);
        public System.Boolean ShouldSerializeTransform() => __ProxyValue.ShouldSerializeTransform();
        public System.Double GetArea(System.Double tolerance, System.Windows.Media.ToleranceType type) => __ProxyValue.GetArea(@tolerance, @type);
        public System.Double GetArea() => __ProxyValue.GetArea();
        public System.Boolean FillContains(System.Windows.Point hitPoint, System.Double tolerance, System.Windows.Media.ToleranceType type) => __ProxyValue.FillContains(@hitPoint, @tolerance, @type);
        public System.Boolean FillContains(System.Windows.Point hitPoint) => __ProxyValue.FillContains(@hitPoint);
        public System.Boolean StrokeContains(System.Windows.Media.Pen pen, System.Windows.Point hitPoint, System.Double tolerance, System.Windows.Media.ToleranceType type) => __ProxyValue.StrokeContains(@pen, @hitPoint, @tolerance, @type);
        public System.Boolean StrokeContains(System.Windows.Media.Pen pen, System.Windows.Point hitPoint) => __ProxyValue.StrokeContains(@pen, @hitPoint);
        public System.Boolean FillContains(System.Windows.Media.Geometry geometry, System.Double tolerance, System.Windows.Media.ToleranceType type) => __ProxyValue.FillContains(@geometry, @tolerance, @type);
        public System.Boolean FillContains(System.Windows.Media.Geometry geometry) => __ProxyValue.FillContains(@geometry);
        public System.Windows.Media.IntersectionDetail FillContainsWithDetail(System.Windows.Media.Geometry geometry, System.Double tolerance, System.Windows.Media.ToleranceType type) => __ProxyValue.FillContainsWithDetail(@geometry, @tolerance, @type);
        public System.Windows.Media.IntersectionDetail FillContainsWithDetail(System.Windows.Media.Geometry geometry) => __ProxyValue.FillContainsWithDetail(@geometry);
        public System.Windows.Media.IntersectionDetail StrokeContainsWithDetail(System.Windows.Media.Pen pen, System.Windows.Media.Geometry geometry, System.Double tolerance, System.Windows.Media.ToleranceType type) => __ProxyValue.StrokeContainsWithDetail(@pen, @geometry, @tolerance, @type);
        public System.Windows.Media.IntersectionDetail StrokeContainsWithDetail(System.Windows.Media.Pen pen, System.Windows.Media.Geometry geometry) => __ProxyValue.StrokeContainsWithDetail(@pen, @geometry);
        public System.Windows.Media.PathGeometry GetFlattenedPathGeometry(System.Double tolerance, System.Windows.Media.ToleranceType type) => __ProxyValue.GetFlattenedPathGeometry(@tolerance, @type);
        public System.Windows.Media.PathGeometry GetFlattenedPathGeometry() => __ProxyValue.GetFlattenedPathGeometry();
        public System.Windows.Media.PathGeometry GetWidenedPathGeometry(System.Windows.Media.Pen pen, System.Double tolerance, System.Windows.Media.ToleranceType type) => __ProxyValue.GetWidenedPathGeometry(@pen, @tolerance, @type);
        public System.Windows.Media.PathGeometry GetWidenedPathGeometry(System.Windows.Media.Pen pen) => __ProxyValue.GetWidenedPathGeometry(@pen);
        public System.Windows.Media.PathGeometry GetOutlinedPathGeometry(System.Double tolerance, System.Windows.Media.ToleranceType type) => __ProxyValue.GetOutlinedPathGeometry(@tolerance, @type);
        public System.Windows.Media.PathGeometry GetOutlinedPathGeometry() => __ProxyValue.GetOutlinedPathGeometry();
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