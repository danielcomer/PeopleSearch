using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows.Input;
using PeopleSearch.Data.Entity;
using PeopleSearch.Data.Entity.Model;
using PeopleSearch.Wpf.Client.Mvvm;

namespace PeopleSearch.Wpf.Client.ViewModels
{
    //todo: consider autosearching on property changed "SearchString" instead of the command.
    public class PersonSearchViewModel : ViewModelBase, IPersonSearchViewModel
    {
        #region Members

        private readonly IPeopleServiceContext _dbContext;
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

        public PersonSearchViewModel(IPeopleServiceContext dbContext)
        {
            _dbContext = dbContext;

            SearchByName = new RelayCommand<string>(ExecuteSearchByNameCommand);

            var query = _dbContext.People.Include(p => p.HomeAddress).ToListAsync();

            People = new ObservableTask<List<Person>>(query);
        }

        #endregion

        #region Methods
        
        private void ExecuteSearchByNameCommand(string personName)
        {
            var searchString = (personName ?? string.Empty).ToUpper();

            var query =
                _dbContext.People.Include(p => p.HomeAddress)
                    .Where(p => p.FirstName.ToUpper().Contains(searchString) || p.LastName.ToUpper().Contains(searchString))
                    .ToListAsync();

            People = new ObservableTask<List<Person>>(query);
        }

        #endregion
    }
}
