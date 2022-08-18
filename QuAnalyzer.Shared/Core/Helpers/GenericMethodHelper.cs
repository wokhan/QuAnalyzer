namespace QuAnalyzer.Core.Helpers;

public class GenericMethodHelper
{
    private static Dictionary<(string, Type), MethodInfo> methodCache = new();

    public static TRet InvokeGenericStatic<TRet>(Type type, string method, Type[] genericTypes, params object[] parameters)
    {
        var cacheName = $"{type.Name}.{method}";
        if (!methodCache.TryGetValue((cacheName, typeof(TRet)), out var m))
        {
            m = type.GetMethod(method, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static).MakeGenericMethod(genericTypes);
            methodCache.Add((cacheName, typeof(TRet)), m);
        }
        return (TRet)m.Invoke(null, parameters);
    }
}
