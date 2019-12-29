namespace System.Windows
{
    using Uno.UI.Generic;

    public class HierarchicalDataTemplate : Proxy<global::Windows.UI.Xaml.HierarchicalDataTemplate>
    {
        public System.Windows.Data.BindingBase ItemsSource
        {
            get => __ProxyValue.ItemsSource;
            set => __ProxyValue.ItemsSource = value;
        }

        public System.Windows.DataTemplate ItemTemplate
        {
            get => __ProxyValue.ItemTemplate;
            set => __ProxyValue.ItemTemplate = value;
        }

        public System.Windows.Controls.DataTemplateSelector ItemTemplateSelector
        {
            get => __ProxyValue.ItemTemplateSelector;
            set => __ProxyValue.ItemTemplateSelector = value;
        }

        public System.Windows.Style ItemContainerStyle
        {
            get => __ProxyValue.ItemContainerStyle;
            set => __ProxyValue.ItemContainerStyle = value;
        }

        public System.Windows.Controls.StyleSelector ItemContainerStyleSelector
        {
            get => __ProxyValue.ItemContainerStyleSelector;
            set => __ProxyValue.ItemContainerStyleSelector = value;
        }

        public System.String ItemStringFormat
        {
            get => __ProxyValue.ItemStringFormat;
            set => __ProxyValue.ItemStringFormat = value;
        }

        public System.Int32 AlternationCount
        {
            get => __ProxyValue.AlternationCount;
            set => __ProxyValue.AlternationCount = value;
        }

        public System.Windows.Data.BindingGroup ItemBindingGroup
        {
            get => __ProxyValue.ItemBindingGroup;
            set => __ProxyValue.ItemBindingGroup = value;
        }

        public System.Object DataType
        {
            get => __ProxyValue.DataType;
            set => __ProxyValue.DataType = value;
        }

        public System.Windows.TriggerCollection Triggers
        {
            get => __ProxyValue.Triggers;
        }

        public System.Object DataTemplateKey
        {
            get => __ProxyValue.DataTemplateKey;
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

        public HierarchicalDataTemplate(): base()
        {
        }

        public HierarchicalDataTemplate(System.Object @dataType): base(@dataType)
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