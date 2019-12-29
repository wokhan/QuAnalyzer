namespace System.Windows.Controls
{
    using Uno.UI.Generic;

    public class CalendarDateRange : Proxy<global::Windows.UI.Xaml.Controls.CalendarDateRange>
    {
        public System.DateTime End
        {
            get => __ProxyValue.End;
            set => __ProxyValue.End = value;
        }

        public System.DateTime Start
        {
            get => __ProxyValue.Start;
            set => __ProxyValue.Start = value;
        }

        public CalendarDateRange(): base()
        {
        }

        public CalendarDateRange(System.DateTime @day): base(@day)
        {
        }

        public CalendarDateRange(System.DateTime @start, System.DateTime @end): base(@start, @end)
        {
        }

        public void add_PropertyChanged(System.ComponentModel.PropertyChangedEventHandler value) => __ProxyValue.add_PropertyChanged(@value);
        public void remove_PropertyChanged(System.ComponentModel.PropertyChangedEventHandler value) => __ProxyValue.remove_PropertyChanged(@value);
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}