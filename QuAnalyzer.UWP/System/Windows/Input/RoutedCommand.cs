namespace System.Windows.Input
{
    using Uno.UI.Generic;

    public class RoutedCommand : Proxy<global::Windows.UI.Xaml.Input.RoutedCommand>
    {
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

        public RoutedCommand(): base()
        {
        }

        public RoutedCommand(System.String @name, System.Type @ownerType): base(@name, @ownerType)
        {
        }

        public RoutedCommand(System.String @name, System.Type @ownerType, System.Windows.Input.InputGestureCollection @inputGestures): base(@name, @ownerType, @inputGestures)
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