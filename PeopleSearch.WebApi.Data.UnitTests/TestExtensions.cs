using System.Collections.Generic;
using System.Linq;
using KellermanSoftware.CompareNetObjects;
using Microsoft.Data.Entity;
using Moq;
using Xunit;

namespace PeopleSearch.WebApi.Data.UnitTests
{
    public static class TestExtensions
    {
        public static void Returns<T>(this Mock<DbSet<T>> mockSet, IEnumerable<T> enumerable) where T : class
        {
            Returns(mockSet, enumerable.AsQueryable());
        }

        public static void Returns<T>(this Mock<DbSet<T>> mockSet, IQueryable<T> queryable) where T : class 
        {
            mockSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(queryable.Provider);
            mockSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(queryable.Expression);
            mockSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            mockSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(queryable.GetEnumerator());
        }

        public static bool IsEqualTo<T>(this T rhs, T lhs)
        {
            var compareLogic = new CompareLogic();
            var comparisonresult = compareLogic.Compare(rhs, lhs);
            return comparisonresult.AreEqual;
        }
    }

    public class TestExtensionsTests
    {
        [Fact]
        public void Returns_WithEnumerable_ConfiguresExpectedProperties()
        {
            var mockSet = new Mock<DbSet<string>>();

            mockSet.Returns(new List<string> { "One", "Two", "Three"});

            Assert.True(mockSet.Object.SequenceEqual(new List<string> { "One", "Two", "Three" }));
        }
    }
}