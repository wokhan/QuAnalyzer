namespace System.Windows
{
    using Uno.UI.Generic;

    public class RoutedEventHandlerInfo : Proxy<global::Windows.UI.Xaml.RoutedEventHandlerInfo>
    {
        public System.Delegate Handler
        {
            get => __ProxyValue.Handler;
        }

        public System.Boolean InvokeHandledEventsToo
        {
            get => __ProxyValue.InvokeHandledEventsToo;
        }

        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public System.Boolean Equals(System.Windows.RoutedEventHandlerInfo handlerInfo) => __ProxyValue.Equals(@handlerInfo);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
        public static System.Boolean op_Equality(System.Windows.RoutedEventHandlerInfo handlerInfo1, System.Windows.RoutedEventHandlerInfo handlerInfo2) => Windows.UI.Xaml.RoutedEventHandlerInfo.op_Equality(@handlerInfo1, @handlerInfo2);
        public static System.Boolean op_Inequality(System.Windows.RoutedEventHandlerInfo handlerInfo1, System.Windows.RoutedEventHandlerInfo handlerInfo2) => Windows.UI.Xaml.RoutedEventHandlerInfo.op_Inequality(@handlerInfo1, @handlerInfo2);
        public override System.String ToString() => __ProxyValue.ToString();
    }
}