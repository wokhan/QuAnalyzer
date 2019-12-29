namespace System.Windows.Controls
{
    using Uno.UI.Generic;

    public class GridViewColumn : Proxy<global::Windows.UI.Xaml.Controls.GridViewColumn>
    {
        public System.Object Header
        {
            get => __ProxyValue.Header;
            set => __ProxyValue.Header = value;
        }

        public System.Windows.Style HeaderContainerStyle
        {
            get => __ProxyValue.HeaderContainerStyle;
            set => __ProxyValue.HeaderContainerStyle = value;
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

        public System.Windows.Data.BindingBase DisplayMemberBinding
        {
            get => __ProxyValue.DisplayMemberBinding;
            set => __ProxyValue.DisplayMemberBinding = value;
        }

        public System.Windows.DataTemplate CellTemplate
        {
            get => __ProxyValue.CellTemplate;
            set => __ProxyValue.CellTemplate = value;
        }

        public System.Windows.Controls.DataTemplateSelector CellTemplateSelector
        {
            get => __ProxyValue.CellTemplateSelector;
            set => __ProxyValue.CellTemplateSelector = value;
        }

        public System.Double Width
        {
            get => __ProxyValue.Width;
            set => __ProxyValue.Width = value;
        }

        public System.Double ActualWidth
        {
            get => __ProxyValue.ActualWidth;
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

        public GridViewColumn(): base()
        {
        }

        public override System.String ToString() => __ProxyValue.ToString();
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