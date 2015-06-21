using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows.Input;
using PeopleSearch.Core.Extensions;
using PeopleSearch.Data.Entity;
using PeopleSearch.Wpf.Client.Mvvm;

namespace PeopleSearch.Wpf.Client.ViewModels
{
    //todo: consider autosearching on property changed "SearchString" instead of the command.
    public class PersonSearchViewModel : ViewModelBase, IPersonSearchViewModel
    {
        #region Members

        private readonly IPeopleSearchDbContext _dbContext;
        private string _searchString = string.Empty;
        private IObservableTask<IList<Person>> _people;

        #endregion

        #region Properties

        #region Observable

        public string SearchString
        {
            get { return _searchString; }
            set { SetBackingMemberValue(ref _searchString, value); }
        }

        public IObservableTask<IList<Person>> People
        {
            get { return _people; }
            private set { SetBackingMemberValue(ref _people, value); }
        }

        #endregion

        #endregion

        #region Commmands

        public ICommand SearchByNameCommand { get; private set; }

        #endregion

        #region Constructors

        public PersonSearchViewModel(IPeopleSearchDbContext dbContext)
        {
            _dbContext = dbContext;

            SearchByNameCommand = new RelayCommand<string>(ExecuteSearchByNameCommand, s => !string.IsNullOrEmpty(s));

            var query = _dbContext.People.ToListAsync();

            People = new ObservableTask<List<Person>>(query);
        }

        #endregion

        #region Methods
        
        private void ExecuteSearchByNameCommand(string personName)
        {
            var searchString = personName ?? SearchString;

            var query = _dbContext.People.Where(p => (p.FirstName + p.LastName)
                    .Contains(searchString, StringComparison.CurrentCultureIgnoreCase))
                    .ToListAsync();

            People = new ObservableTask<List<Person>>(query);
        }

        #endregion
    }
}
