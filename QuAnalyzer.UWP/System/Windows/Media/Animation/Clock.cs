namespace System.Windows.Media.Animation
{
    using Uno.UI.Generic;

    public class Clock : Proxy<global::Windows.UI.Xaml.Media.Animation.Clock>
    {
        public System.Windows.Media.Animation.ClockController Controller
        {
            get => __ProxyValue.Controller;
        }

        public System.Nullable<System.Int32> CurrentIteration
        {
            get => __ProxyValue.CurrentIteration;
        }

        public System.Nullable<System.Double> CurrentGlobalSpeed
        {
            get => __ProxyValue.CurrentGlobalSpeed;
        }

        public System.Nullable<System.Double> CurrentProgress
        {
            get => __ProxyValue.CurrentProgress;
        }

        public System.Windows.Media.Animation.ClockState CurrentState
        {
            get => __ProxyValue.CurrentState;
        }

        public System.Nullable<System.TimeSpan> CurrentTime
        {
            get => __ProxyValue.CurrentTime;
        }

        public System.Boolean HasControllableRoot
        {
            get => __ProxyValue.HasControllableRoot;
        }

        public System.Boolean IsPaused
        {
            get => __ProxyValue.IsPaused;
        }

        public System.Windows.Duration NaturalDuration
        {
            get => __ProxyValue.NaturalDuration;
        }

        public System.Windows.Media.Animation.Clock Parent
        {
            get => __ProxyValue.Parent;
        }

        public System.Windows.Media.Animation.Timeline Timeline
        {
            get => __ProxyValue.Timeline;
        }

        public System.Windows.Threading.Dispatcher Dispatcher
        {
            get => __ProxyValue.Dispatcher;
        }

        public void add_Completed(System.EventHandler value) => __ProxyValue.add_Completed(@value);
        public void remove_Completed(System.EventHandler value) => __ProxyValue.remove_Completed(@value);
        public void add_CurrentGlobalSpeedInvalidated(System.EventHandler value) => __ProxyValue.add_CurrentGlobalSpeedInvalidated(@value);
        public void remove_CurrentGlobalSpeedInvalidated(System.EventHandler value) => __ProxyValue.remove_CurrentGlobalSpeedInvalidated(@value);
        public void add_CurrentStateInvalidated(System.EventHandler value) => __ProxyValue.add_CurrentStateInvalidated(@value);
        public void remove_CurrentStateInvalidated(System.EventHandler value) => __ProxyValue.remove_CurrentStateInvalidated(@value);
        public void add_CurrentTimeInvalidated(System.EventHandler value) => __ProxyValue.add_CurrentTimeInvalidated(@value);
        public void remove_CurrentTimeInvalidated(System.EventHandler value) => __ProxyValue.remove_CurrentTimeInvalidated(@value);
        public void add_RemoveRequested(System.EventHandler value) => __ProxyValue.add_RemoveRequested(@value);
        public void remove_RemoveRequested(System.EventHandler value) => __ProxyValue.remove_RemoveRequested(@value);
        public System.Boolean CheckAccess() => __ProxyValue.CheckAccess();
        public void VerifyAccess() => __ProxyValue.VerifyAccess();
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}