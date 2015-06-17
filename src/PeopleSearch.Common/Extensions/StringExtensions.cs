using System;

namespace PeopleSearch.Common.Extensions
{
    public static class StringExtensions
    {
        public static bool Contains(this string source, string toCheck, StringComparison comp)
        {
            if (string.IsNullOrEmpty(source))
            {
                return false;
            }

            if (toCheck == null)
            {
                throw new ArgumentException("Invalid Argument", nameof(toCheck));
            }

            return source.IndexOf(toCheck, comp) >= 0;
        }
    }
}
