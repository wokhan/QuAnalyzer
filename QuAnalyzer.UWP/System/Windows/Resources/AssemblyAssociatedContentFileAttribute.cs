namespace System.Windows.Resources
{
    using Uno.UI.Generic;

    public class AssemblyAssociatedContentFileAttribute : Proxy<global::Windows.UI.Xaml.Resources.AssemblyAssociatedContentFileAttribute>
    {
        public System.String RelativeContentFilePath
        {
            get => __ProxyValue.RelativeContentFilePath;
        }

        public System.Object TypeId
        {
            get => __ProxyValue.TypeId;
        }

        public AssemblyAssociatedContentFileAttribute(System.String @relativeContentFilePath): base(@relativeContentFilePath)
        {
        }

        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
        public System.Boolean Match(System.Object obj) => __ProxyValue.Match(@obj);
        public System.Boolean IsDefaultAttribute() => __ProxyValue.IsDefaultAttribute();
        public override System.String ToString() => __ProxyValue.ToString();
    }
}