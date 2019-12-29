namespace System.Windows.Documents.DocumentStructures
{
    using Uno.UI.Generic;

    public class StoryFragment : Proxy<global::Windows.UI.Xaml.Documents.DocumentStructures.StoryFragment>
    {
        public System.String StoryName
        {
            get => __ProxyValue.StoryName;
            set => __ProxyValue.StoryName = value;
        }

        public System.String FragmentName
        {
            get => __ProxyValue.FragmentName;
            set => __ProxyValue.FragmentName = value;
        }

        public System.String FragmentType
        {
            get => __ProxyValue.FragmentType;
            set => __ProxyValue.FragmentType = value;
        }

        public StoryFragment(): base()
        {
        }

        public void Add(System.Windows.Documents.DocumentStructures.BlockElement element) => __ProxyValue.Add(@element);
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}