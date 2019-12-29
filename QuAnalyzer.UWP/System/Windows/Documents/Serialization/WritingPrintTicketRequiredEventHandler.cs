﻿namespace System.Windows.Documents.Serialization
{
    using Uno.UI.Generic;

    public class WritingPrintTicketRequiredEventHandler : Proxy<global::Windows.UI.Xaml.Documents.Serialization.WritingPrintTicketRequiredEventHandler>
    {
        public System.Object Target
        {
            get => __ProxyValue.Target;
        }

        public System.Reflection.MethodInfo Method
        {
            get => __ProxyValue.Method;
        }

        public WritingPrintTicketRequiredEventHandler(System.Object @object, System.IntPtr @method): base(@object, @method)
        {
        }

        public void Invoke(System.Object sender, System.Windows.Documents.Serialization.WritingPrintTicketRequiredEventArgs e) => __ProxyValue.Invoke(@sender, @e);
        public System.IAsyncResult BeginInvoke(System.Object sender, System.Windows.Documents.Serialization.WritingPrintTicketRequiredEventArgs e, System.AsyncCallback callback, System.Object object) => __ProxyValue.BeginInvoke(@sender, @e, @callback, @object);
        public void EndInvoke(System.IAsyncResult result) => __ProxyValue.EndInvoke(@result);
        public void GetObjectData(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) => __ProxyValue.GetObjectData(@info, @context);
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public System.Delegate[] GetInvocationList() => __ProxyValue.GetInvocationList();
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
        public System.Object Clone() => __ProxyValue.Clone();
        public System.Object DynamicInvoke(System.Object[] args) => __ProxyValue.DynamicInvoke(@args);
        public override System.String ToString() => __ProxyValue.ToString();
    }
}