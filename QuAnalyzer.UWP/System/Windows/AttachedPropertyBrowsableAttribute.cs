﻿namespace System.Windows
{
    using Uno.UI.Generic;

    public class AttachedPropertyBrowsableAttribute : Proxy<global::Windows.UI.Xaml.AttachedPropertyBrowsableAttribute>
    {
        public System.Object TypeId
        {
            get => __ProxyValue.TypeId;
        }

        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
        public System.Boolean Match(System.Object obj) => __ProxyValue.Match(@obj);
        public System.Boolean IsDefaultAttribute() => __ProxyValue.IsDefaultAttribute();
        public override System.String ToString() => __ProxyValue.ToString();
    }
}