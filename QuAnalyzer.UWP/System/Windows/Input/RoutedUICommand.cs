namespace System.Windows.Input
{
    using Uno.UI.Generic;

    public class RoutedUICommand : Proxy<global::Windows.UI.Xaml.Input.RoutedUICommand>
    {
        public System.String Text
        {
            get => __ProxyValue.Text;
            set => __ProxyValue.Text = value;
        }

        public System.String Name
        {
            get => __ProxyValue.Name;
        }

        public System.Type OwnerType
        {
            get => __ProxyValue.OwnerType;
        }

        public System.Windows.Input.InputGestureCollection InputGestures
        {
            get => __ProxyValue.InputGestures;
        }

        public RoutedUICommand(): base()
        {
        }

        public RoutedUICommand(System.String @text, System.String @name, System.Type @ownerType): base(@text, @name, @ownerType)
        {
        }

        public RoutedUICommand(System.String @text, System.String @name, System.Type @ownerType, System.Windows.Input.InputGestureCollection @inputGestures): base(@text, @name, @ownerType, @inputGestures)
        {
        }

        public void add_CanExecuteChanged(System.EventHandler value) => __ProxyValue.add_CanExecuteChanged(@value);
        public void remove_CanExecuteChanged(System.EventHandler value) => __ProxyValue.remove_CanExecuteChanged(@value);
        public void Execute(System.Object parameter, System.Windows.IInputElement target) => __ProxyValue.Execute(@parameter, @target);
        public System.Boolean CanExecute(System.Object parameter, System.Windows.IInputElement target) => __ProxyValue.CanExecute(@parameter, @target);
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}