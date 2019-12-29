namespace System.Windows.Media.TextFormatting
{
    using Uno.UI.Generic;

    public class TextTabProperties : Proxy<global::Windows.UI.Xaml.Media.TextFormatting.TextTabProperties>
    {
        public System.Windows.Media.TextFormatting.TextTabAlignment Alignment
        {
            get => __ProxyValue.Alignment;
        }

        public System.Double Location
        {
            get => __ProxyValue.Location;
        }

        public System.Int32 TabLeader
        {
            get => __ProxyValue.TabLeader;
        }

        public System.Int32 AligningCharacter
        {
            get => __ProxyValue.AligningCharacter;
        }

        public TextTabProperties(System.Windows.Media.TextFormatting.TextTabAlignment @alignment, System.Double @location, System.Int32 @tabLeader, System.Int32 @aligningChar): base(@alignment, @location, @tabLeader, @aligningChar)
        {
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}