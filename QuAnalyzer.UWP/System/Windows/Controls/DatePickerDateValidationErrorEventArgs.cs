namespace System.Windows.Controls
{
    using Uno.UI.Generic;

    public class DatePickerDateValidationErrorEventArgs : Proxy<global::Windows.UI.Xaml.Controls.DatePickerDateValidationErrorEventArgs>
    {
        public System.Exception Exception
        {
            get => __ProxyValue.Exception;
        }

        public System.String Text
        {
            get => __ProxyValue.Text;
        }

        public System.Boolean ThrowException
        {
            get => __ProxyValue.ThrowException;
            set => __ProxyValue.ThrowException = value;
        }

        public DatePickerDateValidationErrorEventArgs(System.Exception @exception, System.String @text): base(@exception, @text)
        {
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}