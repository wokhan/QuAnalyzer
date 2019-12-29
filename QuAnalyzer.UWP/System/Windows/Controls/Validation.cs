namespace System.Windows.Controls
{
    using Uno.UI.Generic;

    public class Validation : Proxy<global::Windows.UI.Xaml.Controls.Validation>
    {
        public static void AddErrorHandler(System.Windows.DependencyObject element, System.EventHandler<System.Windows.Controls.ValidationErrorEventArgs> handler) => Windows.UI.Xaml.Controls.Validation.AddErrorHandler(@element, @handler);
        public static void RemoveErrorHandler(System.Windows.DependencyObject element, System.EventHandler<System.Windows.Controls.ValidationErrorEventArgs> handler) => Windows.UI.Xaml.Controls.Validation.RemoveErrorHandler(@element, @handler);
        public static System.Collections.ObjectModel.ReadOnlyObservableCollection<System.Windows.Controls.ValidationError> GetErrors(System.Windows.DependencyObject element) => Windows.UI.Xaml.Controls.Validation.GetErrors(@element);
        public static System.Boolean GetHasError(System.Windows.DependencyObject element) => Windows.UI.Xaml.Controls.Validation.GetHasError(@element);
        public static System.Windows.Controls.ControlTemplate GetErrorTemplate(System.Windows.DependencyObject element) => Windows.UI.Xaml.Controls.Validation.GetErrorTemplate(@element);
        public static void SetErrorTemplate(System.Windows.DependencyObject element, System.Windows.Controls.ControlTemplate value) => Windows.UI.Xaml.Controls.Validation.SetErrorTemplate(@element, @value);
        public static System.Windows.DependencyObject GetValidationAdornerSite(System.Windows.DependencyObject element) => Windows.UI.Xaml.Controls.Validation.GetValidationAdornerSite(@element);
        public static void SetValidationAdornerSite(System.Windows.DependencyObject element, System.Windows.DependencyObject value) => Windows.UI.Xaml.Controls.Validation.SetValidationAdornerSite(@element, @value);
        public static System.Windows.DependencyObject GetValidationAdornerSiteFor(System.Windows.DependencyObject element) => Windows.UI.Xaml.Controls.Validation.GetValidationAdornerSiteFor(@element);
        public static void SetValidationAdornerSiteFor(System.Windows.DependencyObject element, System.Windows.DependencyObject value) => Windows.UI.Xaml.Controls.Validation.SetValidationAdornerSiteFor(@element, @value);
        public static void MarkInvalid(System.Windows.Data.BindingExpressionBase bindingExpression, System.Windows.Controls.ValidationError validationError) => Windows.UI.Xaml.Controls.Validation.MarkInvalid(@bindingExpression, @validationError);
        public static void ClearInvalid(System.Windows.Data.BindingExpressionBase bindingExpression) => Windows.UI.Xaml.Controls.Validation.ClearInvalid(@bindingExpression);
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}