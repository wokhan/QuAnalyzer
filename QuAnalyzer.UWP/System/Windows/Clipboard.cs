namespace System.Windows
{
    using Uno.UI.Generic;

    public class Clipboard : Proxy<global::Windows.UI.Xaml.Clipboard>
    {
        public static void Clear() => Windows.UI.Xaml.Clipboard.Clear();
        public static System.Boolean ContainsAudio() => Windows.UI.Xaml.Clipboard.ContainsAudio();
        public static System.Boolean ContainsData(System.String format) => Windows.UI.Xaml.Clipboard.ContainsData(@format);
        public static System.Boolean ContainsFileDropList() => Windows.UI.Xaml.Clipboard.ContainsFileDropList();
        public static System.Boolean ContainsImage() => Windows.UI.Xaml.Clipboard.ContainsImage();
        public static System.Boolean ContainsText() => Windows.UI.Xaml.Clipboard.ContainsText();
        public static System.Boolean ContainsText(System.Windows.TextDataFormat format) => Windows.UI.Xaml.Clipboard.ContainsText(@format);
        public static void Flush() => Windows.UI.Xaml.Clipboard.Flush();
        public static System.IO.Stream GetAudioStream() => Windows.UI.Xaml.Clipboard.GetAudioStream();
        public static System.Object GetData(System.String format) => Windows.UI.Xaml.Clipboard.GetData(@format);
        public static System.Collections.Specialized.StringCollection GetFileDropList() => Windows.UI.Xaml.Clipboard.GetFileDropList();
        public static System.Windows.Media.Imaging.BitmapSource GetImage() => Windows.UI.Xaml.Clipboard.GetImage();
        public static System.String GetText() => Windows.UI.Xaml.Clipboard.GetText();
        public static System.String GetText(System.Windows.TextDataFormat format) => Windows.UI.Xaml.Clipboard.GetText(@format);
        public static void SetAudio(System.Byte[] audioBytes) => Windows.UI.Xaml.Clipboard.SetAudio(@audioBytes);
        public static void SetAudio(System.IO.Stream audioStream) => Windows.UI.Xaml.Clipboard.SetAudio(@audioStream);
        public static void SetData(System.String format, System.Object data) => Windows.UI.Xaml.Clipboard.SetData(@format, @data);
        public static void SetFileDropList(System.Collections.Specialized.StringCollection fileDropList) => Windows.UI.Xaml.Clipboard.SetFileDropList(@fileDropList);
        public static void SetImage(System.Windows.Media.Imaging.BitmapSource image) => Windows.UI.Xaml.Clipboard.SetImage(@image);
        public static void SetText(System.String text) => Windows.UI.Xaml.Clipboard.SetText(@text);
        public static void SetText(System.String text, System.Windows.TextDataFormat format) => Windows.UI.Xaml.Clipboard.SetText(@text, @format);
        public static System.Windows.IDataObject GetDataObject() => Windows.UI.Xaml.Clipboard.GetDataObject();
        public static System.Boolean IsCurrent(System.Windows.IDataObject data) => Windows.UI.Xaml.Clipboard.IsCurrent(@data);
        public static void SetDataObject(System.Object data) => Windows.UI.Xaml.Clipboard.SetDataObject(@data);
        public static void SetDataObject(System.Object data, System.Boolean copy) => Windows.UI.Xaml.Clipboard.SetDataObject(@data, @copy);
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}