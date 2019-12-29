namespace System.Windows.Controls
{
    using Uno.UI.Generic;

    public class ValidationResult : Proxy<global::Windows.UI.Xaml.Controls.ValidationResult>
    {
        public System.Boolean IsValid
        {
            get => __ProxyValue.IsValid;
        }

        public System.Object ErrorContent
        {
            get => __ProxyValue.ErrorContent;
        }

        public static System.Windows.Controls.ValidationResult ValidResult
        {
            get => __ProxyValue.ValidResult;
        }

        public ValidationResult(System.Boolean @isValid, System.Object @errorContent): base(@isValid, @errorContent)
        {
        }

        public static System.Boolean op_Equality(System.Windows.Controls.ValidationResult left, System.Windows.Controls.ValidationResult right) => Windows.UI.Xaml.Controls.ValidationResult.op_Equality(@left, @right);
        public static System.Boolean op_Inequality(System.Windows.Controls.ValidationResult left, System.Windows.Controls.ValidationResult right) => Windows.UI.Xaml.Controls.ValidationResult.op_Inequality(@left, @right);
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
        public override System.String ToString() => __ProxyValue.ToString();
    }
}