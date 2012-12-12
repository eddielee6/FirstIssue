using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstIssue.WebApp.AppCode.ExtensionMethods
{
    public static class StringExtensions
    {
        public static bool EqualIgnoreCase(this string a, string b)
        {
            return string.Equals(a, b, StringComparison.OrdinalIgnoreCase);
        }

        public static bool StartsWithIgnoreCase(this string str, string strToFind)
        {
            return str.StartsWith(strToFind, StringComparison.OrdinalIgnoreCase);
        }
    }
}