﻿namespace System.Windows.Media.Media3D
{
    using Uno.UI.Generic;

    public class PointLightBase : Proxy<global::Windows.UI.Xaml.Media.Media3D.PointLightBase>
    {
        public System.Windows.Media.Media3D.Point3D Position
        {
            get => __ProxyValue.Position;
            set => __ProxyValue.Position = value;
        }

        public System.Double Range
        {
            get => __ProxyValue.Range;
            set => __ProxyValue.Range = value;
        }

        public System.Double ConstantAttenuation
        {
            get => __ProxyValue.ConstantAttenuation;
            set => __ProxyValue.ConstantAttenuation = value;
        }

        public System.Double LinearAttenuation
        {
            get => __ProxyValue.LinearAttenuation;
            set => __ProxyValue.LinearAttenuation = value;
        }

        public System.Double QuadraticAttenuation
        {
            get => __ProxyValue.QuadraticAttenuation;
            set => __ProxyValue.QuadraticAttenuation = value;
        }

        public System.Windows.Media.Color Color
        {
            get => __ProxyValue.Color;
            set => __ProxyValue.Color = value;
        }

        public System.Windows.Media.Media3D.Rect3D Bounds
        {
            get => __ProxyValue.Bounds;
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

        public System.Windows.Media.Media3D.PointLightBase Clone() => __ProxyValue.Clone();
        public System.Windows.Media.Media3D.PointLightBase CloneCurrentValue() => __ProxyValue.CloneCurrentValue();
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