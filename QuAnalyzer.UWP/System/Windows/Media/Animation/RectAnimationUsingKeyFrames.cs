namespace System.Windows.Media.Animation
{
    using Uno.UI.Generic;

    public class RectAnimationUsingKeyFrames : Proxy<global::Windows.UI.Xaml.Media.Animation.RectAnimationUsingKeyFrames>
    {
        public System.Windows.Media.Animation.RectKeyFrameCollection KeyFrames
        {
            get => __ProxyValue.KeyFrames;
            set => __ProxyValue.KeyFrames = value;
        }

        public System.Boolean IsAdditive
        {
            get => __ProxyValue.IsAdditive;
            set => __ProxyValue.IsAdditive = value;
        }

        public System.Boolean IsCumulative
        {
            get => __ProxyValue.IsCumulative;
            set => __ProxyValue.IsCumulative = value;
        }

        public System.Type TargetPropertyType
        {
            get => __ProxyValue.TargetPropertyType;
        }

        public System.Boolean IsDestinationDefault
        {
            get => __ProxyValue.IsDestinationDefault;
        }

        public System.Double AccelerationRatio
        {
            get => __ProxyValue.AccelerationRatio;
            set => __ProxyValue.AccelerationRatio = value;
        }

        public System.Boolean AutoReverse
        {
            get => __ProxyValue.AutoReverse;
            set => __ProxyValue.AutoReverse = value;
        }

        public System.Nullable<System.TimeSpan> BeginTime
        {
            get => __ProxyValue.BeginTime;
            set => __ProxyValue.BeginTime = value;
        }

        public System.Double DecelerationRatio
        {
            get => __ProxyValue.DecelerationRatio;
            set => __ProxyValue.DecelerationRatio = value;
        }

        public System.Windows.Duration Duration
        {
            get => __ProxyValue.Duration;
            set => __ProxyValue.Duration = value;
        }

        public System.Windows.Media.Animation.FillBehavior FillBehavior
        {
            get => __ProxyValue.FillBehavior;
            set => __ProxyValue.FillBehavior = value;
        }

        public System.String Name
        {
            get => __ProxyValue.Name;
            set => __ProxyValue.Name = value;
        }

        public System.Windows.Media.Animation.RepeatBehavior RepeatBehavior
        {
            get => __ProxyValue.RepeatBehavior;
            set => __ProxyValue.RepeatBehavior = value;
        }

        public System.Double SpeedRatio
        {
            get => __ProxyValue.SpeedRatio;
            set => __ProxyValue.SpeedRatio = value;
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

        public RectAnimationUsingKeyFrames(): base()
        {
        }

        public System.Windows.Media.Animation.RectAnimationUsingKeyFrames Clone() => __ProxyValue.Clone();
        public System.Windows.Media.Animation.RectAnimationUsingKeyFrames CloneCurrentValue() => __ProxyValue.CloneCurrentValue();
        public System.Boolean ShouldSerializeKeyFrames() => __ProxyValue.ShouldSerializeKeyFrames();
        public System.Object GetCurrentValue(System.Object defaultOriginValue, System.Object defaultDestinationValue, System.Windows.Media.Animation.AnimationClock animationClock) => __ProxyValue.GetCurrentValue(@defaultOriginValue, @defaultDestinationValue, @animationClock);
        public System.Windows.Rect GetCurrentValue(System.Windows.Rect defaultOriginValue, System.Windows.Rect defaultDestinationValue, System.Windows.Media.Animation.AnimationClock animationClock) => __ProxyValue.GetCurrentValue(@defaultOriginValue, @defaultDestinationValue, @animationClock);
        public System.Windows.Media.Animation.AnimationClock CreateClock() => __ProxyValue.CreateClock();
        public System.Windows.Media.Animation.Clock CreateClock(System.Boolean hasControllableRoot) => __ProxyValue.CreateClock(@hasControllableRoot);
        public void add_CurrentStateInvalidated(System.EventHandler value) => __ProxyValue.add_CurrentStateInvalidated(@value);
        public void remove_CurrentStateInvalidated(System.EventHandler value) => __ProxyValue.remove_CurrentStateInvalidated(@value);
        public void add_CurrentTimeInvalidated(System.EventHandler value) => __ProxyValue.add_CurrentTimeInvalidated(@value);
        public void remove_CurrentTimeInvalidated(System.EventHandler value) => __ProxyValue.remove_CurrentTimeInvalidated(@value);
        public void add_CurrentGlobalSpeedInvalidated(System.EventHandler value) => __ProxyValue.add_CurrentGlobalSpeedInvalidated(@value);
        public void remove_CurrentGlobalSpeedInvalidated(System.EventHandler value) => __ProxyValue.remove_CurrentGlobalSpeedInvalidated(@value);
        public void add_Completed(System.EventHandler value) => __ProxyValue.add_Completed(@value);
        public void remove_Completed(System.EventHandler value) => __ProxyValue.remove_Completed(@value);
        public void add_RemoveRequested(System.EventHandler value) => __ProxyValue.add_RemoveRequested(@value);
        public void remove_RemoveRequested(System.EventHandler value) => __ProxyValue.remove_RemoveRequested(@value);
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
        public override System.String ToString() => __ProxyValue.ToString();
    }
}