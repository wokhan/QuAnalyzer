namespace System.Windows.Media.Animation
{
    using Uno.UI.Generic;

    public class Storyboard : Proxy<global::Windows.UI.Xaml.Media.Animation.Storyboard>
    {
        public System.Windows.Media.Animation.SlipBehavior SlipBehavior
        {
            get => __ProxyValue.SlipBehavior;
            set => __ProxyValue.SlipBehavior = value;
        }

        public System.Windows.Media.Animation.TimelineCollection Children
        {
            get => __ProxyValue.Children;
            set => __ProxyValue.Children = value;
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

        public Storyboard(): base()
        {
        }

        public void SetSpeedRatio(System.Windows.FrameworkContentElement containingObject, System.Double speedRatio) => __ProxyValue.SetSpeedRatio(@containingObject, @speedRatio);
        public void SetSpeedRatio(System.Double speedRatio) => __ProxyValue.SetSpeedRatio(@speedRatio);
        public void SkipToFill(System.Windows.FrameworkElement containingObject) => __ProxyValue.SkipToFill(@containingObject);
        public void SkipToFill(System.Windows.FrameworkContentElement containingObject) => __ProxyValue.SkipToFill(@containingObject);
        public void SkipToFill() => __ProxyValue.SkipToFill();
        public void Stop(System.Windows.FrameworkElement containingObject) => __ProxyValue.Stop(@containingObject);
        public void Stop(System.Windows.FrameworkContentElement containingObject) => __ProxyValue.Stop(@containingObject);
        public void Stop() => __ProxyValue.Stop();
        public System.Windows.Media.Animation.Storyboard Clone() => __ProxyValue.Clone();
        public static void SetTarget(System.Windows.DependencyObject element, System.Windows.DependencyObject value) => Windows.UI.Xaml.Media.Animation.Storyboard.SetTarget(@element, @value);
        public static System.Windows.DependencyObject GetTarget(System.Windows.DependencyObject element) => Windows.UI.Xaml.Media.Animation.Storyboard.GetTarget(@element);
        public static void SetTargetName(System.Windows.DependencyObject element, System.String name) => Windows.UI.Xaml.Media.Animation.Storyboard.SetTargetName(@element, @name);
        public static System.String GetTargetName(System.Windows.DependencyObject element) => Windows.UI.Xaml.Media.Animation.Storyboard.GetTargetName(@element);
        public static void SetTargetProperty(System.Windows.DependencyObject element, System.Windows.PropertyPath path) => Windows.UI.Xaml.Media.Animation.Storyboard.SetTargetProperty(@element, @path);
        public static System.Windows.PropertyPath GetTargetProperty(System.Windows.DependencyObject element) => Windows.UI.Xaml.Media.Animation.Storyboard.GetTargetProperty(@element);
        public void Begin(System.Windows.FrameworkElement containingObject) => __ProxyValue.Begin(@containingObject);
        public void Begin(System.Windows.FrameworkElement containingObject, System.Windows.Media.Animation.HandoffBehavior handoffBehavior) => __ProxyValue.Begin(@containingObject, @handoffBehavior);
        public void Begin(System.Windows.FrameworkElement containingObject, System.Boolean isControllable) => __ProxyValue.Begin(@containingObject, @isControllable);
        public void Begin(System.Windows.FrameworkElement containingObject, System.Windows.Media.Animation.HandoffBehavior handoffBehavior, System.Boolean isControllable) => __ProxyValue.Begin(@containingObject, @handoffBehavior, @isControllable);
        public void Begin(System.Windows.FrameworkElement containingObject, System.Windows.FrameworkTemplate frameworkTemplate) => __ProxyValue.Begin(@containingObject, @frameworkTemplate);
        public void Begin(System.Windows.FrameworkElement containingObject, System.Windows.FrameworkTemplate frameworkTemplate, System.Windows.Media.Animation.HandoffBehavior handoffBehavior) => __ProxyValue.Begin(@containingObject, @frameworkTemplate, @handoffBehavior);
        public void Begin(System.Windows.FrameworkElement containingObject, System.Windows.FrameworkTemplate frameworkTemplate, System.Boolean isControllable) => __ProxyValue.Begin(@containingObject, @frameworkTemplate, @isControllable);
        public void Begin(System.Windows.FrameworkElement containingObject, System.Windows.FrameworkTemplate frameworkTemplate, System.Windows.Media.Animation.HandoffBehavior handoffBehavior, System.Boolean isControllable) => __ProxyValue.Begin(@containingObject, @frameworkTemplate, @handoffBehavior, @isControllable);
        public void Begin(System.Windows.FrameworkContentElement containingObject) => __ProxyValue.Begin(@containingObject);
        public void Begin(System.Windows.FrameworkContentElement containingObject, System.Windows.Media.Animation.HandoffBehavior handoffBehavior) => __ProxyValue.Begin(@containingObject, @handoffBehavior);
        public void Begin(System.Windows.FrameworkContentElement containingObject, System.Boolean isControllable) => __ProxyValue.Begin(@containingObject, @isControllable);
        public void Begin(System.Windows.FrameworkContentElement containingObject, System.Windows.Media.Animation.HandoffBehavior handoffBehavior, System.Boolean isControllable) => __ProxyValue.Begin(@containingObject, @handoffBehavior, @isControllable);
        public void Begin() => __ProxyValue.Begin();
        public System.Nullable<System.Double> GetCurrentGlobalSpeed(System.Windows.FrameworkElement containingObject) => __ProxyValue.GetCurrentGlobalSpeed(@containingObject);
        public System.Nullable<System.Double> GetCurrentGlobalSpeed(System.Windows.FrameworkContentElement containingObject) => __ProxyValue.GetCurrentGlobalSpeed(@containingObject);
        public System.Double GetCurrentGlobalSpeed() => __ProxyValue.GetCurrentGlobalSpeed();
        public System.Nullable<System.Int32> GetCurrentIteration(System.Windows.FrameworkElement containingObject) => __ProxyValue.GetCurrentIteration(@containingObject);
        public System.Nullable<System.Int32> GetCurrentIteration(System.Windows.FrameworkContentElement containingObject) => __ProxyValue.GetCurrentIteration(@containingObject);
        public System.Int32 GetCurrentIteration() => __ProxyValue.GetCurrentIteration();
        public System.Nullable<System.Double> GetCurrentProgress(System.Windows.FrameworkElement containingObject) => __ProxyValue.GetCurrentProgress(@containingObject);
        public System.Nullable<System.Double> GetCurrentProgress(System.Windows.FrameworkContentElement containingObject) => __ProxyValue.GetCurrentProgress(@containingObject);
        public System.Double GetCurrentProgress() => __ProxyValue.GetCurrentProgress();
        public System.Windows.Media.Animation.ClockState GetCurrentState(System.Windows.FrameworkElement containingObject) => __ProxyValue.GetCurrentState(@containingObject);
        public System.Windows.Media.Animation.ClockState GetCurrentState(System.Windows.FrameworkContentElement containingObject) => __ProxyValue.GetCurrentState(@containingObject);
        public System.Windows.Media.Animation.ClockState GetCurrentState() => __ProxyValue.GetCurrentState();
        public System.Nullable<System.TimeSpan> GetCurrentTime(System.Windows.FrameworkElement containingObject) => __ProxyValue.GetCurrentTime(@containingObject);
        public System.Nullable<System.TimeSpan> GetCurrentTime(System.Windows.FrameworkContentElement containingObject) => __ProxyValue.GetCurrentTime(@containingObject);
        public System.TimeSpan GetCurrentTime() => __ProxyValue.GetCurrentTime();
        public System.Boolean GetIsPaused(System.Windows.FrameworkElement containingObject) => __ProxyValue.GetIsPaused(@containingObject);
        public System.Boolean GetIsPaused(System.Windows.FrameworkContentElement containingObject) => __ProxyValue.GetIsPaused(@containingObject);
        public System.Boolean GetIsPaused() => __ProxyValue.GetIsPaused();
        public void Pause(System.Windows.FrameworkElement containingObject) => __ProxyValue.Pause(@containingObject);
        public void Pause(System.Windows.FrameworkContentElement containingObject) => __ProxyValue.Pause(@containingObject);
        public void Pause() => __ProxyValue.Pause();
        public void Remove(System.Windows.FrameworkElement containingObject) => __ProxyValue.Remove(@containingObject);
        public void Remove(System.Windows.FrameworkContentElement containingObject) => __ProxyValue.Remove(@containingObject);
        public void Remove() => __ProxyValue.Remove();
        public void Resume(System.Windows.FrameworkElement containingObject) => __ProxyValue.Resume(@containingObject);
        public void Resume(System.Windows.FrameworkContentElement containingObject) => __ProxyValue.Resume(@containingObject);
        public void Resume() => __ProxyValue.Resume();
        public void Seek(System.Windows.FrameworkElement containingObject, System.TimeSpan offset, System.Windows.Media.Animation.TimeSeekOrigin origin) => __ProxyValue.Seek(@containingObject, @offset, @origin);
        public void Seek(System.Windows.FrameworkContentElement containingObject, System.TimeSpan offset, System.Windows.Media.Animation.TimeSeekOrigin origin) => __ProxyValue.Seek(@containingObject, @offset, @origin);
        public void Seek(System.TimeSpan offset, System.Windows.Media.Animation.TimeSeekOrigin origin) => __ProxyValue.Seek(@offset, @origin);
        public void Seek(System.TimeSpan offset) => __ProxyValue.Seek(@offset);
        public void SeekAlignedToLastTick(System.Windows.FrameworkElement containingObject, System.TimeSpan offset, System.Windows.Media.Animation.TimeSeekOrigin origin) => __ProxyValue.SeekAlignedToLastTick(@containingObject, @offset, @origin);
        public void SeekAlignedToLastTick(System.Windows.FrameworkContentElement containingObject, System.TimeSpan offset, System.Windows.Media.Animation.TimeSeekOrigin origin) => __ProxyValue.SeekAlignedToLastTick(@containingObject, @offset, @origin);
        public void SeekAlignedToLastTick(System.TimeSpan offset, System.Windows.Media.Animation.TimeSeekOrigin origin) => __ProxyValue.SeekAlignedToLastTick(@offset, @origin);
        public void SeekAlignedToLastTick(System.TimeSpan offset) => __ProxyValue.SeekAlignedToLastTick(@offset);
        public void SetSpeedRatio(System.Windows.FrameworkElement containingObject, System.Double speedRatio) => __ProxyValue.SetSpeedRatio(@containingObject, @speedRatio);
        public System.Windows.Media.Animation.ParallelTimeline CloneCurrentValue() => __ProxyValue.CloneCurrentValue();
        public System.Windows.Media.Animation.ClockGroup CreateClock() => __ProxyValue.CreateClock();
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