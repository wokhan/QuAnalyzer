namespace System.Windows.Controls
{
    using Uno.UI.Generic;

    public class ValidationError : Proxy<global::Windows.UI.Xaml.Controls.ValidationError>
    {
        public System.Windows.Controls.ValidationRule RuleInError
        {
            get => __ProxyValue.RuleInError;
            set => __ProxyValue.RuleInError = value;
        }

        public System.Object ErrorContent
        {
            get => __ProxyValue.ErrorContent;
            set => __ProxyValue.ErrorContent = value;
        }

        public System.Exception Exception
        {
            get => __ProxyValue.Exception;
            set => __ProxyValue.Exception = value;
        }

        public System.Object BindingInError
        {
            get => __ProxyValue.BindingInError;
        }

        public ValidationError(System.Windows.Controls.ValidationRule @ruleInError, System.Object @bindingInError, System.Object @errorContent, System.Exception @exception): base(@ruleInError, @bindingInError, @errorContent, @exception)
        {
        }

        public ValidationError(System.Windows.Controls.ValidationRule @ruleInError, System.Object @bindingInError): base(@ruleInError, @bindingInError)
        {
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}