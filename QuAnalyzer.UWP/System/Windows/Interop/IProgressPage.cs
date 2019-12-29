namespace System.Windows.Interop
{
    using Uno.UI.Generic;

    public class IProgressPage : Proxy<global::Windows.UI.Xaml.Interop.IProgressPage>
    {
        public System.Uri DeploymentPath
        {
            get => __ProxyValue.DeploymentPath;
            set => __ProxyValue.DeploymentPath = value;
        }

        public System.Windows.Threading.DispatcherOperationCallback StopCallback
        {
            get => __ProxyValue.StopCallback;
            set => __ProxyValue.StopCallback = value;
        }

        public System.Windows.Threading.DispatcherOperationCallback RefreshCallback
        {
            get => __ProxyValue.RefreshCallback;
            set => __ProxyValue.RefreshCallback = value;
        }

        public System.String ApplicationName
        {
            get => __ProxyValue.ApplicationName;
            set => __ProxyValue.ApplicationName = value;
        }

        public System.String PublisherName
        {
            get => __ProxyValue.PublisherName;
            set => __ProxyValue.PublisherName = value;
        }

        public void UpdateProgress(System.Int64 bytesDownloaded, System.Int64 bytesTotal) => __ProxyValue.UpdateProgress(@bytesDownloaded, @bytesTotal);
    }
}