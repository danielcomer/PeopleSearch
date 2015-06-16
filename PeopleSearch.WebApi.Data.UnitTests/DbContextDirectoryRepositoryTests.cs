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

        private readonly List<Person> _people;
        private readonly Person _person1;
        private readonly Person _person2;

        public DbContextDirectoryRepositoryTests()
        {
            _person1 = new Person {Id = 1, FirstName = "FirstName1", LastName = "LastName1"};
            _person2 = new Person {Id = 2, FirstName = "FirstName2", LastName = "LastName2" };

            _people = new List<Person> {_person1, _person2};

            _mockPersonSet = new Mock<DbSet<Person>>();
            _mockPersonSet.Returns(_people);

            _mockContext = new Mock<DirectoryDbContext>();
            _repository = new DbContextDirectoryRepository(_mockContext.Object);
        }

        [Fact]
        public void GetAllPeople_ReturnsAllPeople()
        {
            _mockContext.Setup(c => c.People).Returns(_mockPersonSet.Object);

            var peopleResult = _repository.GetAllPeople().ToList();

            Assert.NotNull(peopleResult);

            Assert.True(_people.IsEqualTo(peopleResult));
        }

        [Fact]
        public void GetPerson_ReturnsCorrectPerson()
        {
            _mockContext.Setup(c => c.People).Returns(_mockPersonSet.Object);

            var person1Result = _repository.GetPerson(1);
            var person3Result = _repository.GetPerson(3);

            Assert.Null(person3Result);
            Assert.NotNull(person1Result);
            Assert.True(_person1.IsEqualTo(person1Result));
        }

        [Fact]
        public void AddPerson_AddsCorrectPerson_AndReturnsThePerson()
        {
            _mockContext.Setup(c => c.SaveChanges()).Returns(1);
            _mockContext.Setup(c => c.People).Returns(_mockPersonSet.Object);

            var person = new Person {Id = 3};
            var personResult = _repository.AddPerson(person);

            Assert.NotNull(personResult);
            Assert.Equal(person.Id, personResult.Id);
        }

        [Fact]
        public void AddPerson_WhenSaveChangesReturns0_ReturnsNull()
        {
            _mockContext.Setup(c => c.SaveChanges()).Returns(0);
            _mockContext.Setup(c => c.People).Returns(_mockPersonSet.Object);

            var person = new Person { Id = 3 };
            var personResult = _repository.AddPerson(person);

            Assert.Null(personResult);
        }

        [Fact]
        public void DeletePerson_DeletesCorrectPerson_AndReturnsCorrectValue()
        {
            _mockContext.Setup(c => c.SaveChanges()).Returns(1);
            _mockContext.Setup(c => c.People).Returns(_mockPersonSet.Object);

            Assert.True(_repository.DeletePerson(1));
            Assert.False(_repository.DeletePerson(3));

            _mockContext.Verify(c => c.SaveChanges(), Times.Exactly(1));
        }
    }
}