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

            var peopleResult = _repository.GetAllPeople().ToList();

            Assert.NotNull(peopleResult);
            Assert.Equal(2, peopleResult.Count());
            Assert.Equal(1, peopleResult.First().Id);
            Assert.Equal(2, peopleResult.Last().Id);
        }

        [Fact]
        public void GetPerson_ReturnsCorrectPerson()
        {
            _mockPersonSet.DbSetReturns(new List<Person>
            {
                new Person {Id = 1},
                new Person {Id = 2}
            });

            _mockContext.Setup(c => c.People).Returns(_mockPersonSet.Object);

            var personResult = _repository.GetPerson(1);

            Assert.NotNull(personResult);
            Assert.Equal(1, personResult.Id);
        }

        [Fact]
        public void AddPerson_AddsCorrectPerson_AndReturnsThePerson()
        {
            _mockPersonSet.DbSetReturns(new List<Person>
            {
                new Person {Id = 1},
                new Person {Id = 2}
            });

            _mockContext.Setup(c => c.SaveChanges()).Returns(1);
            _mockContext.Setup(c => c.People).Returns(_mockPersonSet.Object);

            var person = new Person {Id = 3};
            var personResult = _repository.AddPerson(person);

            Assert.NotNull(personResult);
            Assert.Equal(person.Id, personResult.Id);
        }

        [Fact]
        public void DeletePerson_DeletesCorrectPerson_AndReturnsCorrectValue()
        {
            _mockPersonSet.DbSetReturns(new List<Person>
            {
                new Person {Id = 1},
                new Person {Id = 2}
            });

            _mockContext.Setup(c => c.SaveChanges()).Returns(1);
            _mockContext.Setup(c => c.People).Returns(_mockPersonSet.Object);

            var person1Deleted = _repository.DeletePerson(1);
            var person3Deleted = _repository.DeletePerson(3);

            Assert.True(person1Deleted);
            Assert.False(person3Deleted);
        }
    }
}