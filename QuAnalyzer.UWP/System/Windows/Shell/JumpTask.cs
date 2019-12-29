namespace System.Windows.Shell
{
    using Uno.UI.Generic;

    public class JumpTask : Proxy<global::Windows.UI.Xaml.Shell.JumpTask>
    {
        public System.String Title
        {
            get => __ProxyValue.Title;
            set => __ProxyValue.Title = value;
        }

        public System.String Description
        {
            get => __ProxyValue.Description;
            set => __ProxyValue.Description = value;
        }

        public System.String ApplicationPath
        {
            get => __ProxyValue.ApplicationPath;
            set => __ProxyValue.ApplicationPath = value;
        }

        public System.String Arguments
        {
            get => __ProxyValue.Arguments;
            set => __ProxyValue.Arguments = value;
        }

        public System.String WorkingDirectory
        {
            get => __ProxyValue.WorkingDirectory;
            set => __ProxyValue.WorkingDirectory = value;
        }

        public System.String IconResourcePath
        {
            get => __ProxyValue.IconResourcePath;
            set => __ProxyValue.IconResourcePath = value;
        }

        public System.Int32 IconResourceIndex
        {
            get => __ProxyValue.IconResourceIndex;
            set => __ProxyValue.IconResourceIndex = value;
        }

        public System.String CustomCategory
        {
            get => __ProxyValue.CustomCategory;
            set => __ProxyValue.CustomCategory = value;
        }

        public JumpTask(): base()
        {
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}