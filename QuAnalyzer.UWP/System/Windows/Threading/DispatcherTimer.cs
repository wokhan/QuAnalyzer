namespace System.Windows.Threading
{
    using Uno.UI.Generic;

    public class DispatcherTimer : Proxy<global::Windows.UI.Xaml.Threading.DispatcherTimer>
    {
        public System.Windows.Threading.Dispatcher Dispatcher
        {
            get => __ProxyValue.Dispatcher;
        }

        public System.Boolean IsEnabled
        {
            get => __ProxyValue.IsEnabled;
            set => __ProxyValue.IsEnabled = value;
        }

        public System.TimeSpan Interval
        {
            get => __ProxyValue.Interval;
            set => __ProxyValue.Interval = value;
        }

        public System.Object Tag
        {
            get => __ProxyValue.Tag;
            set => __ProxyValue.Tag = value;
        }

        public DispatcherTimer(): base()
        {
        }

        public DispatcherTimer(System.Windows.Threading.DispatcherPriority @priority): base(@priority)
        {
        }

        public DispatcherTimer(System.Windows.Threading.DispatcherPriority @priority, System.Windows.Threading.Dispatcher @dispatcher): base(@priority, @dispatcher)
        {
        }

        public DispatcherTimer(System.TimeSpan @interval, System.Windows.Threading.DispatcherPriority @priority, System.EventHandler @callback, System.Windows.Threading.Dispatcher @dispatcher): base(@interval, @priority, @callback, @dispatcher)
        {
        }

        public void Start() => __ProxyValue.Start();
        public void Stop() => __ProxyValue.Stop();
        public void add_Tick(System.EventHandler value) => __ProxyValue.add_Tick(@value);
        public void remove_Tick(System.EventHandler value) => __ProxyValue.remove_Tick(@value);
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}