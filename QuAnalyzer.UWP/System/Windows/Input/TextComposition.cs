namespace System.Windows.Input
{
    using Uno.UI.Generic;

    public class TextComposition : Proxy<global::Windows.UI.Xaml.Input.TextComposition>
    {
        public System.String Text
        {
            get => __ProxyValue.Text;
        }

        public System.String CompositionText
        {
            get => __ProxyValue.CompositionText;
        }

        public System.String SystemText
        {
            get => __ProxyValue.SystemText;
        }

        public System.String ControlText
        {
            get => __ProxyValue.ControlText;
        }

        public System.String SystemCompositionText
        {
            get => __ProxyValue.SystemCompositionText;
        }

        public System.Windows.Input.TextCompositionAutoComplete AutoComplete
        {
            get => __ProxyValue.AutoComplete;
        }

        public System.Windows.Threading.Dispatcher Dispatcher
        {
            get => __ProxyValue.Dispatcher;
        }

        public TextComposition(System.Windows.Input.InputManager @inputManager, System.Windows.IInputElement @source, System.String @resultText): base(@inputManager, @source, @resultText)
        {
        }

        public TextComposition(System.Windows.Input.InputManager @inputManager, System.Windows.IInputElement @source, System.String @resultText, System.Windows.Input.TextCompositionAutoComplete @autoComplete): base(@inputManager, @source, @resultText, @autoComplete)
        {
        }

        public void Complete() => __ProxyValue.Complete();
        public System.Boolean CheckAccess() => __ProxyValue.CheckAccess();
        public void VerifyAccess() => __ProxyValue.VerifyAccess();
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}