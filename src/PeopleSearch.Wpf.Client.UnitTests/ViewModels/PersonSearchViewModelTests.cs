using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using Moq;
using PeopleSearch.Core.Infrastructure;
using PeopleSearch.Data.Entity;
using PeopleSearch.Data.Entity.Model;
using PeopleSearch.Wpf.Client.Mvvm;
using PeopleSearch.Wpf.Client.UnitTests.TestHelpers;
using PeopleSearch.Wpf.Client.ViewModels;
using Xunit;

namespace PeopleSearch.Wpf.Client.UnitTests.ViewModels
{
    public class PersonSearchViewModelTests
    {
        #region Members

        private readonly Mock<IPeopleServiceContext> _dbContextMock;
        private Mock<DbSet<Person>> _personDbSetMock;
        private readonly Mock<IObservableTaskFactory> _taskFactoryMock;
        private readonly Mock<IEventAggregator> _aggregatorMock;
        private readonly Mock<IObservableTask<List<Person>>> _mockObservableTask;

        #endregion Members

        #region Constructors

        public PersonSearchViewModelTests()
        {
            _dbContextMock = new Mock<IPeopleServiceContext>();
            _taskFactoryMock = new Mock<IObservableTaskFactory>();
            _aggregatorMock = new Mock<IEventAggregator>();

            _mockObservableTask = new Mock<IObservableTask<List<Person>>>();
            _taskFactoryMock.Setup(factory => factory.Create(It.IsAny<Task<List<Person>>>())).Returns(_mockObservableTask.Object);

            InitializeData();

            _dbContextMock.Setup(c => c.People).Returns(_personDbSetMock.Object);
        }

        #endregion Constructors

        //[Fact]
        //public async Task Constructor_QueriesAllPeople_ThenLoadsThePeopleProperty()
        //{
        //    var people = new List<Person>
        //    {
        //        new Person {FirstName = "FirstName1", LastName = "LastName1"},
        //        new Person {FirstName = "FirstName2", LastName = "LastName2"},
        //        new Person {FirstName = "FirstName3", LastName = "LastName3"}
        //    };

        //    var mockDummyEntities = MockHelper.CreateDbSet<DerivedDbSet<Person>, Person>(people);
        //    _dbContextMock.Setup(c => c.People).Returns(mockDummyEntities.Object);

        //    //var ot = new ObservableTask<List<Person>>(Task.FromResult(people));

        //    var _mockObservableTask = new Mock<IObservableTask<List<Person>>>();
        //    _mockObservableTask.Setup(ot => ot.TheTask).Returns(Task.FromResult(people));
        //    _mockObservableTask.Setup(ot => ot.Result).Returns(people);

        //    //_taskFactoryMock.Setup(factory => factory.Create(It.IsAny<Task<List<Person>>>())).Returns(ot);
        //    _taskFactoryMock.Setup(factory => factory.Create(It.IsAny<Task<List<Person>>>())).Returns(_mockObservableTask.Object);

        //    var viewModel = CreatePersonSearchViewModel();

        //    //await ot.TheTask;
        //    await _mockObservableTask.Object.TheTask;

        //    Assert.Equal(3, viewModel.People.Result.Count);
        //}

        #region Tests

        [Fact]
        public async Task Constructor_QueriesAllPeople()
        {
            CreatePersonSearchViewModel();

            await _mockObservableTask.Object.TheTask;

            _dbContextMock.Verify(context => context.People, Times.Exactly(1));
        }

        #endregion Tests

        #region Private Methods

        private void InitializeData()
        {
            var people = new List<Person>
            {
                new Person {FirstName = "FirstName1", LastName = "LastName1"},
                new Person {FirstName = "FirstName2", LastName = "LastName2"},
                new Person {FirstName = "FirstName3", LastName = "LastName3"}
            };
            _personDbSetMock = EntityFrameworkMockHelper.CreateDbSet<DbSet<Person>, Person>(people);
            _dbContextMock.Setup(c => c.People).Returns(_personDbSetMock.Object);
        }

        private PersonSearchViewModel CreatePersonSearchViewModel()
        {
            return new PersonSearchViewModel(_dbContextMock.Object, _taskFactoryMock.Object, _aggregatorMock.Object);
        }

        #endregion Private Methods
    }
}
