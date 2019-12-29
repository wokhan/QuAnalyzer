namespace System.Windows.Media
{
    using Uno.UI.Generic;

    public class MediaScriptCommandEventArgs : Proxy<global::Windows.UI.Xaml.Media.MediaScriptCommandEventArgs>
    {
        public System.String ParameterType
        {
            get => __ProxyValue.ParameterType;
        }

        public System.String ParameterValue
        {
            get => __ProxyValue.ParameterValue;
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}