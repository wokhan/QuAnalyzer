using QuAnalyzer.Features.Comparison;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace QuAnalyzer.Core.Helpers;

public class GenericMethodHelper
{
    public static TRet InvokeGenericStatic<TRet>(Type type, string method, Type[] genericTypes, params object[] parameters)
    {
        var m = type.GetMethod(method, BindingFlags.Public | BindingFlags.Static).MakeGenericMethod(genericTypes);
        return (TRet)m.Invoke(null, parameters);
    }
}
