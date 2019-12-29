namespace System.Windows.Controls.Primitives
{
    using Uno.UI.Generic;

    public class GeneratorPosition : Proxy<global::Windows.UI.Xaml.Controls.Primitives.GeneratorPosition>
    {
        public System.Int32 Index
        {
            get => __ProxyValue.Index;
            set => __ProxyValue.Index = value;
        }

        public System.Int32 Offset
        {
            get => __ProxyValue.Offset;
            set => __ProxyValue.Offset = value;
        }

        public GeneratorPosition(System.Int32 @index, System.Int32 @offset): base(@index, @offset)
        {
        }

        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object o) => __ProxyValue.Equals(@o);
        public static System.Boolean op_Equality(System.Windows.Controls.Primitives.GeneratorPosition gp1, System.Windows.Controls.Primitives.GeneratorPosition gp2) => Windows.UI.Xaml.Controls.Primitives.GeneratorPosition.op_Equality(@gp1, @gp2);
        public static System.Boolean op_Inequality(System.Windows.Controls.Primitives.GeneratorPosition gp1, System.Windows.Controls.Primitives.GeneratorPosition gp2) => Windows.UI.Xaml.Controls.Primitives.GeneratorPosition.op_Inequality(@gp1, @gp2);
    }
}