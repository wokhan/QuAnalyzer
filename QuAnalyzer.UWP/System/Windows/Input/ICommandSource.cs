namespace System.Windows.Input
{
    using Uno.UI.Generic;

    public class ICommandSource : Proxy<global::Windows.UI.Xaml.Input.ICommandSource>
    {
        public System.Windows.Input.ICommand Command
        {
            get => __ProxyValue.Command;
        }

        public System.Object CommandParameter
        {
            get => __ProxyValue.CommandParameter;
        }

        public System.Windows.IInputElement CommandTarget
        {
            get => __ProxyValue.CommandTarget;
        }
    }
}