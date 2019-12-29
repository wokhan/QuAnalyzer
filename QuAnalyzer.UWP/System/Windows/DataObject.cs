namespace System.Windows
{
    using Uno.UI.Generic;

    public class DataObject : Proxy<global::Windows.UI.Xaml.DataObject>
    {
        public DataObject(): base()
        {
        }

        public DataObject(System.Object @data): base(@data)
        {
        }

        public DataObject(System.String @format, System.Object @data): base(@format, @data)
        {
        }

        public DataObject(System.Type @format, System.Object @data): base(@format, @data)
        {
        }

        public DataObject(System.String @format, System.Object @data, System.Boolean @autoConvert): base(@format, @data, @autoConvert)
        {
        }

        public System.Object GetData(System.String format, System.Boolean autoConvert) => __ProxyValue.GetData(@format, @autoConvert);
        public System.Object GetData(System.String format) => __ProxyValue.GetData(@format);
        public System.Object GetData(System.Type format) => __ProxyValue.GetData(@format);
        public System.Boolean GetDataPresent(System.Type format) => __ProxyValue.GetDataPresent(@format);
        public System.Boolean GetDataPresent(System.String format, System.Boolean autoConvert) => __ProxyValue.GetDataPresent(@format, @autoConvert);
        public System.Boolean GetDataPresent(System.String format) => __ProxyValue.GetDataPresent(@format);
        public System.String[] GetFormats(System.Boolean autoConvert) => __ProxyValue.GetFormats(@autoConvert);
        public System.String[] GetFormats() => __ProxyValue.GetFormats();
        public void SetData(System.Object data) => __ProxyValue.SetData(@data);
        public void SetData(System.String format, System.Object data) => __ProxyValue.SetData(@format, @data);
        public void SetData(System.Type format, System.Object data) => __ProxyValue.SetData(@format, @data);
        public void SetData(System.String format, System.Object data, System.Boolean autoConvert) => __ProxyValue.SetData(@format, @data, @autoConvert);
        public System.Boolean ContainsAudio() => __ProxyValue.ContainsAudio();
        public System.Boolean ContainsFileDropList() => __ProxyValue.ContainsFileDropList();
        public System.Boolean ContainsImage() => __ProxyValue.ContainsImage();
        public System.Boolean ContainsText() => __ProxyValue.ContainsText();
        public System.Boolean ContainsText(System.Windows.TextDataFormat format) => __ProxyValue.ContainsText(@format);
        public System.IO.Stream GetAudioStream() => __ProxyValue.GetAudioStream();
        public System.Collections.Specialized.StringCollection GetFileDropList() => __ProxyValue.GetFileDropList();
        public System.Windows.Media.Imaging.BitmapSource GetImage() => __ProxyValue.GetImage();
        public System.String GetText() => __ProxyValue.GetText();
        public System.String GetText(System.Windows.TextDataFormat format) => __ProxyValue.GetText(@format);
        public void SetAudio(System.Byte[] audioBytes) => __ProxyValue.SetAudio(@audioBytes);
        public void SetAudio(System.IO.Stream audioStream) => __ProxyValue.SetAudio(@audioStream);
        public void SetFileDropList(System.Collections.Specialized.StringCollection fileDropList) => __ProxyValue.SetFileDropList(@fileDropList);
        public void SetImage(System.Windows.Media.Imaging.BitmapSource image) => __ProxyValue.SetImage(@image);
        public void SetText(System.String textData) => __ProxyValue.SetText(@textData);
        public void SetText(System.String textData, System.Windows.TextDataFormat format) => __ProxyValue.SetText(@textData, @format);
        public static void AddCopyingHandler(System.Windows.DependencyObject element, System.Windows.DataObjectCopyingEventHandler handler) => Windows.UI.Xaml.DataObject.AddCopyingHandler(@element, @handler);
        public static void RemoveCopyingHandler(System.Windows.DependencyObject element, System.Windows.DataObjectCopyingEventHandler handler) => Windows.UI.Xaml.DataObject.RemoveCopyingHandler(@element, @handler);
        public static void AddPastingHandler(System.Windows.DependencyObject element, System.Windows.DataObjectPastingEventHandler handler) => Windows.UI.Xaml.DataObject.AddPastingHandler(@element, @handler);
        public static void RemovePastingHandler(System.Windows.DependencyObject element, System.Windows.DataObjectPastingEventHandler handler) => Windows.UI.Xaml.DataObject.RemovePastingHandler(@element, @handler);
        public static void AddSettingDataHandler(System.Windows.DependencyObject element, System.Windows.DataObjectSettingDataEventHandler handler) => Windows.UI.Xaml.DataObject.AddSettingDataHandler(@element, @handler);
        public static void RemoveSettingDataHandler(System.Windows.DependencyObject element, System.Windows.DataObjectSettingDataEventHandler handler) => Windows.UI.Xaml.DataObject.RemoveSettingDataHandler(@element, @handler);
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}