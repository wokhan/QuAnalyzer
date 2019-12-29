namespace System.Windows.Ink
{
    using Uno.UI.Generic;

    public class GestureRecognitionResult : Proxy<global::Windows.UI.Xaml.Ink.GestureRecognitionResult>
    {
        public System.Windows.Ink.RecognitionConfidence RecognitionConfidence
        {
            get => __ProxyValue.RecognitionConfidence;
        }

        public System.Windows.Ink.ApplicationGesture ApplicationGesture
        {
            get => __ProxyValue.ApplicationGesture;
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}