namespace System.Windows.Input
{
    using Uno.UI.Generic;

    public class InputMethodStateChangedEventArgs : Proxy<global::Windows.UI.Xaml.Input.InputMethodStateChangedEventArgs>
    {
        public System.Boolean IsImeStateChanged
        {
            get => __ProxyValue.IsImeStateChanged;
        }

        public System.Boolean IsMicrophoneStateChanged
        {
            get => __ProxyValue.IsMicrophoneStateChanged;
        }

        public System.Boolean IsHandwritingStateChanged
        {
            get => __ProxyValue.IsHandwritingStateChanged;
        }

        public System.Boolean IsSpeechModeChanged
        {
            get => __ProxyValue.IsSpeechModeChanged;
        }

        public System.Boolean IsImeConversionModeChanged
        {
            get => __ProxyValue.IsImeConversionModeChanged;
        }

        public System.Boolean IsImeSentenceModeChanged
        {
            get => __ProxyValue.IsImeSentenceModeChanged;
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}