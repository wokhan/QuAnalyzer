namespace System.Windows.Controls
{
    using Uno.UI.Generic;

    public class GroupStyle : Proxy<global::Windows.UI.Xaml.Controls.GroupStyle>
    {
        public System.Windows.Controls.ItemsPanelTemplate Panel
        {
            get => __ProxyValue.Panel;
            set => __ProxyValue.Panel = value;
        }

        public System.Windows.Style ContainerStyle
        {
            get => __ProxyValue.ContainerStyle;
            set => __ProxyValue.ContainerStyle = value;
        }

        public System.Windows.Controls.StyleSelector ContainerStyleSelector
        {
            get => __ProxyValue.ContainerStyleSelector;
            set => __ProxyValue.ContainerStyleSelector = value;
        }

        public System.Windows.DataTemplate HeaderTemplate
        {
            get => __ProxyValue.HeaderTemplate;
            set => __ProxyValue.HeaderTemplate = value;
        }

        public System.Windows.Controls.DataTemplateSelector HeaderTemplateSelector
        {
            get => __ProxyValue.HeaderTemplateSelector;
            set => __ProxyValue.HeaderTemplateSelector = value;
        }

        public System.String HeaderStringFormat
        {
            get => __ProxyValue.HeaderStringFormat;
            set => __ProxyValue.HeaderStringFormat = value;
        }

        public System.Boolean HidesIfEmpty
        {
            get => __ProxyValue.HidesIfEmpty;
            set => __ProxyValue.HidesIfEmpty = value;
        }

        public System.Int32 AlternationCount
        {
            get => __ProxyValue.AlternationCount;
            set => __ProxyValue.AlternationCount = value;
        }

        public static System.Windows.Controls.GroupStyle Default
        {
            get => __ProxyValue.Default;
        }

        public GroupStyle(): base()
        {
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}