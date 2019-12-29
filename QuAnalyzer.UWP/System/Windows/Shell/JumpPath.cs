namespace System.Windows.Shell
{
    using Uno.UI.Generic;

    public class JumpPath : Proxy<global::Windows.UI.Xaml.Shell.JumpPath>
    {
        public System.String Path
        {
            get => __ProxyValue.Path;
            set => __ProxyValue.Path = value;
        }

        public System.String CustomCategory
        {
            get => __ProxyValue.CustomCategory;
            set => __ProxyValue.CustomCategory = value;
        }

        public JumpPath(): base()
        {
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}