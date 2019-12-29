namespace System.Windows.Media.Media3D
{
    using Uno.UI.Generic;

    public class OrthographicCamera : Proxy<global::Windows.UI.Xaml.Media.Media3D.OrthographicCamera>
    {
        public System.Double Width
        {
            get => __ProxyValue.Width;
            set => __ProxyValue.Width = value;
        }

        public System.Double NearPlaneDistance
        {
            get => __ProxyValue.NearPlaneDistance;
            set => __ProxyValue.NearPlaneDistance = value;
        }

        public System.Double FarPlaneDistance
        {
            get => __ProxyValue.FarPlaneDistance;
            set => __ProxyValue.FarPlaneDistance = value;
        }

        public System.Windows.Media.Media3D.Point3D Position
        {
            get => __ProxyValue.Position;
            set => __ProxyValue.Position = value;
        }

        public System.Windows.Media.Media3D.Vector3D LookDirection
        {
            get => __ProxyValue.LookDirection;
            set => __ProxyValue.LookDirection = value;
        }

        public System.Windows.Media.Media3D.Vector3D UpDirection
        {
            get => __ProxyValue.UpDirection;
            set => __ProxyValue.UpDirection = value;
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

        public OrthographicCamera(): base()
        {
        }

        public OrthographicCamera(System.Windows.Media.Media3D.Point3D @position, System.Windows.Media.Media3D.Vector3D @lookDirection, System.Windows.Media.Media3D.Vector3D @upDirection, System.Double @width): base(@position, @lookDirection, @upDirection, @width)
        {
        }

        public System.Windows.Media.Media3D.OrthographicCamera Clone() => __ProxyValue.Clone();
        public System.Windows.Media.Media3D.OrthographicCamera CloneCurrentValue() => __ProxyValue.CloneCurrentValue();
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