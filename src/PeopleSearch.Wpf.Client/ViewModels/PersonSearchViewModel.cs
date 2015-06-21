using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Windows.Input;
using PeopleSearch.Data.Entity;
using PeopleSearch.Wpf.Client.Mvvm;

namespace PeopleSearch.Wpf.Client.ViewModels
{
    public class PersonSearchViewModel : ViewModelBase
    {
        private readonly PeopleSearchDbContext _dbContext;

        #region Private Members

        private string _searchString = string.Empty;
        private ObservableTask<IEnumerable<Person>> _people;

        #endregion

        #region Public Properties
        
        public string SearchString
        {
            get { return _searchString; }
            set { SetValue(ref _searchString, value); }
        }

        public Mvvm.ObservableTask<IEnumerable<Person>> People
        {
            get { return _people; }
            private set { SetValue(ref _people, value); }
        }

        #endregion

        #region Commmands

        public ICommand SearchCommand { get; private set; }

        #endregion

        #region Constructors

        public PersonSearchViewModel(PeopleSearchDbContext dbContext)
        {
            _dbContext = dbContext;

            SearchCommand = new RelayCommand<object>(ExecuteSearchCommand);

            //People = new Mvvm.ObservableTask<IEnumerable<Person>>();
        }

        #endregion

        #region Methods
        
        private void ExecuteSearchCommand(object o)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
