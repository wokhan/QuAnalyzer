namespace System.Windows.Media.TextFormatting
{
    using Uno.UI.Generic;

    public class CharacterHit : Proxy<global::Windows.UI.Xaml.Media.TextFormatting.CharacterHit>
    {
        public System.Int32 FirstCharacterIndex
        {
            get => __ProxyValue.FirstCharacterIndex;
        }

        public System.Int32 TrailingLength
        {
            get => __ProxyValue.TrailingLength;
        }

        public CharacterHit(System.Int32 @firstCharacterIndex, System.Int32 @trailingLength): base(@firstCharacterIndex, @trailingLength)
        {
        }

        public static System.Boolean op_Equality(System.Windows.Media.TextFormatting.CharacterHit left, System.Windows.Media.TextFormatting.CharacterHit right) => Windows.UI.Xaml.Media.TextFormatting.CharacterHit.op_Equality(@left, @right);
        public static System.Boolean op_Inequality(System.Windows.Media.TextFormatting.CharacterHit left, System.Windows.Media.TextFormatting.CharacterHit right) => Windows.UI.Xaml.Media.TextFormatting.CharacterHit.op_Inequality(@left, @right);
        public System.Boolean Equals(System.Windows.Media.TextFormatting.CharacterHit obj) => __ProxyValue.Equals(@obj);
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
        public override System.String ToString() => __ProxyValue.ToString();
    }
}