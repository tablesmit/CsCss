﻿using System;

namespace Alba.CsCss.Extensions
{
    internal static class StringExts
    {
        public static bool EqualsLiteral (this string @this, string value)
        {
            return string.Equals(@this, value, StringComparison.Ordinal);
        }

        internal static int Length (this string @this)
        {
            return @this.Length;
        }

        public static char First (this string @this)
        {
            return @this.Length > 0 ? @this[0] : '\0';
        }

        internal static bool LowerCaseEqualsLiteral (this string @this, string value)
        {
            return string.Equals(@this, value, StringComparison.OrdinalIgnoreCase);
        }

        internal static bool LowerCaseEqualsASCII (this string @this, string value, int length)
        {
            if (value.Length != length)
                value = value.Substring(0, length);
            return string.Equals(@this, value, StringComparison.OrdinalIgnoreCase);
        }
    }
}