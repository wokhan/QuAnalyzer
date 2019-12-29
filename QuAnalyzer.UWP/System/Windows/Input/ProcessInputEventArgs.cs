namespace System.Windows.Input
{
    using Uno.UI.Generic;

    public class ProcessInputEventArgs : Proxy<global::Windows.UI.Xaml.Input.ProcessInputEventArgs>
    {
        public System.Windows.Input.StagingAreaInputItem StagingItem
        {
            get => __ProxyValue.StagingItem;
        }

        public System.Windows.Input.InputManager InputManager
        {
            get => __ProxyValue.InputManager;
        }

        public System.Windows.Input.StagingAreaInputItem PushInput(System.Windows.Input.InputEventArgs input, System.Windows.Input.StagingAreaInputItem promote) => __ProxyValue.PushInput(@input, @promote);
        public System.Windows.Input.StagingAreaInputItem PushInput(System.Windows.Input.StagingAreaInputItem input) => __ProxyValue.PushInput(@input);
        public System.Windows.Input.StagingAreaInputItem PopInput() => __ProxyValue.PopInput();
        public System.Windows.Input.StagingAreaInputItem PeekInput() => __ProxyValue.PeekInput();
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}