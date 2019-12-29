namespace System.Windows.Controls
{
    using Uno.UI.Generic;

    public class TextChange : Proxy<global::Windows.UI.Xaml.Controls.TextChange>
    {
        public System.Int32 Offset
        {
            get => __ProxyValue.Offset;
        }

        public System.Int32 AddedLength
        {
            get => __ProxyValue.AddedLength;
        }

        public System.Int32 RemovedLength
        {
            get => __ProxyValue.RemovedLength;
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}