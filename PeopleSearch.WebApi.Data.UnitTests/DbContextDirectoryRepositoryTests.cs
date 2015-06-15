using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Entity;
using Moq;
using PeopleSearch.WebApi.Data.Entities;
using Xunit;

namespace PeopleSearch.WebApi.Data.UnitTests
{
    public class DbContextDirectoryRepositoryTests
    {
        private readonly Mock<DbSet<Person>> _mockPersonSet;
        private readonly Mock<DirectoryDbContext> _mockContext;
        private readonly DbContextDirectoryRepository _repository;

        public DbContextDirectoryRepositoryTests()
        {
            _mockPersonSet = new Mock<DbSet<Person>>();
            _mockContext = new Mock<DirectoryDbContext>();
            _repository = new DbContextDirectoryRepository(_mockContext.Object);
        }

        [Fact]
        public void GetAllPeople_ReturnsAllPeople()
        {
            _mockPersonSet.DbSetReturns(new List<Person>
            {
                new Person {Id = 1},
                new Person {Id = 2}
            });
            
            _mockContext.Setup(c => c.People).Returns(_mockPersonSet.Object);

            var peopleResult = _repository.GetAllPeople();

            Assert.Equal(2, peopleResult.Count());
        }
    }
}