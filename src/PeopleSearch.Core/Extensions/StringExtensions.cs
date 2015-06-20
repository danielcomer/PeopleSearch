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

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Only works with the en-US CultureIno
        /// </remarks>
        /// <param name="value"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static string Pluralize(this string value, int count = int.MaxValue)
        {
            if (count == 1)
            {
                return value;
            }

            return PluralizationService
                .CreateService(new CultureInfo("en-US"))
                .Pluralize(value);
        }
    }
}
