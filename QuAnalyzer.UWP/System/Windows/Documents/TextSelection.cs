namespace System.Windows.Documents
{
    using Uno.UI.Generic;

    public class TextSelection : Proxy<global::Windows.UI.Xaml.Documents.TextSelection>
    {
        public System.Windows.Documents.TextPointer Start
        {
            get => __ProxyValue.Start;
        }

        public System.Windows.Documents.TextPointer End
        {
            get => __ProxyValue.End;
        }

        public System.Boolean IsEmpty
        {
            get => __ProxyValue.IsEmpty;
        }

        public System.String Text
        {
            get => __ProxyValue.Text;
            set => __ProxyValue.Text = value;
        }

        public void add_Changed(System.EventHandler value) => __ProxyValue.add_Changed(@value);
        public void remove_Changed(System.EventHandler value) => __ProxyValue.remove_Changed(@value);
        public System.Boolean Contains(System.Windows.Documents.TextPointer textPointer) => __ProxyValue.Contains(@textPointer);
        public void Select(System.Windows.Documents.TextPointer position1, System.Windows.Documents.TextPointer position2) => __ProxyValue.Select(@position1, @position2);
        public void ApplyPropertyValue(System.Windows.DependencyProperty formattingProperty, System.Object value) => __ProxyValue.ApplyPropertyValue(@formattingProperty, @value);
        public void ClearAllProperties() => __ProxyValue.ClearAllProperties();
        public System.Object GetPropertyValue(System.Windows.DependencyProperty formattingProperty) => __ProxyValue.GetPropertyValue(@formattingProperty);
        public System.Boolean CanSave(System.String dataFormat) => __ProxyValue.CanSave(@dataFormat);
        public System.Boolean CanLoad(System.String dataFormat) => __ProxyValue.CanLoad(@dataFormat);
        public void Save(System.IO.Stream stream, System.String dataFormat) => __ProxyValue.Save(@stream, @dataFormat);
        public void Save(System.IO.Stream stream, System.String dataFormat, System.Boolean preserveTextElements) => __ProxyValue.Save(@stream, @dataFormat, @preserveTextElements);
        public void Load(System.IO.Stream stream, System.String dataFormat) => __ProxyValue.Load(@stream, @dataFormat);
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}