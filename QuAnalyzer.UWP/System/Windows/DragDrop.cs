namespace System.Windows
{
    using Uno.UI.Generic;

    public class DragDrop : Proxy<global::Windows.UI.Xaml.DragDrop>
    {
        public static void AddPreviewQueryContinueDragHandler(System.Windows.DependencyObject element, System.Windows.QueryContinueDragEventHandler handler) => Windows.UI.Xaml.DragDrop.AddPreviewQueryContinueDragHandler(@element, @handler);
        public static void RemovePreviewQueryContinueDragHandler(System.Windows.DependencyObject element, System.Windows.QueryContinueDragEventHandler handler) => Windows.UI.Xaml.DragDrop.RemovePreviewQueryContinueDragHandler(@element, @handler);
        public static void AddQueryContinueDragHandler(System.Windows.DependencyObject element, System.Windows.QueryContinueDragEventHandler handler) => Windows.UI.Xaml.DragDrop.AddQueryContinueDragHandler(@element, @handler);
        public static void RemoveQueryContinueDragHandler(System.Windows.DependencyObject element, System.Windows.QueryContinueDragEventHandler handler) => Windows.UI.Xaml.DragDrop.RemoveQueryContinueDragHandler(@element, @handler);
        public static void AddPreviewGiveFeedbackHandler(System.Windows.DependencyObject element, System.Windows.GiveFeedbackEventHandler handler) => Windows.UI.Xaml.DragDrop.AddPreviewGiveFeedbackHandler(@element, @handler);
        public static void RemovePreviewGiveFeedbackHandler(System.Windows.DependencyObject element, System.Windows.GiveFeedbackEventHandler handler) => Windows.UI.Xaml.DragDrop.RemovePreviewGiveFeedbackHandler(@element, @handler);
        public static void AddGiveFeedbackHandler(System.Windows.DependencyObject element, System.Windows.GiveFeedbackEventHandler handler) => Windows.UI.Xaml.DragDrop.AddGiveFeedbackHandler(@element, @handler);
        public static void RemoveGiveFeedbackHandler(System.Windows.DependencyObject element, System.Windows.GiveFeedbackEventHandler handler) => Windows.UI.Xaml.DragDrop.RemoveGiveFeedbackHandler(@element, @handler);
        public static void AddPreviewDragEnterHandler(System.Windows.DependencyObject element, System.Windows.DragEventHandler handler) => Windows.UI.Xaml.DragDrop.AddPreviewDragEnterHandler(@element, @handler);
        public static void RemovePreviewDragEnterHandler(System.Windows.DependencyObject element, System.Windows.DragEventHandler handler) => Windows.UI.Xaml.DragDrop.RemovePreviewDragEnterHandler(@element, @handler);
        public static void AddDragEnterHandler(System.Windows.DependencyObject element, System.Windows.DragEventHandler handler) => Windows.UI.Xaml.DragDrop.AddDragEnterHandler(@element, @handler);
        public static void RemoveDragEnterHandler(System.Windows.DependencyObject element, System.Windows.DragEventHandler handler) => Windows.UI.Xaml.DragDrop.RemoveDragEnterHandler(@element, @handler);
        public static void AddPreviewDragOverHandler(System.Windows.DependencyObject element, System.Windows.DragEventHandler handler) => Windows.UI.Xaml.DragDrop.AddPreviewDragOverHandler(@element, @handler);
        public static void RemovePreviewDragOverHandler(System.Windows.DependencyObject element, System.Windows.DragEventHandler handler) => Windows.UI.Xaml.DragDrop.RemovePreviewDragOverHandler(@element, @handler);
        public static void AddDragOverHandler(System.Windows.DependencyObject element, System.Windows.DragEventHandler handler) => Windows.UI.Xaml.DragDrop.AddDragOverHandler(@element, @handler);
        public static void RemoveDragOverHandler(System.Windows.DependencyObject element, System.Windows.DragEventHandler handler) => Windows.UI.Xaml.DragDrop.RemoveDragOverHandler(@element, @handler);
        public static void AddPreviewDragLeaveHandler(System.Windows.DependencyObject element, System.Windows.DragEventHandler handler) => Windows.UI.Xaml.DragDrop.AddPreviewDragLeaveHandler(@element, @handler);
        public static void RemovePreviewDragLeaveHandler(System.Windows.DependencyObject element, System.Windows.DragEventHandler handler) => Windows.UI.Xaml.DragDrop.RemovePreviewDragLeaveHandler(@element, @handler);
        public static void AddDragLeaveHandler(System.Windows.DependencyObject element, System.Windows.DragEventHandler handler) => Windows.UI.Xaml.DragDrop.AddDragLeaveHandler(@element, @handler);
        public static void RemoveDragLeaveHandler(System.Windows.DependencyObject element, System.Windows.DragEventHandler handler) => Windows.UI.Xaml.DragDrop.RemoveDragLeaveHandler(@element, @handler);
        public static void AddPreviewDropHandler(System.Windows.DependencyObject element, System.Windows.DragEventHandler handler) => Windows.UI.Xaml.DragDrop.AddPreviewDropHandler(@element, @handler);
        public static void RemovePreviewDropHandler(System.Windows.DependencyObject element, System.Windows.DragEventHandler handler) => Windows.UI.Xaml.DragDrop.RemovePreviewDropHandler(@element, @handler);
        public static void AddDropHandler(System.Windows.DependencyObject element, System.Windows.DragEventHandler handler) => Windows.UI.Xaml.DragDrop.AddDropHandler(@element, @handler);
        public static void RemoveDropHandler(System.Windows.DependencyObject element, System.Windows.DragEventHandler handler) => Windows.UI.Xaml.DragDrop.RemoveDropHandler(@element, @handler);
        public static System.Windows.DragDropEffects DoDragDrop(System.Windows.DependencyObject dragSource, System.Object data, System.Windows.DragDropEffects allowedEffects) => Windows.UI.Xaml.DragDrop.DoDragDrop(@dragSource, @data, @allowedEffects);
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}