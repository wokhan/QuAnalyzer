namespace System.Windows
{
    using Uno.UI.Generic;

    public class FrameworkCompatibilityPreferences : Proxy<global::Windows.UI.Xaml.FrameworkCompatibilityPreferences>
    {
        public static System.Boolean AreInactiveSelectionHighlightBrushKeysSupported
        {
            get => __ProxyValue.AreInactiveSelectionHighlightBrushKeysSupported;
            set => __ProxyValue.AreInactiveSelectionHighlightBrushKeysSupported = value;
        }

        public static System.Boolean KeepTextBoxDisplaySynchronizedWithTextProperty
        {
            get => __ProxyValue.KeepTextBoxDisplaySynchronizedWithTextProperty;
            set => __ProxyValue.KeepTextBoxDisplaySynchronizedWithTextProperty = value;
        }

        public static System.Boolean ShouldThrowOnCopyOrCutFailure
        {
            get => __ProxyValue.ShouldThrowOnCopyOrCutFailure;
            set => __ProxyValue.ShouldThrowOnCopyOrCutFailure = value;
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}