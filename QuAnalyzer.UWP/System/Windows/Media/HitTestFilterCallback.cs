namespace System.Windows.Media
{
    using Uno.UI.Generic;

    public class HitTestFilterCallback : Proxy<global::Windows.UI.Xaml.Media.HitTestFilterCallback>
    {
        public System.Object Target
        {
            get => __ProxyValue.Target;
        }

        public System.Reflection.MethodInfo Method
        {
            get => __ProxyValue.Method;
        }

        public HitTestFilterCallback(System.Object @object, System.IntPtr @method): base(@object, @method)
        {
        }

        public System.Windows.Media.HitTestFilterBehavior Invoke(System.Windows.DependencyObject potentialHitTestTarget) => __ProxyValue.Invoke(@potentialHitTestTarget);
        public System.IAsyncResult BeginInvoke(System.Windows.DependencyObject potentialHitTestTarget, System.AsyncCallback callback, System.Object object) => __ProxyValue.BeginInvoke(@potentialHitTestTarget, @callback, @object);
        public System.Windows.Media.HitTestFilterBehavior EndInvoke(System.IAsyncResult result) => __ProxyValue.EndInvoke(@result);
        public void GetObjectData(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) => __ProxyValue.GetObjectData(@info, @context);
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public System.Delegate[] GetInvocationList() => __ProxyValue.GetInvocationList();
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
        public System.Object Clone() => __ProxyValue.Clone();
        public System.Object DynamicInvoke(System.Object[] args) => __ProxyValue.DynamicInvoke(@args);
        public override System.String ToString() => __ProxyValue.ToString();
    }
}