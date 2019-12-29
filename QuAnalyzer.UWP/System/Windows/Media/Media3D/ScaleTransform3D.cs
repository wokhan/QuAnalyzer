namespace System.Windows.Media.Media3D
{
    using Uno.UI.Generic;

    public class ScaleTransform3D : Proxy<global::Windows.UI.Xaml.Media.Media3D.ScaleTransform3D>
    {
        public System.Windows.Media.Media3D.Matrix3D Value
        {
            get => __ProxyValue.Value;
        }

        public System.Double ScaleX
        {
            get => __ProxyValue.ScaleX;
            set => __ProxyValue.ScaleX = value;
        }

        public System.Double ScaleY
        {
            get => __ProxyValue.ScaleY;
            set => __ProxyValue.ScaleY = value;
        }

        public System.Double ScaleZ
        {
            get => __ProxyValue.ScaleZ;
            set => __ProxyValue.ScaleZ = value;
        }

        public System.Double CenterX
        {
            get => __ProxyValue.CenterX;
            set => __ProxyValue.CenterX = value;
        }

        public System.Double CenterY
        {
            get => __ProxyValue.CenterY;
            set => __ProxyValue.CenterY = value;
        }

        public System.Double CenterZ
        {
            get => __ProxyValue.CenterZ;
            set => __ProxyValue.CenterZ = value;
        }

        public System.Boolean IsAffine
        {
            get => __ProxyValue.IsAffine;
        }

        public System.Windows.Media.Media3D.GeneralTransform3D Inverse
        {
            get => __ProxyValue.Inverse;
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

        public ScaleTransform3D(): base()
        {
        }

        public ScaleTransform3D(System.Windows.Media.Media3D.Vector3D @scale): base(@scale)
        {
        }

        public ScaleTransform3D(System.Double @scaleX, System.Double @scaleY, System.Double @scaleZ): base(@scaleX, @scaleY, @scaleZ)
        {
        }

        public ScaleTransform3D(System.Windows.Media.Media3D.Vector3D @scale, System.Windows.Media.Media3D.Point3D @center): base(@scale, @center)
        {
        }

        public ScaleTransform3D(System.Double @scaleX, System.Double @scaleY, System.Double @scaleZ, System.Double @centerX, System.Double @centerY, System.Double @centerZ): base(@scaleX, @scaleY, @scaleZ, @centerX, @centerY, @centerZ)
        {
        }

        public System.Windows.Media.Media3D.ScaleTransform3D Clone() => __ProxyValue.Clone();
        public System.Windows.Media.Media3D.ScaleTransform3D CloneCurrentValue() => __ProxyValue.CloneCurrentValue();
        public System.Windows.Media.Media3D.Point3D Transform(System.Windows.Media.Media3D.Point3D point) => __ProxyValue.Transform(@point);
        public System.Windows.Media.Media3D.Vector3D Transform(System.Windows.Media.Media3D.Vector3D vector) => __ProxyValue.Transform(@vector);
        public System.Windows.Media.Media3D.Point4D Transform(System.Windows.Media.Media3D.Point4D point) => __ProxyValue.Transform(@point);
        public void Transform(System.Windows.Media.Media3D.Point3D[] points) => __ProxyValue.Transform(@points);
        public void Transform(System.Windows.Media.Media3D.Vector3D[] vectors) => __ProxyValue.Transform(@vectors);
        public void Transform(System.Windows.Media.Media3D.Point4D[] points) => __ProxyValue.Transform(@points);
        public System.Boolean TryTransform(System.Windows.Media.Media3D.Point3D inPoint, out System.Windows.Media.Media3D.Point3D result) => __ProxyValue.TryTransform(@inPoint, @result);
        public System.Windows.Media.Media3D.Rect3D TransformBounds(System.Windows.Media.Media3D.Rect3D rect) => __ProxyValue.TransformBounds(@rect);
        public System.Windows.Media.Media3D.Point3D Transform(System.Windows.Media.Media3D.Point3D point) => __ProxyValue.Transform(@point);
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