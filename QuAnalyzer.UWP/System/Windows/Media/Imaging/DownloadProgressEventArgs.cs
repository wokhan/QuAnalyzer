namespace System.Windows.Media.Imaging
{
    using Uno.UI.Generic;

    public class DownloadProgressEventArgs : Proxy<global::Windows.UI.Xaml.Media.Imaging.DownloadProgressEventArgs>
    {
        public System.Int32 Progress
        {
            get => __ProxyValue.Progress;
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}