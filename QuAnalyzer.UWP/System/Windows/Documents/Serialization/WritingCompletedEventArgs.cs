namespace System.Windows.Documents.Serialization
{
    using Uno.UI.Generic;

    public class WritingCompletedEventArgs : Proxy<global::Windows.UI.Xaml.Documents.Serialization.WritingCompletedEventArgs>
    {
        public System.Boolean Cancelled
        {
            get => __ProxyValue.Cancelled;
        }

        public System.Exception Error
        {
            get => __ProxyValue.Error;
        }

        public System.Object UserState
        {
            get => __ProxyValue.UserState;
        }

        public WritingCompletedEventArgs(System.Boolean @cancelled, System.Object @state, System.Exception @exception): base(@cancelled, @state, @exception)
        {
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}