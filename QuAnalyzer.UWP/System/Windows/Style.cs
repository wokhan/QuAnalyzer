namespace System.Windows
{
    using Uno.UI.Generic;

    public class Style : Proxy<global::Windows.UI.Xaml.Style>
    {
        public System.Boolean IsSealed
        {
            get => __ProxyValue.IsSealed;
        }

        public System.Type TargetType
        {
            get => __ProxyValue.TargetType;
            set => __ProxyValue.TargetType = value;
        }

        public System.Windows.Style BasedOn
        {
            get => __ProxyValue.BasedOn;
            set => __ProxyValue.BasedOn = value;
        }

        public System.Windows.TriggerCollection Triggers
        {
            get => __ProxyValue.Triggers;
        }

        public System.Windows.SetterBaseCollection Setters
        {
            get => __ProxyValue.Setters;
        }

        public System.Windows.ResourceDictionary Resources
        {
            get => __ProxyValue.Resources;
            set => __ProxyValue.Resources = value;
        }

        public System.Windows.Threading.Dispatcher Dispatcher
        {
            get => __ProxyValue.Dispatcher;
        }

        public Style(): base()
        {
        }

        public Style(System.Type @targetType): base(@targetType)
        {
        }

        public Style(System.Type @targetType, System.Windows.Style @basedOn): base(@targetType, @basedOn)
        {
        }

        public void RegisterName(System.String name, System.Object scopedElement) => __ProxyValue.RegisterName(@name, @scopedElement);
        public void UnregisterName(System.String name) => __ProxyValue.UnregisterName(@name);
        public void Seal() => __ProxyValue.Seal();
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
        public System.Boolean CheckAccess() => __ProxyValue.CheckAccess();
        public void VerifyAccess() => __ProxyValue.VerifyAccess();
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
    }
}