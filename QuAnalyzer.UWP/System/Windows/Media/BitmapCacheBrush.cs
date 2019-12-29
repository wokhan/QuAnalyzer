namespace System.Windows.Media
{
    using Uno.UI.Generic;

    public class BitmapCacheBrush : Proxy<global::Windows.UI.Xaml.Media.BitmapCacheBrush>
    {
        public System.Windows.Media.Visual Target
        {
            get => __ProxyValue.Target;
            set => __ProxyValue.Target = value;
        }

        public System.Windows.Media.BitmapCache BitmapCache
        {
            get => __ProxyValue.BitmapCache;
            set => __ProxyValue.BitmapCache = value;
        }

        public System.Boolean AutoLayoutContent
        {
            get => __ProxyValue.AutoLayoutContent;
            set => __ProxyValue.AutoLayoutContent = value;
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

        public BitmapCacheBrush(): base()
        {
        }

        public BitmapCacheBrush(System.Windows.Media.Visual @visual): base(@visual)
        {
        }

        public System.Windows.Media.BitmapCacheBrush Clone() => __ProxyValue.Clone();
        public System.Windows.Media.BitmapCacheBrush CloneCurrentValue() => __ProxyValue.CloneCurrentValue();
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