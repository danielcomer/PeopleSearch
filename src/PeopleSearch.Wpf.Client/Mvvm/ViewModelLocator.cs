using PeopleSearch.ViewModel;
using PeopleSearch.Wpf.Client.IoC;

namespace PeopleSearch.Wpf.Client.Mvvm
{
    public class ViewModelLocator
    {
        public PersonSearchViewModel PersonSearchViewModel => NinjectServiceLocator.Get<PersonSearchViewModel>();
    }
}
