namespace System.Windows
{
    using Uno.UI.Generic;

    public class SplashScreen : Proxy<global::Windows.UI.Xaml.SplashScreen>
    {
        public SplashScreen(System.String @resourceName): base(@resourceName)
        {
        }

        public SplashScreen(System.Reflection.Assembly @resourceAssembly, System.String @resourceName): base(@resourceAssembly, @resourceName)
        {
        }

        public void Show(System.Boolean autoClose) => __ProxyValue.Show(@autoClose);
        public void Show(System.Boolean autoClose, System.Boolean topMost) => __ProxyValue.Show(@autoClose, @topMost);
        public void Close(System.TimeSpan fadeoutDuration) => __ProxyValue.Close(@fadeoutDuration);
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}