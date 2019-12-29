namespace System.Windows.Documents
{
    using Uno.UI.Generic;

    public class FrameworkRichTextComposition : Proxy<global::Windows.UI.Xaml.Documents.FrameworkRichTextComposition>
    {
        public System.Windows.Documents.TextPointer ResultStart
        {
            get => __ProxyValue.ResultStart;
        }

        public System.Windows.Documents.TextPointer ResultEnd
        {
            get => __ProxyValue.ResultEnd;
        }

        public System.Windows.Documents.TextPointer CompositionStart
        {
            get => __ProxyValue.CompositionStart;
        }

        public System.Windows.Documents.TextPointer CompositionEnd
        {
            get => __ProxyValue.CompositionEnd;
        }

        public System.Int32 ResultOffset
        {
            get => __ProxyValue.ResultOffset;
        }

        public System.Int32 ResultLength
        {
            get => __ProxyValue.ResultLength;
        }

        public System.Int32 CompositionOffset
        {
            get => __ProxyValue.CompositionOffset;
        }

        public System.Int32 CompositionLength
        {
            get => __ProxyValue.CompositionLength;
        }

        public System.String Text
        {
            get => __ProxyValue.Text;
        }

        public System.String CompositionText
        {
            get => __ProxyValue.CompositionText;
        }

        public System.String SystemText
        {
            get => __ProxyValue.SystemText;
        }

        public System.String ControlText
        {
            get => __ProxyValue.ControlText;
        }

        public System.String SystemCompositionText
        {
            get => __ProxyValue.SystemCompositionText;
        }

        public System.Windows.Input.TextCompositionAutoComplete AutoComplete
        {
            get => __ProxyValue.AutoComplete;
        }

        public System.Windows.Threading.Dispatcher Dispatcher
        {
            get => __ProxyValue.Dispatcher;
        }

        public void Complete() => __ProxyValue.Complete();
        public System.Boolean CheckAccess() => __ProxyValue.CheckAccess();
        public void VerifyAccess() => __ProxyValue.VerifyAccess();
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}