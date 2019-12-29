using System.Runtime.CompilerServices;
namespace Uno.UI.Generic
{
    public class Proxy<T>
    {
        private T __ProxyValue { get => this; }

        public static ConditionalWeakTable<object, object> __references = new ConditionalWeakTable<object, object>();
        public static implicit operator T(Proxy<T> proxy) { return (T)__references.GetValue(proxy, null); }
        public static implicit operator Proxy<T>(T source) { return (Proxy<T>)__references.GetValue(source, create); }

        private static object create(object source)
        {
            var newProxy = new Proxy<T>();
            __references.Add(newProxy, source);
            __references.Add(source, newProxy);

            return newProxy;
        }
    }
}