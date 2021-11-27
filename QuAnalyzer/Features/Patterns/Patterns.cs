using System;
using System.Linq;

namespace QuAnalyzer.Features.Patterns;

internal class Patterns
{
    internal static string GetRegEx(string src, int threshold)
    {
        if (String.IsNullOrEmpty(src))
        {
            return src;
        }

        var previous = ' ';
        var cpt = 1;

        return src.Select(chr => (chr >= 'A' && chr <= 'Z') || (chr >= 'a' && chr <= 'z') ? 'w'
                                : chr >= '0' && chr <= '9' ? 'd'
                                : threshold == 3 ? 'x'
                                : chr)
                  .Select(chr =>
                  {
                      if (chr == previous)
                      {
                          cpt++;
                          return String.Empty;
                      }
                      else if (previous != ' ')
                      {
                          var ret = Form(previous, cpt, threshold);
                          previous = chr;
                          cpt = 1;
                          return ret;
                      }
                      else
                      {
                          previous = chr;
                          return String.Empty;
                      }
                  })
                  .Aggregate((a, b) => a + b) + Form(previous, cpt, threshold);
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
