namespace System.Windows
{
    using Uno.UI.Generic;

    public class FrameworkElementFactory : Proxy<global::Windows.UI.Xaml.FrameworkElementFactory>
    {
        public System.Type Type
        {
            get => __ProxyValue.Type;
            set => __ProxyValue.Type = value;
        }

        public System.String Text
        {
            get => __ProxyValue.Text;
            set => __ProxyValue.Text = value;
        }

        public System.String Name
        {
            get => __ProxyValue.Name;
            set => __ProxyValue.Name = value;
        }

        public System.Boolean IsSealed
        {
            get => __ProxyValue.IsSealed;
        }

        public System.Windows.FrameworkElementFactory Parent
        {
            get => __ProxyValue.Parent;
        }

        public System.Windows.FrameworkElementFactory FirstChild
        {
            get => __ProxyValue.FirstChild;
        }

        public System.Windows.FrameworkElementFactory NextSibling
        {
            get => __ProxyValue.NextSibling;
        }

        public FrameworkElementFactory(): base()
        {
        }

        public FrameworkElementFactory(System.Type @type): base(@type)
        {
        }

        public FrameworkElementFactory(System.String @text): base(@text)
        {
        }

        public FrameworkElementFactory(System.Type @type, System.String @name): base(@type, @name)
        {
        }

        public void AppendChild(System.Windows.FrameworkElementFactory child) => __ProxyValue.AppendChild(@child);
        public void SetValue(System.Windows.DependencyProperty dp, System.Object value) => __ProxyValue.SetValue(@dp, @value);
        public void SetBinding(System.Windows.DependencyProperty dp, System.Windows.Data.BindingBase binding) => __ProxyValue.SetBinding(@dp, @binding);
        public void SetResourceReference(System.Windows.DependencyProperty dp, System.Object name) => __ProxyValue.SetResourceReference(@dp, @name);
        public void AddHandler(System.Windows.RoutedEvent routedEvent, System.Delegate handler) => __ProxyValue.AddHandler(@routedEvent, @handler);
        public void AddHandler(System.Windows.RoutedEvent routedEvent, System.Delegate handler, System.Boolean handledEventsToo) => __ProxyValue.AddHandler(@routedEvent, @handler, @handledEventsToo);
        public void RemoveHandler(System.Windows.RoutedEvent routedEvent, System.Delegate handler) => __ProxyValue.RemoveHandler(@routedEvent, @handler);
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}