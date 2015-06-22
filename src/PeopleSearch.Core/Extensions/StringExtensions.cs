using System;
using System.Data.Entity.Design.PluralizationServices;
using System.Globalization;

namespace PeopleSearch.Core.Extensions
{
    public static class StringExtensions
    {
        public static bool Contains(this string source, string value, StringComparison comp = StringComparison.CurrentCulture)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            return source.IndexOf(value, comp) >= 0;
        }
    }
}
