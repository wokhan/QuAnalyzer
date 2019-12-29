namespace System.Windows.Interop
{
    using Uno.UI.Generic;

    public class ComponentDispatcher : Proxy<global::Windows.UI.Xaml.Interop.ComponentDispatcher>
    {
        public static System.Boolean IsThreadModal
        {
            get => __ProxyValue.IsThreadModal;
        }

        public static System.Windows.Interop.MSG CurrentKeyboardMessage
        {
            get => __ProxyValue.CurrentKeyboardMessage;
        }

        public static void PushModal() => Windows.UI.Xaml.Interop.ComponentDispatcher.PushModal();
        public static void PopModal() => Windows.UI.Xaml.Interop.ComponentDispatcher.PopModal();
        public static void RaiseIdle() => Windows.UI.Xaml.Interop.ComponentDispatcher.RaiseIdle();
        public static System.Boolean RaiseThreadMessage(System.Windows.Interop.MSG msg) => Windows.UI.Xaml.Interop.ComponentDispatcher.RaiseThreadMessage(@msg);
        public static void add_ThreadIdle(System.EventHandler value) => Windows.UI.Xaml.Interop.ComponentDispatcher.add_ThreadIdle(@value);
        public static void remove_ThreadIdle(System.EventHandler value) => Windows.UI.Xaml.Interop.ComponentDispatcher.remove_ThreadIdle(@value);
        public static void add_ThreadFilterMessage(System.Windows.Interop.ThreadMessageEventHandler value) => Windows.UI.Xaml.Interop.ComponentDispatcher.add_ThreadFilterMessage(@value);
        public static void remove_ThreadFilterMessage(System.Windows.Interop.ThreadMessageEventHandler value) => Windows.UI.Xaml.Interop.ComponentDispatcher.remove_ThreadFilterMessage(@value);
        public static void add_ThreadPreprocessMessage(System.Windows.Interop.ThreadMessageEventHandler value) => Windows.UI.Xaml.Interop.ComponentDispatcher.add_ThreadPreprocessMessage(@value);
        public static void remove_ThreadPreprocessMessage(System.Windows.Interop.ThreadMessageEventHandler value) => Windows.UI.Xaml.Interop.ComponentDispatcher.remove_ThreadPreprocessMessage(@value);
        public static void add_EnterThreadModal(System.EventHandler value) => Windows.UI.Xaml.Interop.ComponentDispatcher.add_EnterThreadModal(@value);
        public static void remove_EnterThreadModal(System.EventHandler value) => Windows.UI.Xaml.Interop.ComponentDispatcher.remove_EnterThreadModal(@value);
        public static void add_LeaveThreadModal(System.EventHandler value) => Windows.UI.Xaml.Interop.ComponentDispatcher.add_LeaveThreadModal(@value);
        public static void remove_LeaveThreadModal(System.EventHandler value) => Windows.UI.Xaml.Interop.ComponentDispatcher.remove_LeaveThreadModal(@value);
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}