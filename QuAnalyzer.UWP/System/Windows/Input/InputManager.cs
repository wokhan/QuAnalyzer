namespace System.Windows.Input
{
    using Uno.UI.Generic;

    public class InputManager : Proxy<global::Windows.UI.Xaml.Input.InputManager>
    {
        public static System.Windows.Input.InputManager Current
        {
            get => __ProxyValue.Current;
        }

        public System.Collections.ICollection InputProviders
        {
            get => __ProxyValue.InputProviders;
        }

        public System.Windows.Input.KeyboardDevice PrimaryKeyboardDevice
        {
            get => __ProxyValue.PrimaryKeyboardDevice;
        }

        public System.Windows.Input.MouseDevice PrimaryMouseDevice
        {
            get => __ProxyValue.PrimaryMouseDevice;
        }

        public System.Windows.Input.InputDevice MostRecentInputDevice
        {
            get => __ProxyValue.MostRecentInputDevice;
        }

        public System.Boolean IsInMenuMode
        {
            get => __ProxyValue.IsInMenuMode;
        }

        public System.Windows.Threading.Dispatcher Dispatcher
        {
            get => __ProxyValue.Dispatcher;
        }

        public void add_PreProcessInput(System.Windows.Input.PreProcessInputEventHandler value) => __ProxyValue.add_PreProcessInput(@value);
        public void remove_PreProcessInput(System.Windows.Input.PreProcessInputEventHandler value) => __ProxyValue.remove_PreProcessInput(@value);
        public void add_PreNotifyInput(System.Windows.Input.NotifyInputEventHandler value) => __ProxyValue.add_PreNotifyInput(@value);
        public void remove_PreNotifyInput(System.Windows.Input.NotifyInputEventHandler value) => __ProxyValue.remove_PreNotifyInput(@value);
        public void add_PostNotifyInput(System.Windows.Input.NotifyInputEventHandler value) => __ProxyValue.add_PostNotifyInput(@value);
        public void remove_PostNotifyInput(System.Windows.Input.NotifyInputEventHandler value) => __ProxyValue.remove_PostNotifyInput(@value);
        public void add_PostProcessInput(System.Windows.Input.ProcessInputEventHandler value) => __ProxyValue.add_PostProcessInput(@value);
        public void remove_PostProcessInput(System.Windows.Input.ProcessInputEventHandler value) => __ProxyValue.remove_PostProcessInput(@value);
        public void PushMenuMode(System.Windows.PresentationSource menuSite) => __ProxyValue.PushMenuMode(@menuSite);
        public void PopMenuMode(System.Windows.PresentationSource menuSite) => __ProxyValue.PopMenuMode(@menuSite);
        public void add_EnterMenuMode(System.EventHandler value) => __ProxyValue.add_EnterMenuMode(@value);
        public void remove_EnterMenuMode(System.EventHandler value) => __ProxyValue.remove_EnterMenuMode(@value);
        public void add_LeaveMenuMode(System.EventHandler value) => __ProxyValue.add_LeaveMenuMode(@value);
        public void remove_LeaveMenuMode(System.EventHandler value) => __ProxyValue.remove_LeaveMenuMode(@value);
        public void add_HitTestInvalidatedAsync(System.EventHandler value) => __ProxyValue.add_HitTestInvalidatedAsync(@value);
        public void remove_HitTestInvalidatedAsync(System.EventHandler value) => __ProxyValue.remove_HitTestInvalidatedAsync(@value);
        public System.Boolean ProcessInput(System.Windows.Input.InputEventArgs input) => __ProxyValue.ProcessInput(@input);
        public System.Boolean CheckAccess() => __ProxyValue.CheckAccess();
        public void VerifyAccess() => __ProxyValue.VerifyAccess();
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}