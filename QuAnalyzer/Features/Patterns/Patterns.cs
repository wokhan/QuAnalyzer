using System;
using System.Linq;

namespace QuAnalyzer.Features.Patterns
{
    internal class Patterns
    {
        internal static string GetRegEx(string src, int threshold)
        {
            if (src == null)
            {
                return null;
            }

            var ex = ' ';
            var cpt = 1;

            return src.Select(c => c >= 'A' && c <= 'Z' ? 'w' : c >= 'a' && c <= 'z' ? 'w' : c >= '0' && c <= '9' ? 'd' : threshold == 3 ? 'x' : c)
                  .Select(c =>
                  {
                      if (c == ex)
                      {
                          cpt++;
                          return String.Empty;
                      }
                      else if (ex != ' ')
                      {
                          var ret = Form(ex, cpt, threshold);
                          ex = c;
                          cpt = 1;
                          return ret;
                      }
                      else
                      {
                          ex = c;
                          return String.Empty;
                      }
                  })
                  .Aggregate((a, b) => a + b) + Form(ex, cpt, threshold);
        }

        private static string Form(char c, int cpt, int threshold)
        {
            if (threshold == 1)
            {
                return "\\" + c + "{" + cpt + "}";
            }
            else
            {
                return "\\" + c + "*";
            }
        }
    }
}
