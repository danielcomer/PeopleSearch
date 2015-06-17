using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using PeopleSearch.Common.Http;
using PeopleSearch.Common.Mvvm;
using PeopleSearch.Entities;

namespace PeopleSearch.ViewModel
{
    public class PersonSearchViewModel : ViewModelBase
    {
        #region Private Members

        private readonly SimpleJsonRestfulClient<Person> _peopleRestClient;

        private string _searchString = string.Empty;
        private ObservableTask<IEnumerable<Person>> _people;

        #endregion

        #region Public Properties
        
        public string SearchString
        {
            get { return _searchString; }
            set { SetValue(ref _searchString, value); }
        }

        public ObservableTask<IEnumerable<Person>> People
        {
            get { return _people; }
            private set { SetValue(ref _people, value); }
        }

        #endregion

        #region Commmands

        public ICommand SearchCommand { get; private set; }

        #endregion

        #region Constructors

        public PersonSearchViewModel(SimpleJsonRestfulClient<Person> peopleRestClient)
        {
            _peopleRestClient = peopleRestClient;

            ConstructCommands();

            PropertyChanged += HandlePropertyChanged;
        }

        private void HandlePropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            ((DelegateCommand) SearchCommand).IsEnabled = !string.IsNullOrEmpty(SearchString);
        }

        #endregion

        #region Methods

        private void ConstructCommands()
        {
            SearchCommand = new DelegateCommand(ExecuteSearchCommand);
        }

        private void ExecuteSearchCommand(object o)
        {
            People = new ObservableTask<IEnumerable<Person>>(_peopleRestClient.GetAll());
        }

        #endregion
    }
}
