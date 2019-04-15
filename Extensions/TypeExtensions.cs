using System;
using System.Collections.Generic;
using System.Text;

namespace Wokhan.Core.Extensions
{
    public static class TypeExtensions
    {
        public static object GetDefault(this Type t)
        {
            return ((Func<object>)GetDefaultGeneric<object>).Method.GetGenericMethodDefinition().MakeGenericMethod(t).Invoke(null, null);
        }

        public static T GetDefaultGeneric<T>()
        {
            return default(T);
        }

    }
}
