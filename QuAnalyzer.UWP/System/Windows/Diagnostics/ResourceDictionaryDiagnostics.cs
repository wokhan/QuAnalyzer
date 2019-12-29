namespace System.Windows.Diagnostics
{
    using Uno.UI.Generic;

    public class ResourceDictionaryDiagnostics : Proxy<global::Windows.UI.Xaml.Diagnostics.ResourceDictionaryDiagnostics>
    {
        public static System.Collections.Generic.IEnumerable<System.Windows.Diagnostics.ResourceDictionaryInfo> ThemedResourceDictionaries
        {
            get => __ProxyValue.ThemedResourceDictionaries;
        }

        public static System.Collections.Generic.IEnumerable<System.Windows.Diagnostics.ResourceDictionaryInfo> GenericResourceDictionaries
        {
            get => __ProxyValue.GenericResourceDictionaries;
        }

        public static void add_ThemedResourceDictionaryLoaded(System.EventHandler<System.Windows.Diagnostics.ResourceDictionaryLoadedEventArgs> value) => Windows.UI.Xaml.Diagnostics.ResourceDictionaryDiagnostics.add_ThemedResourceDictionaryLoaded(@value);
        public static void remove_ThemedResourceDictionaryLoaded(System.EventHandler<System.Windows.Diagnostics.ResourceDictionaryLoadedEventArgs> value) => Windows.UI.Xaml.Diagnostics.ResourceDictionaryDiagnostics.remove_ThemedResourceDictionaryLoaded(@value);
        public static void add_ThemedResourceDictionaryUnloaded(System.EventHandler<System.Windows.Diagnostics.ResourceDictionaryUnloadedEventArgs> value) => Windows.UI.Xaml.Diagnostics.ResourceDictionaryDiagnostics.add_ThemedResourceDictionaryUnloaded(@value);
        public static void remove_ThemedResourceDictionaryUnloaded(System.EventHandler<System.Windows.Diagnostics.ResourceDictionaryUnloadedEventArgs> value) => Windows.UI.Xaml.Diagnostics.ResourceDictionaryDiagnostics.remove_ThemedResourceDictionaryUnloaded(@value);
        public static void add_GenericResourceDictionaryLoaded(System.EventHandler<System.Windows.Diagnostics.ResourceDictionaryLoadedEventArgs> value) => Windows.UI.Xaml.Diagnostics.ResourceDictionaryDiagnostics.add_GenericResourceDictionaryLoaded(@value);
        public static void remove_GenericResourceDictionaryLoaded(System.EventHandler<System.Windows.Diagnostics.ResourceDictionaryLoadedEventArgs> value) => Windows.UI.Xaml.Diagnostics.ResourceDictionaryDiagnostics.remove_GenericResourceDictionaryLoaded(@value);
        public static System.Collections.Generic.IEnumerable<System.Windows.ResourceDictionary> GetResourceDictionariesForSource(System.Uri uri) => Windows.UI.Xaml.Diagnostics.ResourceDictionaryDiagnostics.GetResourceDictionariesForSource(@uri);
        public static System.Collections.Generic.IEnumerable<System.Windows.FrameworkElement> GetFrameworkElementOwners(System.Windows.ResourceDictionary dictionary) => Windows.UI.Xaml.Diagnostics.ResourceDictionaryDiagnostics.GetFrameworkElementOwners(@dictionary);
        public static System.Collections.Generic.IEnumerable<System.Windows.FrameworkContentElement> GetFrameworkContentElementOwners(System.Windows.ResourceDictionary dictionary) => Windows.UI.Xaml.Diagnostics.ResourceDictionaryDiagnostics.GetFrameworkContentElementOwners(@dictionary);
        public static System.Collections.Generic.IEnumerable<System.Windows.Application> GetApplicationOwners(System.Windows.ResourceDictionary dictionary) => Windows.UI.Xaml.Diagnostics.ResourceDictionaryDiagnostics.GetApplicationOwners(@dictionary);
        public static void add_StaticResourceResolved(System.EventHandler<System.Windows.Diagnostics.StaticResourceResolvedEventArgs> value) => Windows.UI.Xaml.Diagnostics.ResourceDictionaryDiagnostics.add_StaticResourceResolved(@value);
        public static void remove_StaticResourceResolved(System.EventHandler<System.Windows.Diagnostics.StaticResourceResolvedEventArgs> value) => Windows.UI.Xaml.Diagnostics.ResourceDictionaryDiagnostics.remove_StaticResourceResolved(@value);
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}