namespace System.Windows.Diagnostics
{
    using Uno.UI.Generic;

    public class VisualTreeChangeEventArgs : Proxy<global::Windows.UI.Xaml.Diagnostics.VisualTreeChangeEventArgs>
    {
        public System.Windows.DependencyObject Parent
        {
            get => __ProxyValue.Parent;
        }

        public System.Windows.DependencyObject Child
        {
            get => __ProxyValue.Child;
        }

        public System.Int32 ChildIndex
        {
            get => __ProxyValue.ChildIndex;
        }

        public System.Windows.Diagnostics.VisualTreeChangeType ChangeType
        {
            get => __ProxyValue.ChangeType;
        }

        public VisualTreeChangeEventArgs(System.Windows.DependencyObject @parent, System.Windows.DependencyObject @child, System.Int32 @childIndex, System.Windows.Diagnostics.VisualTreeChangeType @changeType): base(@parent, @child, @childIndex, @changeType)
        {
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}