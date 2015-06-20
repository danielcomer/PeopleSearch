using System;
using PeopleSearch.Core.Extensions;
using Xunit;

namespace PeopleSearch.Core.UnitTests.Extensions
{
    public class StringExtensionsTest
    {
        [Theory]
        [InlineData("Hello World!", "hello", StringComparison.CurrentCultureIgnoreCase, true)]
        [InlineData("Hello World!", "hello", StringComparison.InvariantCultureIgnoreCase, true)]
        [InlineData("Hello World!", "hello", StringComparison.CurrentCulture, false)]
        [InlineData("Hello World!", "hello", StringComparison.InvariantCulture, false)]
        [InlineData("", "", null, true)]
        [InlineData("SomeString", "SomeOtherString", StringComparison.CurrentCulture, false)]
        public void ContainsTheory(string source, string compareValue, StringComparison comparison, bool expectedResult)
        {
            var result = source.Contains(compareValue, comparison);

            Assert.Equal(expectedResult, result);
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

        [Theory]
        [InlineData("Person", 1, "Person")]
        [InlineData("Person", 0, "People")]
        [InlineData("Person", -1, "People")]
        [InlineData("Mouse", 2, "Mice")]
        [InlineData("Interest", 2, "Interests")]
        public void PluralizeTheory(string source, int count, string expectedResult)
        {
            var result = source.Pluralize(count);

            Assert.Equal(expectedResult, result);
        }
    }
}
