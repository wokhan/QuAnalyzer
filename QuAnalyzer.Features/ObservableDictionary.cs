using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace QuAnalyzer;

/// <summary>
/// An observable variant of <see cref="Dictionary{TKey, TValue}"/>.
/// </summary>
/// <typeparam name="TKey"></typeparam>
/// <typeparam name="TValue"></typeparam>
public class ObservableDictionary<TKey, TValue> : Dictionary<TKey, TValue>, INotifyCollectionChanged, INotifyPropertyChanged //where TKey : class
{
    public ObservableDictionary(IDictionary<TKey, TValue> dictionary) : base(dictionary)
    {
    }

    public ObservableDictionary()
    {
    }

    public ObservableDictionary(IDictionary<TKey, TValue> dictionary, IEqualityComparer<TKey> comparer) : base(dictionary, comparer)
    {
    }

    public ObservableDictionary(IEnumerable<KeyValuePair<TKey, TValue>> collection) : base(collection)
    {
    }

    public ObservableDictionary(IEnumerable<KeyValuePair<TKey, TValue>> collection, IEqualityComparer<TKey> comparer) : base(collection, comparer)
    {
    }

    public ObservableDictionary(IEqualityComparer<TKey> comparer) : base(comparer)
    {
    }

    public ObservableDictionary(int capacity) : base(capacity)
    {
    }

    public ObservableDictionary(int capacity, IEqualityComparer<TKey> comparer) : base(capacity, comparer)
    {
    }

    protected ObservableDictionary(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    public event NotifyCollectionChangedEventHandler? CollectionChanged;
    public event PropertyChangedEventHandler? PropertyChanged;

    public new void Add(TKey key, TValue value)
    {
        base.Add(key, value);

        NotifyCollectionChanged(NotifyCollectionChangedAction.Add, (key, value));
        NotifyPropertyChanged(nameof(Keys));
        NotifyPropertyChanged(nameof(Values));
    }

    public new void Remove(TKey key)
    {
        base.Remove(key);

        NotifyCollectionChanged(NotifyCollectionChangedAction.Reset);
        NotifyPropertyChanged(nameof(Keys));
        NotifyPropertyChanged(nameof(Values));
    }

    public void Refresh()
    {
        NotifyCollectionChanged(NotifyCollectionChangedAction.Reset);
        NotifyPropertyChanged(nameof(Keys));
        NotifyPropertyChanged(nameof(Values));
    }

    public new void Clear()
    {
        base.Clear();

        NotifyCollectionChanged(NotifyCollectionChangedAction.Reset);
        NotifyPropertyChanged(nameof(Keys));
        NotifyPropertyChanged(nameof(Values));
    }

    public new TValue this[TKey key]
    {
        get => base[key];
        set
        {
            var oldvalue = base[key];
            base[key] = value;
            NotifyCollectionChanged(NotifyCollectionChangedAction.Replace, (key, value), (key, oldvalue));
            NotifyPropertyChanged(nameof(Values));

        }
    }

    protected void NotifyCollectionChanged(NotifyCollectionChangedAction action, object? item = null, object? oldItem = null)
    {
        if (action == NotifyCollectionChangedAction.Replace)
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(action, item, oldItem));

        if (action == NotifyCollectionChangedAction.Add || action == NotifyCollectionChangedAction.Remove)
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(action, item));
    }


    private void NotifyPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

}
