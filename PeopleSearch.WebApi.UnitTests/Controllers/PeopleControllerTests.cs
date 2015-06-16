using Moq;
using PeopleSearch.WebApi.Data;
using Xunit;
using PeopleSearch.WebApi.Controllers;
using System.Collections.Generic;
using PeopleSearch.WebApi.Data.Entities;
using Microsoft.AspNet.Mvc;
using System.Linq;

namespace PeopleSearch.WebApi.UnitTests.Controllers
{
    public class PeopleControllerTests
    {
        private Mock<IDirectoryRepository> _mockDirectoryRepository;
        private PeopleController _controller;

        public PeopleControllerTests()
        {
            _mockDirectoryRepository = new Mock<IDirectoryRepository>();
            _controller = new PeopleController(_mockDirectoryRepository.Object);
        }

        [Fact]
        public void VerifyIndexReturnsAllEmployees()
        {
            _mockDirectoryRepository
                .Setup(repo => repo.GetAllPeople())
                .Returns(new List<Person> {
                    new Person { Id = 1, FirstName = "FirstName1", LastName="LastName1", Gender = Gender.Male },
                    new Person { Id = 2, FirstName = "FirstName2", LastName="LastName2", Gender = Gender.Male },
                    new Person { Id = 3, FirstName = "FirstName3", LastName="LastName3", Gender = Gender.Male,
                    HomeAddress = new Address { StreetLineOne = "Street 1", City = "City 1", PostalCode = "12345" }
                }
            });

            var result = _controller.Index() as ObjectResult;

            var people = result.Value as List<Person>;

            Assert.NotNull(people);
            Assert.Equal(3, people.Count);
            Assert.Equal(1, people.First().Id);
            Assert.Equal("12345", people.Last().HomeAddress.PostalCode);
        }

        [Fact]
        public void VerifyGetByIdReturnsHttpNotFoundWhenPersonDoesntExist()
        {
            _mockDirectoryRepository
                .Setup(repo => repo.GetPerson(It.IsAny<int>()))
                .Returns<Person>(null);

            var result = _controller.GetById(1) as HttpNotFoundResult;

            Assert.NotNull(result);
        }

        [Fact]
        public void VerifyGetByIdReturnsPerson()
        {
            _mockDirectoryRepository
                .Setup(repo => repo.GetPerson(It.Is<int>(value => value == 1)))
                .Returns(new Person { Id = 1 });
                
            var result = _controller.GetById(1) as ObjectResult;

            var person = result.Value as Person;

            Assert.NotNull(person);
            Assert.Equal(1, person.Id);
        }
    }
}
