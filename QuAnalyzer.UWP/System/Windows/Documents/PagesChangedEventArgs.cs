﻿namespace System.Windows.Documents
{
    using Uno.UI.Generic;

    public class PagesChangedEventArgs : Proxy<global::Windows.UI.Xaml.Documents.PagesChangedEventArgs>
    {
        public System.Int32 Start
        {
            get => __ProxyValue.Start;
        }

        public System.Int32 Count
        {
            get => __ProxyValue.Count;
        }

        public PagesChangedEventArgs(System.Int32 @start, System.Int32 @count): base(@start, @count)
        {
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}