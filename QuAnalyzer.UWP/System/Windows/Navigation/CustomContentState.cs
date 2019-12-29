namespace System.Windows.Navigation
{
    using Uno.UI.Generic;

    public class CustomContentState : Proxy<global::Windows.UI.Xaml.Navigation.CustomContentState>
    {
        public System.String JournalEntryName
        {
            get => __ProxyValue.JournalEntryName;
        }

        public void Replay(System.Windows.Navigation.NavigationService navigationService, System.Windows.Navigation.NavigationMode mode) => __ProxyValue.Replay(@navigationService, @mode);
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}