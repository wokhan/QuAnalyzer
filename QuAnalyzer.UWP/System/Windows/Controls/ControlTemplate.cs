namespace System.Windows.Controls
{
    using Uno.UI.Generic;

    public class ControlTemplate : Proxy<global::Windows.UI.Xaml.Controls.ControlTemplate>
    {
        public System.Type TargetType
        {
            get => __ProxyValue.TargetType;
            set => __ProxyValue.TargetType = value;
        }

        public System.Windows.TriggerCollection Triggers
        {
            get => __ProxyValue.Triggers;
        }

        public System.Boolean IsSealed
        {
            get => __ProxyValue.IsSealed;
        }

        public System.Windows.FrameworkElementFactory VisualTree
        {
            get => __ProxyValue.VisualTree;
            set => __ProxyValue.VisualTree = value;
        }

        public System.Windows.TemplateContent Template
        {
            get => __ProxyValue.Template;
            set => __ProxyValue.Template = value;
        }

        public System.Windows.ResourceDictionary Resources
        {
            get => __ProxyValue.Resources;
            set => __ProxyValue.Resources = value;
        }

        public System.Boolean HasContent
        {
            get => __ProxyValue.HasContent;
        }

        public System.Windows.Threading.Dispatcher Dispatcher
        {
            get => __ProxyValue.Dispatcher;
        }

        public ControlTemplate(): base()
        {
        }

        public ControlTemplate(System.Type @targetType): base(@targetType)
        {
        }

        public System.Boolean ShouldSerializeVisualTree() => __ProxyValue.ShouldSerializeVisualTree();
        public System.Object FindName(System.String name, System.Windows.FrameworkElement templatedParent) => __ProxyValue.FindName(@name, @templatedParent);
        public void RegisterName(System.String name, System.Object scopedElement) => __ProxyValue.RegisterName(@name, @scopedElement);
        public void UnregisterName(System.String name) => __ProxyValue.UnregisterName(@name);
        public void Seal() => __ProxyValue.Seal();
        public System.Windows.DependencyObject LoadContent() => __ProxyValue.LoadContent();
        public System.Boolean ShouldSerializeResources(System.Windows.Markup.XamlDesignerSerializationManager manager) => __ProxyValue.ShouldSerializeResources(@manager);
        public System.Boolean CheckAccess() => __ProxyValue.CheckAccess();
        public void VerifyAccess() => __ProxyValue.VerifyAccess();
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}