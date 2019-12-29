namespace System.Windows.Input
{
    using Uno.UI.Generic;

    public class InputLanguageManager : Proxy<global::Windows.UI.Xaml.Input.InputLanguageManager>
    {
        public static System.Windows.Input.InputLanguageManager Current
        {
            get => __ProxyValue.Current;
        }

        public System.Globalization.CultureInfo CurrentInputLanguage
        {
            get => __ProxyValue.CurrentInputLanguage;
            set => __ProxyValue.CurrentInputLanguage = value;
        }

        public System.Collections.IEnumerable AvailableInputLanguages
        {
            get => __ProxyValue.AvailableInputLanguages;
        }

        public System.Windows.Threading.Dispatcher Dispatcher
        {
            get => __ProxyValue.Dispatcher;
        }

        public static void SetInputLanguage(System.Windows.DependencyObject target, System.Globalization.CultureInfo inputLanguage) => Windows.UI.Xaml.Input.InputLanguageManager.SetInputLanguage(@target, @inputLanguage);
        public static System.Globalization.CultureInfo GetInputLanguage(System.Windows.DependencyObject target) => Windows.UI.Xaml.Input.InputLanguageManager.GetInputLanguage(@target);
        public static void SetRestoreInputLanguage(System.Windows.DependencyObject target, System.Boolean restore) => Windows.UI.Xaml.Input.InputLanguageManager.SetRestoreInputLanguage(@target, @restore);
        public static System.Boolean GetRestoreInputLanguage(System.Windows.DependencyObject target) => Windows.UI.Xaml.Input.InputLanguageManager.GetRestoreInputLanguage(@target);
        public void RegisterInputLanguageSource(System.Windows.Input.IInputLanguageSource inputLanguageSource) => __ProxyValue.RegisterInputLanguageSource(@inputLanguageSource);
        public void ReportInputLanguageChanged(System.Globalization.CultureInfo newLanguageId, System.Globalization.CultureInfo previousLanguageId) => __ProxyValue.ReportInputLanguageChanged(@newLanguageId, @previousLanguageId);
        public System.Boolean ReportInputLanguageChanging(System.Globalization.CultureInfo newLanguageId, System.Globalization.CultureInfo previousLanguageId) => __ProxyValue.ReportInputLanguageChanging(@newLanguageId, @previousLanguageId);
        public void add_InputLanguageChanged(System.Windows.Input.InputLanguageEventHandler value) => __ProxyValue.add_InputLanguageChanged(@value);
        public void remove_InputLanguageChanged(System.Windows.Input.InputLanguageEventHandler value) => __ProxyValue.remove_InputLanguageChanged(@value);
        public void add_InputLanguageChanging(System.Windows.Input.InputLanguageEventHandler value) => __ProxyValue.add_InputLanguageChanging(@value);
        public void remove_InputLanguageChanging(System.Windows.Input.InputLanguageEventHandler value) => __ProxyValue.remove_InputLanguageChanging(@value);
        public System.Boolean CheckAccess() => __ProxyValue.CheckAccess();
        public void VerifyAccess() => __ProxyValue.VerifyAccess();
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}