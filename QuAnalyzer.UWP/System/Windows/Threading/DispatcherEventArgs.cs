﻿namespace System.Windows.Threading
{
    using Uno.UI.Generic;

    public class DispatcherEventArgs : Proxy<global::Windows.UI.Xaml.Threading.DispatcherEventArgs>
    {
        public System.Windows.Threading.Dispatcher Dispatcher
        {
            get => __ProxyValue.Dispatcher;
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}