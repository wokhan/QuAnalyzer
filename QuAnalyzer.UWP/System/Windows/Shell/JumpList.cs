namespace System.Windows.Shell
{
    using Uno.UI.Generic;

    public class JumpList : Proxy<global::Windows.UI.Xaml.Shell.JumpList>
    {
        public System.Boolean ShowFrequentCategory
        {
            get => __ProxyValue.ShowFrequentCategory;
            set => __ProxyValue.ShowFrequentCategory = value;
        }

        public System.Boolean ShowRecentCategory
        {
            get => __ProxyValue.ShowRecentCategory;
            set => __ProxyValue.ShowRecentCategory = value;
        }

        public System.Collections.Generic.List<System.Windows.Shell.JumpItem> JumpItems
        {
            get => __ProxyValue.JumpItems;
        }

        public JumpList(): base()
        {
        }

        public JumpList(System.Collections.Generic.IEnumerable<System.Windows.Shell.JumpItem> @items, System.Boolean @showFrequent, System.Boolean @showRecent): base(@items, @showFrequent, @showRecent)
        {
        }

        public static void AddToRecentCategory(System.String itemPath) => Windows.UI.Xaml.Shell.JumpList.AddToRecentCategory(@itemPath);
        public static void AddToRecentCategory(System.Windows.Shell.JumpPath jumpPath) => Windows.UI.Xaml.Shell.JumpList.AddToRecentCategory(@jumpPath);
        public static void AddToRecentCategory(System.Windows.Shell.JumpTask jumpTask) => Windows.UI.Xaml.Shell.JumpList.AddToRecentCategory(@jumpTask);
        public static void SetJumpList(System.Windows.Application application, System.Windows.Shell.JumpList value) => Windows.UI.Xaml.Shell.JumpList.SetJumpList(@application, @value);
        public static System.Windows.Shell.JumpList GetJumpList(System.Windows.Application application) => Windows.UI.Xaml.Shell.JumpList.GetJumpList(@application);
        public void BeginInit() => __ProxyValue.BeginInit();
        public void EndInit() => __ProxyValue.EndInit();
        public void Apply() => __ProxyValue.Apply();
        public void add_JumpItemsRejected(System.EventHandler<System.Windows.Shell.JumpItemsRejectedEventArgs> value) => __ProxyValue.add_JumpItemsRejected(@value);
        public void remove_JumpItemsRejected(System.EventHandler<System.Windows.Shell.JumpItemsRejectedEventArgs> value) => __ProxyValue.remove_JumpItemsRejected(@value);
        public void add_JumpItemsRemovedByUser(System.EventHandler<System.Windows.Shell.JumpItemsRemovedEventArgs> value) => __ProxyValue.add_JumpItemsRemovedByUser(@value);
        public void remove_JumpItemsRemovedByUser(System.EventHandler<System.Windows.Shell.JumpItemsRemovedEventArgs> value) => __ProxyValue.remove_JumpItemsRemovedByUser(@value);
        public override System.String ToString() => __ProxyValue.ToString();
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
    }
}