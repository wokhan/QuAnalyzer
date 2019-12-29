namespace System.Windows.Input
{
    using Uno.UI.Generic;

    public class StagingAreaInputItem : Proxy<global::Windows.UI.Xaml.Input.StagingAreaInputItem>
    {
        public System.Windows.Input.InputEventArgs Input
        {
            get => __ProxyValue.Input;
        }

        public System.Object GetData(System.Object key) => __ProxyValue.GetData(@key);
        public void SetData(System.Object key, System.Object value) => __ProxyValue.SetData(@key, @value);
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}