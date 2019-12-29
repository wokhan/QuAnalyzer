namespace System.Windows.Data
{
    using Uno.UI.Generic;

    public class CollectionSynchronizationCallback : Proxy<global::Windows.UI.Xaml.Data.CollectionSynchronizationCallback>
    {
        public System.Object Target
        {
            get => __ProxyValue.Target;
        }

        public System.Reflection.MethodInfo Method
        {
            get => __ProxyValue.Method;
        }

        public CollectionSynchronizationCallback(System.Object @object, System.IntPtr @method): base(@object, @method)
        {
        }

        public void Invoke(System.Collections.IEnumerable collection, System.Object context, System.Action accessMethod, System.Boolean writeAccess) => __ProxyValue.Invoke(@collection, @context, @accessMethod, @writeAccess);
        public System.IAsyncResult BeginInvoke(System.Collections.IEnumerable collection, System.Object context, System.Action accessMethod, System.Boolean writeAccess, System.AsyncCallback callback, System.Object object) => __ProxyValue.BeginInvoke(@collection, @context, @accessMethod, @writeAccess, @callback, @object);
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