using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows.Input;
using PeopleSearch.Data.Entity;
using PeopleSearch.Data.Entity.Model;
using PeopleSearch.Wpf.Client.Mvvm;

namespace PeopleSearch.Wpf.Client.ViewModels
{
    public class PersonSearchViewModel : ViewModelBase, IPersonSearchViewModel
    {
        #region Members

        private readonly IPeopleServiceContext _dbContext;
        private readonly IObservableTaskFactory _taskFactory;
        private IObservableTask<IList<Person>> _people;

        #endregion

        #region Properties

        #region Observable

        public IObservableTask<IList<Person>> People
        {
            get { return _people; }
            private set { SetBackingMemberValue(ref _people, value); }
        }

        #endregion

        #endregion

        #region Commmands

        public ICommand SearchByName { get; }

        #endregion

        #region Constructors

        public PersonSearchViewModel(IPeopleServiceContext dbContext, IObservableTaskFactory taskFactory)
        {
            _dbContext = dbContext;
            _taskFactory = taskFactory;

            SearchByName = new RelayCommand<string>(ExecuteSearchByNameCommand);
            People = _taskFactory.Create(CreateQuery().ToListAsync());
        }

        #endregion

        #region Methods
        
        private void ExecuteSearchByNameCommand(string personName)
        {
            People = _taskFactory.Create(CreateQuery(personName).ToListAsync());
        }

        private IQueryable<Person> CreateQuery(string personName = null)
        {
            var query = _dbContext.People.Include(p => p.HomeAddress);

            if (!string.IsNullOrEmpty(personName))
            {
                query = query.Where(p =>
                    p.FirstName.ToUpper().Contains(personName.ToUpper()) ||
                    p.LastName.ToUpper().Contains(personName.ToUpper()));
            }

            return query;
        }

        #endregion
    }
}
