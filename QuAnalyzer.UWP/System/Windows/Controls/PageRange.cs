namespace System.Windows.Controls
{
    using Uno.UI.Generic;

    public class PageRange : Proxy<global::Windows.UI.Xaml.Controls.PageRange>
    {
        public System.Int32 PageFrom
        {
            get => __ProxyValue.PageFrom;
            set => __ProxyValue.PageFrom = value;
        }

        public System.Int32 PageTo
        {
            get => __ProxyValue.PageTo;
            set => __ProxyValue.PageTo = value;
        }

        public PageRange(System.Int32 @page): base(@page)
        {
        }

        public PageRange(System.Int32 @pageFrom, System.Int32 @pageTo): base(@pageFrom, @pageTo)
        {
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public System.Boolean Equals(System.Windows.Controls.PageRange pageRange) => __ProxyValue.Equals(@pageRange);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
        public static System.Boolean op_Equality(System.Windows.Controls.PageRange pr1, System.Windows.Controls.PageRange pr2) => Windows.UI.Xaml.Controls.PageRange.op_Equality(@pr1, @pr2);
        public static System.Boolean op_Inequality(System.Windows.Controls.PageRange pr1, System.Windows.Controls.PageRange pr2) => Windows.UI.Xaml.Controls.PageRange.op_Inequality(@pr1, @pr2);
    }
}