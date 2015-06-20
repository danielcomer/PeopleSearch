using PeopleSearch.Wpf.Client.IoC;
using PersonSearchViewModel = PeopleSearch.Wpf.Client.ViewModels.PersonSearchViewModel;

namespace PeopleSearch.Wpf.Client.Mvvm
{
    public class ViewModelLocator
    {
        public PersonSearchViewModel PersonSearchViewModel => NinjectServiceLocator.Get<PersonSearchViewModel>();
    }
}
