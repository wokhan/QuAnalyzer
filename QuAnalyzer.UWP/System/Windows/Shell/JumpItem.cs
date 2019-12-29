namespace System.Windows.Shell
{
    using Uno.UI.Generic;

    public class JumpItem : Proxy<global::Windows.UI.Xaml.Shell.JumpItem>
    {
        public System.String CustomCategory
        {
            get => __ProxyValue.CustomCategory;
            set => __ProxyValue.CustomCategory = value;
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}