namespace System.Windows.Input
{
    using Uno.UI.Generic;

    public class MouseGesture : Proxy<global::Windows.UI.Xaml.Input.MouseGesture>
    {
        public System.Windows.Input.MouseAction MouseAction
        {
            get => __ProxyValue.MouseAction;
            set => __ProxyValue.MouseAction = value;
        }

        public System.Windows.Input.ModifierKeys Modifiers
        {
            get => __ProxyValue.Modifiers;
            set => __ProxyValue.Modifiers = value;
        }

        public MouseGesture(): base()
        {
        }

        public MouseGesture(System.Windows.Input.MouseAction @mouseAction): base(@mouseAction)
        {
        }

        public MouseGesture(System.Windows.Input.MouseAction @mouseAction, System.Windows.Input.ModifierKeys @modifiers): base(@mouseAction, @modifiers)
        {
        }

        public System.Boolean Matches(System.Object targetElement, System.Windows.Input.InputEventArgs inputEventArgs) => __ProxyValue.Matches(@targetElement, @inputEventArgs);
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}