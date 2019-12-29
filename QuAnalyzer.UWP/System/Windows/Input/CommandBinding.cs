namespace System.Windows.Input
{
    using Uno.UI.Generic;

    public class CommandBinding : Proxy<global::Windows.UI.Xaml.Input.CommandBinding>
    {
        public System.Windows.Input.ICommand Command
        {
            get => __ProxyValue.Command;
            set => __ProxyValue.Command = value;
        }

        public CommandBinding(): base()
        {
        }

        public CommandBinding(System.Windows.Input.ICommand @command): base(@command)
        {
        }

        public CommandBinding(System.Windows.Input.ICommand @command, System.Windows.Input.ExecutedRoutedEventHandler @executed): base(@command, @executed)
        {
        }

        public CommandBinding(System.Windows.Input.ICommand @command, System.Windows.Input.ExecutedRoutedEventHandler @executed, System.Windows.Input.CanExecuteRoutedEventHandler @canExecute): base(@command, @executed, @canExecute)
        {
        }

        public void add_PreviewExecuted(System.Windows.Input.ExecutedRoutedEventHandler value) => __ProxyValue.add_PreviewExecuted(@value);
        public void remove_PreviewExecuted(System.Windows.Input.ExecutedRoutedEventHandler value) => __ProxyValue.remove_PreviewExecuted(@value);
        public void add_Executed(System.Windows.Input.ExecutedRoutedEventHandler value) => __ProxyValue.add_Executed(@value);
        public void remove_Executed(System.Windows.Input.ExecutedRoutedEventHandler value) => __ProxyValue.remove_Executed(@value);
        public void add_PreviewCanExecute(System.Windows.Input.CanExecuteRoutedEventHandler value) => __ProxyValue.add_PreviewCanExecute(@value);
        public void remove_PreviewCanExecute(System.Windows.Input.CanExecuteRoutedEventHandler value) => __ProxyValue.remove_PreviewCanExecute(@value);
        public void add_CanExecute(System.Windows.Input.CanExecuteRoutedEventHandler value) => __ProxyValue.add_CanExecute(@value);
        public void remove_CanExecute(System.Windows.Input.CanExecuteRoutedEventHandler value) => __ProxyValue.remove_CanExecute(@value);
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}