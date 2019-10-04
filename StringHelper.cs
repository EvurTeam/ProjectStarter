using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProjectStarter
{
    public static class StringHelper
    {
        public static string Macro(this string s, string key, string val, bool repl = true)
        {
            if (repl)
            {
                return s.Replace($"${key}$", val);
            }
            return s.Replace($"${key}$", "");
        }

        public static bool IsNull(this string s)
        {
            return string.IsNullOrWhiteSpace(s);
        }

        public static string RemoveTags(this string s)
        {
            var re = new Regex("(<[^>]*>)");
            return re.Replace(s, "");
        }
    }
}
