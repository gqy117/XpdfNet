using System;
using System.Collections.Generic;
using System.Text;

namespace Xpdf.Wrapper
{
    internal static class Extensions
    {
        public static object ThrowIfNull(this object obj, string param, string message = null)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(param, message);
            }

            return obj;
        }

        public static string ThrowIfWhite(this string str, string param, string message = null)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                throw new ArgumentNullException(param, message);
            }

            return str;
        }

        public static string ThrowIfEmpty(this string str, string param, string message = null)
        {
            if (string.IsNullOrEmpty(str))
            {
                throw new ArgumentNullException(param, message);
            }

            return str;
        }
    }
}
