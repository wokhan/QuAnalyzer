namespace System.Windows
{
    using Uno.UI.Generic;

    public class SourceChangedEventArgs : Proxy<global::Windows.UI.Xaml.SourceChangedEventArgs>
    {
        public System.Windows.PresentationSource OldSource
        {
            get => __ProxyValue.OldSource;
        }

        public System.Windows.PresentationSource NewSource
        {
            get => __ProxyValue.NewSource;
        }

        public System.Windows.IInputElement Element
        {
            get => __ProxyValue.Element;
        }

        public System.Windows.IInputElement OldParent
        {
            get => __ProxyValue.OldParent;
        }

        public System.Windows.RoutedEvent RoutedEvent
        {
            get => __ProxyValue.RoutedEvent;
            set => __ProxyValue.RoutedEvent = value;
        }

        public System.Boolean Handled
        {
            get => __ProxyValue.Handled;
            set => __ProxyValue.Handled = value;
        }

        public System.Object Source
        {
            get => __ProxyValue.Source;
            set => __ProxyValue.Source = value;
        }

        public System.Object OriginalSource
        {
            get => __ProxyValue.OriginalSource;
        }

        public SourceChangedEventArgs(System.Windows.PresentationSource @oldSource, System.Windows.PresentationSource @newSource): base(@oldSource, @newSource)
        {
        }

        public SourceChangedEventArgs(System.Windows.PresentationSource @oldSource, System.Windows.PresentationSource @newSource, System.Windows.IInputElement @element, System.Windows.IInputElement @oldParent): base(@oldSource, @newSource, @element, @oldParent)
        {
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}