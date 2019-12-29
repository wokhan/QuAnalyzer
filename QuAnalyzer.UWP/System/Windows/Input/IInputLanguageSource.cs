namespace System.Windows.Input
{
    using Uno.UI.Generic;

    public class IInputLanguageSource : Proxy<global::Windows.UI.Xaml.Input.IInputLanguageSource>
    {
        public System.Globalization.CultureInfo CurrentInputLanguage
        {
            get => __ProxyValue.CurrentInputLanguage;
            set => __ProxyValue.CurrentInputLanguage = value;
        }

        public System.Collections.IEnumerable InputLanguageList
        {
            get => __ProxyValue.InputLanguageList;
        }

        public void Initialize() => __ProxyValue.Initialize();
        public void Uninitialize() => __ProxyValue.Uninitialize();
    }
}