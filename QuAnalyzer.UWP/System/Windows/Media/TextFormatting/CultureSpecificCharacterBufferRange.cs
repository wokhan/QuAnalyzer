namespace System.Windows.Media.TextFormatting
{
    using Uno.UI.Generic;

    public class CultureSpecificCharacterBufferRange : Proxy<global::Windows.UI.Xaml.Media.TextFormatting.CultureSpecificCharacterBufferRange>
    {
        public System.Globalization.CultureInfo CultureInfo
        {
            get => __ProxyValue.CultureInfo;
        }

        public System.Windows.Media.TextFormatting.CharacterBufferRange CharacterBufferRange
        {
            get => __ProxyValue.CharacterBufferRange;
        }

        public CultureSpecificCharacterBufferRange(System.Globalization.CultureInfo @culture, System.Windows.Media.TextFormatting.CharacterBufferRange @characterBufferRange): base(@culture, @characterBufferRange)
        {
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}