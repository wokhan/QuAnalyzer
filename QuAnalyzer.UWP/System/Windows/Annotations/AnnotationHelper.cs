namespace System.Windows.Annotations
{
    using Uno.UI.Generic;

    public class AnnotationHelper : Proxy<global::Windows.UI.Xaml.Annotations.AnnotationHelper>
    {
        public static System.Windows.Annotations.Annotation CreateHighlightForSelection(System.Windows.Annotations.AnnotationService service, System.String author, System.Windows.Media.Brush highlightBrush) => Windows.UI.Xaml.Annotations.AnnotationHelper.CreateHighlightForSelection(@service, @author, @highlightBrush);
        public static System.Windows.Annotations.Annotation CreateTextStickyNoteForSelection(System.Windows.Annotations.AnnotationService service, System.String author) => Windows.UI.Xaml.Annotations.AnnotationHelper.CreateTextStickyNoteForSelection(@service, @author);
        public static System.Windows.Annotations.Annotation CreateInkStickyNoteForSelection(System.Windows.Annotations.AnnotationService service, System.String author) => Windows.UI.Xaml.Annotations.AnnotationHelper.CreateInkStickyNoteForSelection(@service, @author);
        public static void ClearHighlightsForSelection(System.Windows.Annotations.AnnotationService service) => Windows.UI.Xaml.Annotations.AnnotationHelper.ClearHighlightsForSelection(@service);
        public static void DeleteTextStickyNotesForSelection(System.Windows.Annotations.AnnotationService service) => Windows.UI.Xaml.Annotations.AnnotationHelper.DeleteTextStickyNotesForSelection(@service);
        public static void DeleteInkStickyNotesForSelection(System.Windows.Annotations.AnnotationService service) => Windows.UI.Xaml.Annotations.AnnotationHelper.DeleteInkStickyNotesForSelection(@service);
        public static System.Windows.Annotations.IAnchorInfo GetAnchorInfo(System.Windows.Annotations.AnnotationService service, System.Windows.Annotations.Annotation annotation) => Windows.UI.Xaml.Annotations.AnnotationHelper.GetAnchorInfo(@service, @annotation);
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}