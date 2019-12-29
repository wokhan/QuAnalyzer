namespace System.Windows.Media.Imaging
{
    using Uno.UI.Generic;

    public class BitmapMetadata : Proxy<global::Windows.UI.Xaml.Media.Imaging.BitmapMetadata>
    {
        public System.String Format
        {
            get => __ProxyValue.Format;
        }

        public System.String Location
        {
            get => __ProxyValue.Location;
        }

        public System.Boolean IsReadOnly
        {
            get => __ProxyValue.IsReadOnly;
        }

        public System.Boolean IsFixedSize
        {
            get => __ProxyValue.IsFixedSize;
        }

        public System.Collections.ObjectModel.ReadOnlyCollection<System.String> Author
        {
            get => __ProxyValue.Author;
            set => __ProxyValue.Author = value;
        }

        public System.String Title
        {
            get => __ProxyValue.Title;
            set => __ProxyValue.Title = value;
        }

        public System.Int32 Rating
        {
            get => __ProxyValue.Rating;
            set => __ProxyValue.Rating = value;
        }

        public System.String Subject
        {
            get => __ProxyValue.Subject;
            set => __ProxyValue.Subject = value;
        }

        public System.String Comment
        {
            get => __ProxyValue.Comment;
            set => __ProxyValue.Comment = value;
        }

        public System.String DateTaken
        {
            get => __ProxyValue.DateTaken;
            set => __ProxyValue.DateTaken = value;
        }

        public System.String ApplicationName
        {
            get => __ProxyValue.ApplicationName;
            set => __ProxyValue.ApplicationName = value;
        }

        public System.String Copyright
        {
            get => __ProxyValue.Copyright;
            set => __ProxyValue.Copyright = value;
        }

        public System.String CameraManufacturer
        {
            get => __ProxyValue.CameraManufacturer;
            set => __ProxyValue.CameraManufacturer = value;
        }

        public System.String CameraModel
        {
            get => __ProxyValue.CameraModel;
            set => __ProxyValue.CameraModel = value;
        }

        public System.Collections.ObjectModel.ReadOnlyCollection<System.String> Keywords
        {
            get => __ProxyValue.Keywords;
            set => __ProxyValue.Keywords = value;
        }

        public System.Boolean CanFreeze
        {
            get => __ProxyValue.CanFreeze;
        }

        public System.Boolean IsFrozen
        {
            get => __ProxyValue.IsFrozen;
        }

        public System.Windows.DependencyObjectType DependencyObjectType
        {
            get => __ProxyValue.DependencyObjectType;
        }

        public System.Boolean IsSealed
        {
            get => __ProxyValue.IsSealed;
        }

        public System.Windows.Threading.Dispatcher Dispatcher
        {
            get => __ProxyValue.Dispatcher;
        }

        public BitmapMetadata(System.String @containerFormat): base(@containerFormat)
        {
        }

        public System.Windows.Media.Imaging.BitmapMetadata Clone() => __ProxyValue.Clone();
        public void SetQuery(System.String query, System.Object value) => __ProxyValue.SetQuery(@query, @value);
        public System.Object GetQuery(System.String query) => __ProxyValue.GetQuery(@query);
        public void RemoveQuery(System.String query) => __ProxyValue.RemoveQuery(@query);
        public System.Boolean ContainsQuery(System.String query) => __ProxyValue.ContainsQuery(@query);
        public System.Windows.Freezable CloneCurrentValue() => __ProxyValue.CloneCurrentValue();
        public System.Windows.Freezable GetAsFrozen() => __ProxyValue.GetAsFrozen();
        public System.Windows.Freezable GetCurrentValueAsFrozen() => __ProxyValue.GetCurrentValueAsFrozen();
        public void Freeze() => __ProxyValue.Freeze();
        public void add_Changed(System.EventHandler value) => __ProxyValue.add_Changed(@value);
        public void remove_Changed(System.EventHandler value) => __ProxyValue.remove_Changed(@value);
        public override System.Boolean Equals(System.Object obj) => __ProxyValue.Equals(@obj);
        public override System.Int32 GetHashCode() => __ProxyValue.GetHashCode();
        public System.Object GetValue(System.Windows.DependencyProperty dp) => __ProxyValue.GetValue(@dp);
        public void SetValue(System.Windows.DependencyProperty dp, System.Object value) => __ProxyValue.SetValue(@dp, @value);
        public void SetCurrentValue(System.Windows.DependencyProperty dp, System.Object value) => __ProxyValue.SetCurrentValue(@dp, @value);
        public void SetValue(System.Windows.DependencyPropertyKey key, System.Object value) => __ProxyValue.SetValue(@key, @value);
        public void ClearValue(System.Windows.DependencyProperty dp) => __ProxyValue.ClearValue(@dp);
        public void ClearValue(System.Windows.DependencyPropertyKey key) => __ProxyValue.ClearValue(@key);
        public void CoerceValue(System.Windows.DependencyProperty dp) => __ProxyValue.CoerceValue(@dp);
        public void InvalidateProperty(System.Windows.DependencyProperty dp) => __ProxyValue.InvalidateProperty(@dp);
        public System.Object ReadLocalValue(System.Windows.DependencyProperty dp) => __ProxyValue.ReadLocalValue(@dp);
        public System.Windows.LocalValueEnumerator GetLocalValueEnumerator() => __ProxyValue.GetLocalValueEnumerator();
        public System.Boolean CheckAccess() => __ProxyValue.CheckAccess();
        public void VerifyAccess() => __ProxyValue.VerifyAccess();
        public override System.String ToString() => __ProxyValue.ToString();
    }
}