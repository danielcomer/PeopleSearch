using PeopleSearch.Common.Http;
using PeopleSearch.Common.Mvvm;
using PeopleSearch.Entities;

namespace PeopleSearch.ViewModel
{
    public class PersonListViewModel : ViewModelBase
    {
        private readonly SimpleJsonRestfulClient<Person> _peopleRestClient;

        private string _loadingString = "";

        public string LoadingString
        {
            get { return _loadingString; }
            set
            {
                SetValue(ref _loadingString, value);
            }
        }

        public PersonListViewModel(SimpleJsonRestfulClient<Person> peopleRestClient)
        {
            _peopleRestClient = peopleRestClient;
        }
    }
}
