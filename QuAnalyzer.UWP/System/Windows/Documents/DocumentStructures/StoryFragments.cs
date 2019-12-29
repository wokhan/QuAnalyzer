namespace System.Windows.Documents.DocumentStructures
{
    using Uno.UI.Generic;

    public class StoryFragments : Proxy<global::Windows.UI.Xaml.Documents.DocumentStructures.StoryFragments>
    {
        public StoryFragments(): base()
        {
        }

        public void Add(System.Windows.Documents.DocumentStructures.StoryFragment storyFragment) => __ProxyValue.Add(@storyFragment);
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}