using System;
using System.Linq;

namespace Wokhan.Core.Extensions
{
    public static class StringExtensions
    {

        public static T AnonymousToKnownType<T>(this object o) where T : class
        {
            return (T)o;
        }

        public static dynamic ToObject(this object[] o, Type targetclass, string[] attributes)
        {
            var trg = Activator.CreateInstance(targetclass);

            var pr = attributes.Join(targetclass.GetProperties(), a => a, b => b.Name, (a, b) => b).ToList();
            for (int i = 0; i < pr.Count; i++)
            {
                if (o[i] != DBNull.Value && o[i] != null)
                {
                    pr[i].SetValue(trg, o[i]);
                }
            }

            return Convert.ChangeType(trg, targetclass);
        }

        public static T ToObject<T>(this object[] o, string[] attributes)
        {
            return ToObject(o, typeof(T), attributes);
        }

        public static T ToObject<T>(this string[] o, string[] attributes)
        {
            var trg = (T)Activator.CreateInstance(typeof(T));

            var pr = attributes.Join(typeof(T).GetProperties(), a => a, b => b.Name, (a, b) => b).ToList();
            for (int i = 0; i < pr.Count; i++)
            {
                pr[i].SetValue(trg, o[i]);
            }

            return trg;
        }

        /// <summary>
        /// Truncates a string to the specified max length (if needed)
        /// </summary>
        /// <param name="source">Source string</param>
        /// <param name="maxlength">Maximum length to truncate the string at</param>
        /// <returns></returns>
        public static string Truncate(this string str, int maxLen)
        {
            return str.Length > maxLen ? str.Substring(0, maxLen) : str;
        }


    }

}
