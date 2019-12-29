namespace System.Windows.Input
{
    using Uno.UI.Generic;

    public class CommandManager : Proxy<global::Windows.UI.Xaml.Input.CommandManager>
    {
        public static void add_RequerySuggested(System.EventHandler value) => Windows.UI.Xaml.Input.CommandManager.add_RequerySuggested(@value);
        public static void remove_RequerySuggested(System.EventHandler value) => Windows.UI.Xaml.Input.CommandManager.remove_RequerySuggested(@value);
        public static void AddPreviewExecutedHandler(System.Windows.UIElement element, System.Windows.Input.ExecutedRoutedEventHandler handler) => Windows.UI.Xaml.Input.CommandManager.AddPreviewExecutedHandler(@element, @handler);
        public static void RemovePreviewExecutedHandler(System.Windows.UIElement element, System.Windows.Input.ExecutedRoutedEventHandler handler) => Windows.UI.Xaml.Input.CommandManager.RemovePreviewExecutedHandler(@element, @handler);
        public static void AddExecutedHandler(System.Windows.UIElement element, System.Windows.Input.ExecutedRoutedEventHandler handler) => Windows.UI.Xaml.Input.CommandManager.AddExecutedHandler(@element, @handler);
        public static void RemoveExecutedHandler(System.Windows.UIElement element, System.Windows.Input.ExecutedRoutedEventHandler handler) => Windows.UI.Xaml.Input.CommandManager.RemoveExecutedHandler(@element, @handler);
        public static void AddPreviewCanExecuteHandler(System.Windows.UIElement element, System.Windows.Input.CanExecuteRoutedEventHandler handler) => Windows.UI.Xaml.Input.CommandManager.AddPreviewCanExecuteHandler(@element, @handler);
        public static void RemovePreviewCanExecuteHandler(System.Windows.UIElement element, System.Windows.Input.CanExecuteRoutedEventHandler handler) => Windows.UI.Xaml.Input.CommandManager.RemovePreviewCanExecuteHandler(@element, @handler);
        public static void AddCanExecuteHandler(System.Windows.UIElement element, System.Windows.Input.CanExecuteRoutedEventHandler handler) => Windows.UI.Xaml.Input.CommandManager.AddCanExecuteHandler(@element, @handler);
        public static void RemoveCanExecuteHandler(System.Windows.UIElement element, System.Windows.Input.CanExecuteRoutedEventHandler handler) => Windows.UI.Xaml.Input.CommandManager.RemoveCanExecuteHandler(@element, @handler);
        public static void RegisterClassInputBinding(System.Type type, System.Windows.Input.InputBinding inputBinding) => Windows.UI.Xaml.Input.CommandManager.RegisterClassInputBinding(@type, @inputBinding);
        public static void RegisterClassCommandBinding(System.Type type, System.Windows.Input.CommandBinding commandBinding) => Windows.UI.Xaml.Input.CommandManager.RegisterClassCommandBinding(@type, @commandBinding);
        public static void InvalidateRequerySuggested() => Windows.UI.Xaml.Input.CommandManager.InvalidateRequerySuggested();
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}