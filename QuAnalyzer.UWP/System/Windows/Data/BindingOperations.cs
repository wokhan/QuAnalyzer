namespace System.Windows.Data
{
    using Uno.UI.Generic;

    public class BindingOperations : Proxy<global::Windows.UI.Xaml.Data.BindingOperations>
    {
        public static System.Object DisconnectedSource
        {
            get => __ProxyValue.DisconnectedSource;
        }

        public static System.Windows.Data.BindingExpressionBase SetBinding(System.Windows.DependencyObject target, System.Windows.DependencyProperty dp, System.Windows.Data.BindingBase binding) => Windows.UI.Xaml.Data.BindingOperations.SetBinding(@target, @dp, @binding);
        public static System.Windows.Data.BindingBase GetBindingBase(System.Windows.DependencyObject target, System.Windows.DependencyProperty dp) => Windows.UI.Xaml.Data.BindingOperations.GetBindingBase(@target, @dp);
        public static System.Windows.Data.Binding GetBinding(System.Windows.DependencyObject target, System.Windows.DependencyProperty dp) => Windows.UI.Xaml.Data.BindingOperations.GetBinding(@target, @dp);
        public static System.Windows.Data.PriorityBinding GetPriorityBinding(System.Windows.DependencyObject target, System.Windows.DependencyProperty dp) => Windows.UI.Xaml.Data.BindingOperations.GetPriorityBinding(@target, @dp);
        public static System.Windows.Data.MultiBinding GetMultiBinding(System.Windows.DependencyObject target, System.Windows.DependencyProperty dp) => Windows.UI.Xaml.Data.BindingOperations.GetMultiBinding(@target, @dp);
        public static System.Windows.Data.BindingExpressionBase GetBindingExpressionBase(System.Windows.DependencyObject target, System.Windows.DependencyProperty dp) => Windows.UI.Xaml.Data.BindingOperations.GetBindingExpressionBase(@target, @dp);
        public static System.Windows.Data.BindingExpression GetBindingExpression(System.Windows.DependencyObject target, System.Windows.DependencyProperty dp) => Windows.UI.Xaml.Data.BindingOperations.GetBindingExpression(@target, @dp);
        public static System.Windows.Data.MultiBindingExpression GetMultiBindingExpression(System.Windows.DependencyObject target, System.Windows.DependencyProperty dp) => Windows.UI.Xaml.Data.BindingOperations.GetMultiBindingExpression(@target, @dp);
        public static System.Windows.Data.PriorityBindingExpression GetPriorityBindingExpression(System.Windows.DependencyObject target, System.Windows.DependencyProperty dp) => Windows.UI.Xaml.Data.BindingOperations.GetPriorityBindingExpression(@target, @dp);
        public static void ClearBinding(System.Windows.DependencyObject target, System.Windows.DependencyProperty dp) => Windows.UI.Xaml.Data.BindingOperations.ClearBinding(@target, @dp);
        public static void ClearAllBindings(System.Windows.DependencyObject target) => Windows.UI.Xaml.Data.BindingOperations.ClearAllBindings(@target);
        public static System.Boolean IsDataBound(System.Windows.DependencyObject target, System.Windows.DependencyProperty dp) => Windows.UI.Xaml.Data.BindingOperations.IsDataBound(@target, @dp);
        public static void EnableCollectionSynchronization(System.Collections.IEnumerable collection, System.Object context, System.Windows.Data.CollectionSynchronizationCallback synchronizationCallback) => Windows.UI.Xaml.Data.BindingOperations.EnableCollectionSynchronization(@collection, @context, @synchronizationCallback);
        public static void EnableCollectionSynchronization(System.Collections.IEnumerable collection, System.Object lockObject) => Windows.UI.Xaml.Data.BindingOperations.EnableCollectionSynchronization(@collection, @lockObject);
        public static void DisableCollectionSynchronization(System.Collections.IEnumerable collection) => Windows.UI.Xaml.Data.BindingOperations.DisableCollectionSynchronization(@collection);
        public static void AccessCollection(System.Collections.IEnumerable collection, System.Action accessMethod, System.Boolean writeAccess) => Windows.UI.Xaml.Data.BindingOperations.AccessCollection(@collection, @accessMethod, @writeAccess);
        public static System.Collections.ObjectModel.ReadOnlyCollection<System.Windows.Data.BindingExpressionBase> GetSourceUpdatingBindings(System.Windows.DependencyObject root) => Windows.UI.Xaml.Data.BindingOperations.GetSourceUpdatingBindings(@root);
        public static System.Collections.ObjectModel.ReadOnlyCollection<System.Windows.Data.BindingGroup> GetSourceUpdatingBindingGroups(System.Windows.DependencyObject root) => Windows.UI.Xaml.Data.BindingOperations.GetSourceUpdatingBindingGroups(@root);
        public static void add_CollectionRegistering(System.EventHandler<System.Windows.Data.CollectionRegisteringEventArgs> value) => Windows.UI.Xaml.Data.BindingOperations.add_CollectionRegistering(@value);
        public static void remove_CollectionRegistering(System.EventHandler<System.Windows.Data.CollectionRegisteringEventArgs> value) => Windows.UI.Xaml.Data.BindingOperations.remove_CollectionRegistering(@value);
        public static void add_CollectionViewRegistering(System.EventHandler<System.Windows.Data.CollectionViewRegisteringEventArgs> value) => Windows.UI.Xaml.Data.BindingOperations.add_CollectionViewRegistering(@value);
        public static void remove_CollectionViewRegistering(System.EventHandler<System.Windows.Data.CollectionViewRegisteringEventArgs> value) => Windows.UI.Xaml.Data.BindingOperations.remove_CollectionViewRegistering(@value);
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}