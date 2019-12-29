using System;
using System.Runtime.CompilerServices;

namespace Uno.UI.Generic
{
    public class Proxy
    {
        protected static ConditionalWeakTable<object, object> __references = new ConditionalWeakTable<object, object>();

        protected static void AddMapping<T>(T source, Proxy<T> target)
        {
            __references.Add(target, source);
            __references.Add(source, target);
        }
    }

    public class Proxy<T> : Proxy
    {
        protected T __ProxyValue { get => this; }

        public static implicit operator T(Proxy<T> proxy) { return (T)__references.GetValue(proxy, null); }
        public static implicit operator Proxy<T>(T source) { return (Proxy<T>)__references.GetValue(source, Create); }

        public static Proxy<T> Create(object source)
        {
            var newProxy = new Proxy<T>();
            AddMapping((T)source, newProxy);
            return newProxy;
        }

        public Proxy()
        {
        }

        public Proxy(params object[] args)
        {
            var source = (T)Activator.CreateInstance(typeof(T), args);
            AddMapping(source, this);
        }
    }
}