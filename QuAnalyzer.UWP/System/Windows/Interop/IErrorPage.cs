namespace System.Windows.Interop
{
    using Uno.UI.Generic;

    public class IErrorPage : Proxy<global::Windows.UI.Xaml.Interop.IErrorPage>
    {
        public System.Uri DeploymentPath
        {
            get => __ProxyValue.DeploymentPath;
            set => __ProxyValue.DeploymentPath = value;
        }

        public System.String ErrorTitle
        {
            get => __ProxyValue.ErrorTitle;
            set => __ProxyValue.ErrorTitle = value;
        }

        public System.String ErrorText
        {
            get => __ProxyValue.ErrorText;
            set => __ProxyValue.ErrorText = value;
        }

        public System.Boolean ErrorFlag
        {
            get => __ProxyValue.ErrorFlag;
            set => __ProxyValue.ErrorFlag = value;
        }

        public System.String LogFilePath
        {
            get => __ProxyValue.LogFilePath;
            set => __ProxyValue.LogFilePath = value;
        }

        public System.Uri SupportUri
        {
            get => __ProxyValue.SupportUri;
            set => __ProxyValue.SupportUri = value;
        }

        public System.Windows.Threading.DispatcherOperationCallback RefreshCallback
        {
            get => __ProxyValue.RefreshCallback;
            set => __ProxyValue.RefreshCallback = value;
        }

        public System.Windows.Threading.DispatcherOperationCallback GetWinFxCallback
        {
            get => __ProxyValue.GetWinFxCallback;
            set => __ProxyValue.GetWinFxCallback = value;
        }
    }
}