namespace System.Windows.Data
{
    using Uno.UI.Generic;

    public class GroupDescriptionSelectorCallback : Proxy<global::Windows.UI.Xaml.Data.GroupDescriptionSelectorCallback>
    {
        public System.Object Target
        {
            get => __ProxyValue.Target;
        }

        public System.Reflection.MethodInfo Method
        {
            get => __ProxyValue.Method;
        }

        public GroupDescriptionSelectorCallback(System.Object @object, System.IntPtr @method): base(@object, @method)
        {
        }

        public System.ComponentModel.GroupDescription Invoke(System.Windows.Data.CollectionViewGroup group, System.Int32 level) => __ProxyValue.Invoke(@group, @level);
        public System.IAsyncResult BeginInvoke(System.Windows.Data.CollectionViewGroup group, System.Int32 level, System.AsyncCallback callback, System.Object object) => __ProxyValue.BeginInvoke(@group, @level, @callback, @object);
        public System.ComponentModel.GroupDescription EndInvoke(System.IAsyncResult result) => __ProxyValue.EndInvoke(@result);
        public void GetObjectData(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) => __ProxyValue.GetObjectData(@info, @context);
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public System.Delegate[] GetInvocationList() => __ProxyValue.GetInvocationList();
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
        public System.Object Clone() => __ProxyValue.Clone();
        public System.Object DynamicInvoke(System.Object[] args) => __ProxyValue.DynamicInvoke(@args);
        public override System.String ToString() => __ProxyValue.ToString();
    }
}