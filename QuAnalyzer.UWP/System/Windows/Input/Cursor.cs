namespace System.Windows.Input
{
    using Uno.UI.Generic;

    public class Cursor : Proxy<global::Windows.UI.Xaml.Input.Cursor>
    {
        public Cursor(System.String @cursorFile): base(@cursorFile)
        {
        }

        public Cursor(System.String @cursorFile, System.Boolean @scaleWithDpi): base(@cursorFile, @scaleWithDpi)
        {
        }

        public Cursor(System.IO.Stream @cursorStream): base(@cursorStream)
        {
        }

        public Cursor(System.IO.Stream @cursorStream, System.Boolean @scaleWithDpi): base(@cursorStream, @scaleWithDpi)
        {
        }

        public void Dispose() => __ProxyValue.Dispose();
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}