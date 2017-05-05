using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace QuAnalyzer.DataProviders.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ProviderAttribute : Attribute
    {
        public delegate Dictionary<string, string> MethodDel();
        public MethodDel Method { get; set; }

        public ProviderAttribute(Type type, string methodName)
        {
            this.Method = (MethodDel)Delegate.CreateDelegate(typeof(MethodDel), type, methodName);
        }
    }
}
