namespace System.Windows.Navigation
{
    using Uno.UI.Generic;

    public class ReturnEventArgs`1<T> : Proxy<global::Windows.UI.Xaml.Navigation.ReturnEventArgs<T>>
    {
        public T Result
        {
            get => __ProxyValue.Result;
            set => __ProxyValue.Result = value;
        }

        public ReturnEventArgs`1(): base()
        {
        }

        public ReturnEventArgs`1(T @result): base(@result)
        {
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}