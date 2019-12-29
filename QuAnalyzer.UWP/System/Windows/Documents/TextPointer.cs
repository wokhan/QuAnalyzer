namespace System.Windows.Documents
{
    using Uno.UI.Generic;

    public class TextPointer : Proxy<global::Windows.UI.Xaml.Documents.TextPointer>
    {
        public System.Boolean HasValidLayout
        {
            get => __ProxyValue.HasValidLayout;
        }

        public System.Windows.Documents.LogicalDirection LogicalDirection
        {
            get => __ProxyValue.LogicalDirection;
        }

        public System.Windows.DependencyObject Parent
        {
            get => __ProxyValue.Parent;
        }

        public System.Boolean IsAtInsertionPosition
        {
            get => __ProxyValue.IsAtInsertionPosition;
        }

        public System.Boolean IsAtLineStartPosition
        {
            get => __ProxyValue.IsAtLineStartPosition;
        }

        public System.Windows.Documents.Paragraph Paragraph
        {
            get => __ProxyValue.Paragraph;
        }

        public System.Windows.Documents.TextPointer DocumentStart
        {
            get => __ProxyValue.DocumentStart;
        }

        public System.Windows.Documents.TextPointer DocumentEnd
        {
            get => __ProxyValue.DocumentEnd;
        }

        public System.Boolean IsInSameDocument(System.Windows.Documents.TextPointer textPosition) => __ProxyValue.IsInSameDocument(@textPosition);
        public System.Int32 CompareTo(System.Windows.Documents.TextPointer position) => __ProxyValue.CompareTo(@position);
        public System.Windows.Documents.TextPointerContext GetPointerContext(System.Windows.Documents.LogicalDirection direction) => __ProxyValue.GetPointerContext(@direction);
        public System.Int32 GetTextRunLength(System.Windows.Documents.LogicalDirection direction) => __ProxyValue.GetTextRunLength(@direction);
        public System.Int32 GetOffsetToPosition(System.Windows.Documents.TextPointer position) => __ProxyValue.GetOffsetToPosition(@position);
        public System.String GetTextInRun(System.Windows.Documents.LogicalDirection direction) => __ProxyValue.GetTextInRun(@direction);
        public System.Int32 GetTextInRun(System.Windows.Documents.LogicalDirection direction, System.Char[] textBuffer, System.Int32 startIndex, System.Int32 count) => __ProxyValue.GetTextInRun(@direction, @textBuffer, @startIndex, @count);
        public System.Windows.DependencyObject GetAdjacentElement(System.Windows.Documents.LogicalDirection direction) => __ProxyValue.GetAdjacentElement(@direction);
        public System.Windows.Documents.TextPointer GetPositionAtOffset(System.Int32 offset) => __ProxyValue.GetPositionAtOffset(@offset);
        public System.Windows.Documents.TextPointer GetPositionAtOffset(System.Int32 offset, System.Windows.Documents.LogicalDirection direction) => __ProxyValue.GetPositionAtOffset(@offset, @direction);
        public System.Windows.Documents.TextPointer GetNextContextPosition(System.Windows.Documents.LogicalDirection direction) => __ProxyValue.GetNextContextPosition(@direction);
        public System.Windows.Documents.TextPointer GetInsertionPosition(System.Windows.Documents.LogicalDirection direction) => __ProxyValue.GetInsertionPosition(@direction);
        public System.Windows.Documents.TextPointer GetNextInsertionPosition(System.Windows.Documents.LogicalDirection direction) => __ProxyValue.GetNextInsertionPosition(@direction);
        public System.Windows.Documents.TextPointer GetLineStartPosition(System.Int32 count) => __ProxyValue.GetLineStartPosition(@count);
        public System.Windows.Documents.TextPointer GetLineStartPosition(System.Int32 count, out System.Int32 actualCount) => __ProxyValue.GetLineStartPosition(@count, @actualCount);
        public System.Windows.Rect GetCharacterRect(System.Windows.Documents.LogicalDirection direction) => __ProxyValue.GetCharacterRect(@direction);
        public void InsertTextInRun(System.String textData) => __ProxyValue.InsertTextInRun(@textData);
        public System.Int32 DeleteTextInRun(System.Int32 count) => __ProxyValue.DeleteTextInRun(@count);
        public System.Windows.Documents.TextPointer InsertParagraphBreak() => __ProxyValue.InsertParagraphBreak();
        public System.Windows.Documents.TextPointer InsertLineBreak() => __ProxyValue.InsertLineBreak();
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}