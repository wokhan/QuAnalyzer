namespace System.Windows.Controls.Primitives
{
    using Uno.UI.Generic;

    public class CustomPopupPlacementCallback : Proxy<global::Windows.UI.Xaml.Controls.Primitives.CustomPopupPlacementCallback>
    {
        public System.Object Target
        {
            get => __ProxyValue.Target;
        }

        public System.Reflection.MethodInfo Method
        {
            get => __ProxyValue.Method;
        }

        public CustomPopupPlacementCallback(System.Object @object, System.IntPtr @method): base(@object, @method)
        {
        }

        public System.Windows.Controls.Primitives.CustomPopupPlacement[] Invoke(System.Windows.Size popupSize, System.Windows.Size targetSize, System.Windows.Point offset) => __ProxyValue.Invoke(@popupSize, @targetSize, @offset);
        public System.IAsyncResult BeginInvoke(System.Windows.Size popupSize, System.Windows.Size targetSize, System.Windows.Point offset, System.AsyncCallback callback, System.Object object) => __ProxyValue.BeginInvoke(@popupSize, @targetSize, @offset, @callback, @object);
        public System.Windows.Controls.Primitives.CustomPopupPlacement[] EndInvoke(System.IAsyncResult result) => __ProxyValue.EndInvoke(@result);
        public void GetObjectData(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) => __ProxyValue.GetObjectData(@info, @context);
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public System.Delegate[] GetInvocationList() => __ProxyValue.GetInvocationList();
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
        public System.Object Clone() => __ProxyValue.Clone();
        public System.Object DynamicInvoke(System.Object[] args) => __ProxyValue.DynamicInvoke(@args);
        public override System.String ToString() => __ProxyValue.ToString();
    }
}