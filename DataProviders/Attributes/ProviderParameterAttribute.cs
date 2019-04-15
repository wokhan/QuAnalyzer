using System;
using System.Collections.Generic;

namespace Wokhan.Data.Providers.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class ProviderParameterAttribute : Attribute
    {
        public string Description;
        public bool IsEncoded;
        public bool IsFile;
        public string FileFilter;
        public string ExclusionGroup;
        public int Position = Int32.MaxValue;

        private MethodDel method;
        public delegate Dictionary<string, string> MethodDel();
        public MethodDel Method { get { return method; } }

        public ProviderParameterAttribute() { }

        public ProviderParameterAttribute(string description, bool isEnc = false, Type type = null, string methodName = null)
        {
            Description = description;
            IsEncoded = isEnc;
            if (type != null && methodName != null)
            {
                method = (MethodDel)Delegate.CreateDelegate(typeof(MethodDel), type, methodName);
            }
        }

    }
}
