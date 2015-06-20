using System;
using System.Collections.Generic;
using PeopleSearch.Core.Extensions;
using Xunit;

namespace PeopleSearch.Core.UnitTests.Extensions
{
    public class StringExtensionsTest
    {
        public static readonly List<object[]> Data = new List<object[]>
        {
            new object[] { "Hello World!", "hello", StringComparison.CurrentCultureIgnoreCase, true },
            new object[] { "Hello World!", "hello", StringComparison.InvariantCultureIgnoreCase, true },
            new object[] { "Hello World!", "hello", StringComparison.CurrentCulture, false },
            new object[] { "Hello World!", "hello", StringComparison.InvariantCulture, false },
            new object[] { "", "", null, true },
            new object[] { "SomeString", "SomeOtherString", StringComparison.CurrentCulture, false }
        };

        [Theory, MemberData(nameof(Data))]
        public void ContainsTheory(string source, string compareValue, StringComparison comparison, bool expectedResult)
        {
            var result = source.Contains(compareValue, comparison);

            Assert.Equal(result, expectedResult);
        }

        [Fact]
        public void Contains_WithNullMatch_ThrowsException()
        {
            var exception = Assert.Throws<ArgumentNullException>(() =>
            {
                // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
                // ReSharper disable once AssignNullToNotNullAttribute
                "Hello World!".Contains(null, StringComparison.CurrentCulture);
            });

            Assert.Equal("value", exception.ParamName);
        }
    }
}
