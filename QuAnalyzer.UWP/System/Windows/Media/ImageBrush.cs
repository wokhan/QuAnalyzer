﻿namespace System.Windows.Media
{
    using Uno.UI.Generic;

    public class ImageBrush : Proxy<global::Windows.UI.Xaml.Media.ImageBrush>
    {
        public System.Windows.Media.ImageSource ImageSource
        {
            get => __ProxyValue.ImageSource;
            set => __ProxyValue.ImageSource = value;
        }

        public System.Windows.Media.BrushMappingMode ViewportUnits
        {
            get => __ProxyValue.ViewportUnits;
            set => __ProxyValue.ViewportUnits = value;
        }

        public System.Windows.Media.BrushMappingMode ViewboxUnits
        {
            get => __ProxyValue.ViewboxUnits;
            set => __ProxyValue.ViewboxUnits = value;
        }

        public System.Windows.Rect Viewport
        {
            get => __ProxyValue.Viewport;
            set => __ProxyValue.Viewport = value;
        }

        public System.Windows.Rect Viewbox
        {
            get => __ProxyValue.Viewbox;
            set => __ProxyValue.Viewbox = value;
        }

        public System.Windows.Media.Stretch Stretch
        {
            get => __ProxyValue.Stretch;
            set => __ProxyValue.Stretch = value;
        }

        public System.Windows.Media.TileMode TileMode
        {
            get => __ProxyValue.TileMode;
            set => __ProxyValue.TileMode = value;
        }

        public System.Windows.Media.AlignmentX AlignmentX
        {
            get => __ProxyValue.AlignmentX;
            set => __ProxyValue.AlignmentX = value;
        }

        public System.Windows.Media.AlignmentY AlignmentY
        {
            get => __ProxyValue.AlignmentY;
            set => __ProxyValue.AlignmentY = value;
        }

        public System.Double Opacity
        {
            get => __ProxyValue.Opacity;
            set => __ProxyValue.Opacity = value;
        }

        public System.Windows.Media.Transform Transform
        {
            get => __ProxyValue.Transform;
            set => __ProxyValue.Transform = value;
        }

        public System.Windows.Media.Transform RelativeTransform
        {
            get => __ProxyValue.RelativeTransform;
            set => __ProxyValue.RelativeTransform = value;
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

        public ImageBrush(): base()
        {
        }

        public ImageBrush(System.Windows.Media.ImageSource @image): base(@image)
        {
        }

        public System.Windows.Media.ImageBrush Clone() => __ProxyValue.Clone();
        public System.Windows.Media.ImageBrush CloneCurrentValue() => __ProxyValue.CloneCurrentValue();
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