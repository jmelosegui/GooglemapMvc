using System;

namespace Jmelosegui.Mvc.Googlemap
{
    static class StringExtensions
    {
        public static bool HasValue(this string source)
        {
            return !String.IsNullOrWhiteSpace(source);
        }
    }
}