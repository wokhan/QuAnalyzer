namespace System.Windows
{
    using Uno.UI.Generic;

    public class BaseCompatibilityPreferences : Proxy<global::Windows.UI.Xaml.BaseCompatibilityPreferences>
    {
        public static System.Boolean ReuseDispatcherSynchronizationContextInstance
        {
            get => __ProxyValue.ReuseDispatcherSynchronizationContextInstance;
            set => __ProxyValue.ReuseDispatcherSynchronizationContextInstance = value;
        }

        public static System.Boolean FlowDispatcherSynchronizationContextPriority
        {
            get => __ProxyValue.FlowDispatcherSynchronizationContextPriority;
            set => __ProxyValue.FlowDispatcherSynchronizationContextPriority = value;
        }

        public static System.Boolean InlineDispatcherSynchronizationContextSend
        {
            get => __ProxyValue.InlineDispatcherSynchronizationContextSend;
            set => __ProxyValue.InlineDispatcherSynchronizationContextSend = value;
        }

        public static System.Windows.HandleDispatcherRequestProcessingFailureOptions HandleDispatcherRequestProcessingFailure
        {
            get => __ProxyValue.HandleDispatcherRequestProcessingFailure;
            set => __ProxyValue.HandleDispatcherRequestProcessingFailure = value;
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}