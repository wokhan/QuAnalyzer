namespace System.Windows.Input
{
    using Uno.UI.Generic;

    public class InputMethod : Proxy<global::Windows.UI.Xaml.Input.InputMethod>
    {
        public static System.Windows.Input.InputMethod Current
        {
            get => __ProxyValue.Current;
        }

        public System.Windows.Input.InputMethodState ImeState
        {
            get => __ProxyValue.ImeState;
            set => __ProxyValue.ImeState = value;
        }

        public System.Windows.Input.InputMethodState MicrophoneState
        {
            get => __ProxyValue.MicrophoneState;
            set => __ProxyValue.MicrophoneState = value;
        }

        public System.Windows.Input.InputMethodState HandwritingState
        {
            get => __ProxyValue.HandwritingState;
            set => __ProxyValue.HandwritingState = value;
        }

        public System.Windows.Input.SpeechMode SpeechMode
        {
            get => __ProxyValue.SpeechMode;
            set => __ProxyValue.SpeechMode = value;
        }

        public System.Windows.Input.ImeConversionModeValues ImeConversionMode
        {
            get => __ProxyValue.ImeConversionMode;
            set => __ProxyValue.ImeConversionMode = value;
        }

        public System.Windows.Input.ImeSentenceModeValues ImeSentenceMode
        {
            get => __ProxyValue.ImeSentenceMode;
            set => __ProxyValue.ImeSentenceMode = value;
        }

        public System.Boolean CanShowConfigurationUI
        {
            get => __ProxyValue.CanShowConfigurationUI;
        }

        public System.Boolean CanShowRegisterWordUI
        {
            get => __ProxyValue.CanShowRegisterWordUI;
        }

        public System.Windows.Threading.Dispatcher Dispatcher
        {
            get => __ProxyValue.Dispatcher;
        }

        public static void SetIsInputMethodEnabled(System.Windows.DependencyObject target, System.Boolean value) => Windows.UI.Xaml.Input.InputMethod.SetIsInputMethodEnabled(@target, @value);
        public static System.Boolean GetIsInputMethodEnabled(System.Windows.DependencyObject target) => Windows.UI.Xaml.Input.InputMethod.GetIsInputMethodEnabled(@target);
        public static void SetIsInputMethodSuspended(System.Windows.DependencyObject target, System.Boolean value) => Windows.UI.Xaml.Input.InputMethod.SetIsInputMethodSuspended(@target, @value);
        public static System.Boolean GetIsInputMethodSuspended(System.Windows.DependencyObject target) => Windows.UI.Xaml.Input.InputMethod.GetIsInputMethodSuspended(@target);
        public static void SetPreferredImeState(System.Windows.DependencyObject target, System.Windows.Input.InputMethodState value) => Windows.UI.Xaml.Input.InputMethod.SetPreferredImeState(@target, @value);
        public static System.Windows.Input.InputMethodState GetPreferredImeState(System.Windows.DependencyObject target) => Windows.UI.Xaml.Input.InputMethod.GetPreferredImeState(@target);
        public static void SetPreferredImeConversionMode(System.Windows.DependencyObject target, System.Windows.Input.ImeConversionModeValues value) => Windows.UI.Xaml.Input.InputMethod.SetPreferredImeConversionMode(@target, @value);
        public static System.Windows.Input.ImeConversionModeValues GetPreferredImeConversionMode(System.Windows.DependencyObject target) => Windows.UI.Xaml.Input.InputMethod.GetPreferredImeConversionMode(@target);
        public static void SetPreferredImeSentenceMode(System.Windows.DependencyObject target, System.Windows.Input.ImeSentenceModeValues value) => Windows.UI.Xaml.Input.InputMethod.SetPreferredImeSentenceMode(@target, @value);
        public static System.Windows.Input.ImeSentenceModeValues GetPreferredImeSentenceMode(System.Windows.DependencyObject target) => Windows.UI.Xaml.Input.InputMethod.GetPreferredImeSentenceMode(@target);
        public static void SetInputScope(System.Windows.DependencyObject target, System.Windows.Input.InputScope value) => Windows.UI.Xaml.Input.InputMethod.SetInputScope(@target, @value);
        public static System.Windows.Input.InputScope GetInputScope(System.Windows.DependencyObject target) => Windows.UI.Xaml.Input.InputMethod.GetInputScope(@target);
        public void ShowConfigureUI() => __ProxyValue.ShowConfigureUI();
        public void ShowConfigureUI(System.Windows.UIElement element) => __ProxyValue.ShowConfigureUI(@element);
        public void ShowRegisterWordUI() => __ProxyValue.ShowRegisterWordUI();
        public void ShowRegisterWordUI(System.String registeredText) => __ProxyValue.ShowRegisterWordUI(@registeredText);
        public void ShowRegisterWordUI(System.Windows.UIElement element, System.String registeredText) => __ProxyValue.ShowRegisterWordUI(@element, @registeredText);
        public void add_StateChanged(System.Windows.Input.InputMethodStateChangedEventHandler value) => __ProxyValue.add_StateChanged(@value);
        public void remove_StateChanged(System.Windows.Input.InputMethodStateChangedEventHandler value) => __ProxyValue.remove_StateChanged(@value);
        public System.Boolean CheckAccess() => __ProxyValue.CheckAccess();
        public void VerifyAccess() => __ProxyValue.VerifyAccess();
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}