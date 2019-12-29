namespace System.Windows.Input
{
    using Uno.UI.Generic;

    public class IManipulator : Proxy<global::Windows.UI.Xaml.Input.IManipulator>
    {
        public System.Int32 Id
        {
            get => __ProxyValue.Id;
        }

        public System.Windows.Point GetPosition(System.Windows.IInputElement relativeTo) => __ProxyValue.GetPosition(@relativeTo);
        public void add_Updated(System.EventHandler value) => __ProxyValue.add_Updated(@value);
        public void remove_Updated(System.EventHandler value) => __ProxyValue.remove_Updated(@value);
        public void ManipulationEnded(System.Boolean cancel) => __ProxyValue.ManipulationEnded(@cancel);
    }
}