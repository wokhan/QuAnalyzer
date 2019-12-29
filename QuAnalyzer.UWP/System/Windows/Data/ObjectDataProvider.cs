namespace System.Windows.Data
{
    using Uno.UI.Generic;

    public class ObjectDataProvider : Proxy<global::Windows.UI.Xaml.Data.ObjectDataProvider>
    {
        public System.Type ObjectType
        {
            get => __ProxyValue.ObjectType;
            set => __ProxyValue.ObjectType = value;
        }

        public System.Object ObjectInstance
        {
            get => __ProxyValue.ObjectInstance;
            set => __ProxyValue.ObjectInstance = value;
        }

        public System.String MethodName
        {
            get => __ProxyValue.MethodName;
            set => __ProxyValue.MethodName = value;
        }

        public System.Collections.IList ConstructorParameters
        {
            get => __ProxyValue.ConstructorParameters;
        }

        public System.Collections.IList MethodParameters
        {
            get => __ProxyValue.MethodParameters;
        }

        public System.Boolean IsAsynchronous
        {
            get => __ProxyValue.IsAsynchronous;
            set => __ProxyValue.IsAsynchronous = value;
        }

        public System.Boolean IsInitialLoadEnabled
        {
            get => __ProxyValue.IsInitialLoadEnabled;
            set => __ProxyValue.IsInitialLoadEnabled = value;
        }

        public System.Object Data
        {
            get => __ProxyValue.Data;
        }

        public System.Exception Error
        {
            get => __ProxyValue.Error;
        }

        public ObjectDataProvider(): base()
        {
        }

        public System.Boolean ShouldSerializeObjectType() => __ProxyValue.ShouldSerializeObjectType();
        public System.Boolean ShouldSerializeObjectInstance() => __ProxyValue.ShouldSerializeObjectInstance();
        public System.Boolean ShouldSerializeConstructorParameters() => __ProxyValue.ShouldSerializeConstructorParameters();
        public System.Boolean ShouldSerializeMethodParameters() => __ProxyValue.ShouldSerializeMethodParameters();
        public void InitialLoad() => __ProxyValue.InitialLoad();
        public void Refresh() => __ProxyValue.Refresh();
        public void add_DataChanged(System.EventHandler value) => __ProxyValue.add_DataChanged(@value);
        public void remove_DataChanged(System.EventHandler value) => __ProxyValue.remove_DataChanged(@value);
        public System.IDisposable DeferRefresh() => __ProxyValue.DeferRefresh();
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}