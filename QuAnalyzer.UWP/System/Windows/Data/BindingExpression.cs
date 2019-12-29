﻿namespace System.Windows.Data
{
    using Uno.UI.Generic;

    public class BindingExpression : Proxy<global::Windows.UI.Xaml.Data.BindingExpression>
    {
        public System.Windows.Data.Binding ParentBinding
        {
            get => __ProxyValue.ParentBinding;
        }

        public System.Object DataItem
        {
            get => __ProxyValue.DataItem;
        }

        public System.Object ResolvedSource
        {
            get => __ProxyValue.ResolvedSource;
        }

        public System.String ResolvedSourcePropertyName
        {
            get => __ProxyValue.ResolvedSourcePropertyName;
        }

        public System.Windows.DependencyObject Target
        {
            get => __ProxyValue.Target;
        }

        public System.Windows.DependencyProperty TargetProperty
        {
            get => __ProxyValue.TargetProperty;
        }

        public System.Windows.Data.BindingBase ParentBindingBase
        {
            get => __ProxyValue.ParentBindingBase;
        }

        public System.Windows.Data.BindingGroup BindingGroup
        {
            get => __ProxyValue.BindingGroup;
        }

        public System.Windows.Data.BindingStatus Status
        {
            get => __ProxyValue.Status;
        }

        public System.Windows.Controls.ValidationError ValidationError
        {
            get => __ProxyValue.ValidationError;
        }

        public System.Boolean HasError
        {
            get => __ProxyValue.HasError;
        }

        public System.Boolean HasValidationError
        {
            get => __ProxyValue.HasValidationError;
        }

        public System.Boolean IsDirty
        {
            get => __ProxyValue.IsDirty;
        }

        public System.Collections.ObjectModel.ReadOnlyCollection<System.Windows.Controls.ValidationError> ValidationErrors
        {
            get => __ProxyValue.ValidationErrors;
        }

        public void UpdateSource() => __ProxyValue.UpdateSource();
        public void UpdateTarget() => __ProxyValue.UpdateTarget();
        public System.Boolean ValidateWithoutUpdate() => __ProxyValue.ValidateWithoutUpdate();
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}