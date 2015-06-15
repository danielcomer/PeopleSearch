using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Entity;
using Moq;

namespace PeopleSearch.WebApi.Data.UnitTests
{
    public static class TestExtensions
    {
        public static void DbSetReturns<T>(this Mock<DbSet<T>> mockSet, IEnumerable<T> enumerable) where T : class
        {
            DbSetReturns(mockSet, enumerable.AsQueryable());
        }

        public static void DbSetReturns<T>(this Mock<DbSet<T>> mockSet, IQueryable<T> queryable) where T : class 
        {
            mockSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(queryable.Provider);
            mockSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(queryable.Expression);
            mockSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            mockSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(queryable.GetEnumerator());
        }
    }
}