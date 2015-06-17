using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
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

        private List<Person> _people;
        private string _loadingMessage = string.Empty;
        private string _searchString = string.Empty;

        #endregion

        #region Public Properties

        public string LoadingMessage
        {
            get { return _loadingMessage; }
            set { SetValue(ref _loadingMessage, value, new [] { nameof(IsLoading) } ); }
        }

        public bool IsLoading
        {
            get { return !string.IsNullOrEmpty(LoadingMessage); }
        }

        public string SearchString
        {
            get { return _searchString; }
            set { SetValue(ref _searchString, value); }
        }

        public List<Person> People
        {
            get { return _people; }
            set { SetValue(ref _people, value); }
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
            SearchCommand = new AsyncDelegateCommand(ExecuteSearchCommand);
        }

        private async Task ExecuteSearchCommand(object o)
        {
            var results = await _peopleRestClient.GetAll();
            People = results.ToList();
        }

        #endregion
    }
}
