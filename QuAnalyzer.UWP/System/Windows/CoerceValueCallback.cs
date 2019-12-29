namespace System.Windows
{
    using Uno.UI.Generic;

    public class CoerceValueCallback : Proxy<global::Windows.UI.Xaml.CoerceValueCallback>
    {
        public System.Object Target
        {
            get => __ProxyValue.Target;
        }

        public System.Reflection.MethodInfo Method
        {
            get => __ProxyValue.Method;
        }

        public CoerceValueCallback(System.Object @object, System.IntPtr @method): base(@object, @method)
        {
        }

        public System.Object Invoke(System.Windows.DependencyObject d, System.Object baseValue) => __ProxyValue.Invoke(@d, @baseValue);
        public System.IAsyncResult BeginInvoke(System.Windows.DependencyObject d, System.Object baseValue, System.AsyncCallback callback, System.Object object) => __ProxyValue.BeginInvoke(@d, @baseValue, @callback, @object);
        public System.Object EndInvoke(System.IAsyncResult result) => __ProxyValue.EndInvoke(@result);
        public void GetObjectData(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) => __ProxyValue.GetObjectData(@info, @context);
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public System.Delegate[] GetInvocationList() => __ProxyValue.GetInvocationList();
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
        public System.Object Clone() => __ProxyValue.Clone();
        public System.Object DynamicInvoke(System.Object[] args) => __ProxyValue.DynamicInvoke(@args);
        public override System.String ToString() => __ProxyValue.ToString();
    }
}