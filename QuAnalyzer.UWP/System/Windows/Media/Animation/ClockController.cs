namespace System.Windows.Media.Animation
{
    using Uno.UI.Generic;

    public class ClockController : Proxy<global::Windows.UI.Xaml.Media.Animation.ClockController>
    {
        public System.Windows.Media.Animation.Clock Clock
        {
            get => __ProxyValue.Clock;
        }

        public System.Double SpeedRatio
        {
            get => __ProxyValue.SpeedRatio;
            set => __ProxyValue.SpeedRatio = value;
        }

        public System.Windows.Threading.Dispatcher Dispatcher
        {
            get => __ProxyValue.Dispatcher;
        }

        public void Begin() => __ProxyValue.Begin();
        public void SkipToFill() => __ProxyValue.SkipToFill();
        public void Pause() => __ProxyValue.Pause();
        public void Resume() => __ProxyValue.Resume();
        public void Seek(System.TimeSpan offset, System.Windows.Media.Animation.TimeSeekOrigin origin) => __ProxyValue.Seek(@offset, @origin);
        public void SeekAlignedToLastTick(System.TimeSpan offset, System.Windows.Media.Animation.TimeSeekOrigin origin) => __ProxyValue.SeekAlignedToLastTick(@offset, @origin);
        public void Stop() => __ProxyValue.Stop();
        public void Remove() => __ProxyValue.Remove();
        public System.Boolean CheckAccess() => __ProxyValue.CheckAccess();
        public void VerifyAccess() => __ProxyValue.VerifyAccess();
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}