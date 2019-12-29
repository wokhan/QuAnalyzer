namespace System.Windows.Documents.Serialization
{
    using Uno.UI.Generic;

    public class WritingProgressChangedEventArgs : Proxy<global::Windows.UI.Xaml.Documents.Serialization.WritingProgressChangedEventArgs>
    {
        public System.Int32 Number
        {
            get => __ProxyValue.Number;
        }

        public System.Windows.Documents.Serialization.WritingProgressChangeLevel WritingLevel
        {
            get => __ProxyValue.WritingLevel;
        }

        public System.Int32 ProgressPercentage
        {
            get => __ProxyValue.ProgressPercentage;
        }

        public System.Object UserState
        {
            get => __ProxyValue.UserState;
        }

        public WritingProgressChangedEventArgs(System.Windows.Documents.Serialization.WritingProgressChangeLevel @writingLevel, System.Int32 @number, System.Int32 @progressPercentage, System.Object @state): base(@writingLevel, @number, @progressPercentage, @state)
        {
        }

        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}