﻿namespace System.Windows.Ink
{
    using Uno.UI.Generic;

    public class EllipseStylusShape : Proxy<global::Windows.UI.Xaml.Ink.EllipseStylusShape>
    {
        public System.Double Width
        {
            get => __ProxyValue.Width;
        }

        public System.Double Height
        {
            get => __ProxyValue.Height;
        }

        public System.Double Rotation
        {
            get => __ProxyValue.Rotation;
        }

        public EllipseStylusShape(System.Double @width, System.Double @height): base(@width, @height)
        {
        }

        public EllipseStylusShape(System.Double @width, System.Double @height, System.Double @rotation): base(@width, @height, @rotation)
        {
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}