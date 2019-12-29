namespace System.Windows.Controls
{
    using Uno.UI.Generic;

    public class GridView : Proxy<global::Windows.UI.Xaml.Controls.GridView>
    {
        public static System.Windows.ResourceKey GridViewScrollViewerStyleKey
        {
            get => __ProxyValue.GridViewScrollViewerStyleKey;
        }

        public static System.Windows.ResourceKey GridViewStyleKey
        {
            get => __ProxyValue.GridViewStyleKey;
        }

        public static System.Windows.ResourceKey GridViewItemContainerStyleKey
        {
            get => __ProxyValue.GridViewItemContainerStyleKey;
        }

        public System.Windows.Controls.GridViewColumnCollection Columns
        {
            get => __ProxyValue.Columns;
        }

        public System.Windows.Style ColumnHeaderContainerStyle
        {
            get => __ProxyValue.ColumnHeaderContainerStyle;
            set => __ProxyValue.ColumnHeaderContainerStyle = value;
        }

        public System.Windows.DataTemplate ColumnHeaderTemplate
        {
            get => __ProxyValue.ColumnHeaderTemplate;
            set => __ProxyValue.ColumnHeaderTemplate = value;
        }

        public System.Windows.Controls.DataTemplateSelector ColumnHeaderTemplateSelector
        {
            get => __ProxyValue.ColumnHeaderTemplateSelector;
            set => __ProxyValue.ColumnHeaderTemplateSelector = value;
        }

        public System.String ColumnHeaderStringFormat
        {
            get => __ProxyValue.ColumnHeaderStringFormat;
            set => __ProxyValue.ColumnHeaderStringFormat = value;
        }

        public System.Boolean AllowsColumnReorder
        {
            get => __ProxyValue.AllowsColumnReorder;
            set => __ProxyValue.AllowsColumnReorder = value;
        }

        public System.Windows.Controls.ContextMenu ColumnHeaderContextMenu
        {
            get => __ProxyValue.ColumnHeaderContextMenu;
            set => __ProxyValue.ColumnHeaderContextMenu = value;
        }

        public System.Object ColumnHeaderToolTip
        {
            get => __ProxyValue.ColumnHeaderToolTip;
            set => __ProxyValue.ColumnHeaderToolTip = value;
        }

        public System.Windows.DependencyObjectType DependencyObjectType
        {
            get => __ProxyValue.DependencyObjectType;
        }

        public System.Boolean IsSealed
        {
            get => __ProxyValue.IsSealed;
        }

        public System.Windows.Threading.Dispatcher Dispatcher
        {
            get => __ProxyValue.Dispatcher;
        }

        public GridView(): base()
        {
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public static System.Windows.Controls.GridViewColumnCollection GetColumnCollection(System.Windows.DependencyObject element) => Windows.UI.Xaml.Controls.GridView.GetColumnCollection(@element);
        public static void SetColumnCollection(System.Windows.DependencyObject element, System.Windows.Controls.GridViewColumnCollection collection) => Windows.UI.Xaml.Controls.GridView.SetColumnCollection(@element, @collection);
        public static System.Boolean ShouldSerializeColumnCollection(System.Windows.DependencyObject obj) => Windows.UI.Xaml.Controls.GridView.ShouldSerializeColumnCollection(@obj);
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
        public System.Object GetValue(System.Windows.DependencyProperty dp) => __ProxyValue.GetValue(@dp);
        public void SetValue(System.Windows.DependencyProperty dp, System.Object value) => __ProxyValue.SetValue(@dp, @value);
        public void SetCurrentValue(System.Windows.DependencyProperty dp, System.Object value) => __ProxyValue.SetCurrentValue(@dp, @value);
        public void SetValue(System.Windows.DependencyPropertyKey key, System.Object value) => __ProxyValue.SetValue(@key, @value);
        public void ClearValue(System.Windows.DependencyProperty dp) => __ProxyValue.ClearValue(@dp);
        public void ClearValue(System.Windows.DependencyPropertyKey key) => __ProxyValue.ClearValue(@key);
        public void CoerceValue(System.Windows.DependencyProperty dp) => __ProxyValue.CoerceValue(@dp);
        public void InvalidateProperty(System.Windows.DependencyProperty dp) => __ProxyValue.InvalidateProperty(@dp);
        public System.Object ReadLocalValue(System.Windows.DependencyProperty dp) => __ProxyValue.ReadLocalValue(@dp);
        public System.Windows.LocalValueEnumerator GetLocalValueEnumerator() => __ProxyValue.GetLocalValueEnumerator();
        public System.Boolean CheckAccess() => __ProxyValue.CheckAccess();
        public void VerifyAccess() => __ProxyValue.VerifyAccess();
    }
}