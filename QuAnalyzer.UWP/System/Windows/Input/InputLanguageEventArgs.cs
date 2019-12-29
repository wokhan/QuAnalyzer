namespace System.Windows.Input
{
    using Uno.UI.Generic;

    public class InputLanguageEventArgs : Proxy<global::Windows.UI.Xaml.Input.InputLanguageEventArgs>
    {
        public System.Globalization.CultureInfo NewLanguage
        {
            get => __ProxyValue.NewLanguage;
        }

        public System.Globalization.CultureInfo PreviousLanguage
        {
            get => __ProxyValue.PreviousLanguage;
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}