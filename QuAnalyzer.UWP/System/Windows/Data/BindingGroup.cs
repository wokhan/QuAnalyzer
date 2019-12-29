namespace System.Windows.Data
{
    using Uno.UI.Generic;

    public class BindingGroup : Proxy<global::Windows.UI.Xaml.Data.BindingGroup>
    {
        public System.Windows.DependencyObject Owner
        {
            get => __ProxyValue.Owner;
        }

        public System.Collections.ObjectModel.Collection<System.Windows.Controls.ValidationRule> ValidationRules
        {
            get => __ProxyValue.ValidationRules;
        }

        public System.Collections.ObjectModel.Collection<System.Windows.Data.BindingExpressionBase> BindingExpressions
        {
            get => __ProxyValue.BindingExpressions;
        }

        public System.String Name
        {
            get => __ProxyValue.Name;
            set => __ProxyValue.Name = value;
        }

        public System.Boolean NotifyOnValidationError
        {
            get => __ProxyValue.NotifyOnValidationError;
            set => __ProxyValue.NotifyOnValidationError = value;
        }

        public System.Boolean ValidatesOnNotifyDataError
        {
            get => __ProxyValue.ValidatesOnNotifyDataError;
            set => __ProxyValue.ValidatesOnNotifyDataError = value;
        }

        public System.Boolean SharesProposedValues
        {
            get => __ProxyValue.SharesProposedValues;
            set => __ProxyValue.SharesProposedValues = value;
        }

        public System.Boolean CanRestoreValues
        {
            get => __ProxyValue.CanRestoreValues;
        }

        public System.Collections.IList Items
        {
            get => __ProxyValue.Items;
        }

        public System.Boolean IsDirty
        {
            get => __ProxyValue.IsDirty;
        }

        public System.Boolean HasValidationError
        {
            get => __ProxyValue.HasValidationError;
        }

        public System.Collections.ObjectModel.ReadOnlyCollection<System.Windows.Controls.ValidationError> ValidationErrors
        {
            get => __ProxyValue.ValidationErrors;
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

        public BindingGroup(): base()
        {
        }

        public void BeginEdit() => __ProxyValue.BeginEdit();
        public System.Boolean CommitEdit() => __ProxyValue.CommitEdit();
        public void CancelEdit() => __ProxyValue.CancelEdit();
        public System.Boolean ValidateWithoutUpdate() => __ProxyValue.ValidateWithoutUpdate();
        public System.Boolean UpdateSources() => __ProxyValue.UpdateSources();
        public System.Object GetValue(System.Object item, System.String propertyName) => __ProxyValue.GetValue(@item, @propertyName);
        public System.Boolean TryGetValue(System.Object item, System.String propertyName, out System.Object value) => __ProxyValue.TryGetValue(@item, @propertyName, @value);
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
        public override System.String ToString() => __ProxyValue.ToString();
    }
}