using PeopleSearch.Wpf.Client.IoC;
using PeopleSearch.Wpf.Client.ViewModels;

namespace PeopleSearch.Wpf.Client.Mvvm
{
    public class ViewModelLocator
    {
        public IPersonSearchViewModel PersonSearchViewModel => NinjectServiceLocator.Get<IPersonSearchViewModel>();
    }
}
