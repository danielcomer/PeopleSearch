using System.Collections.Generic;
using System.Windows.Input;
using PeopleSearch.Data.Entity.Model;
using PeopleSearch.Wpf.Client.Mvvm;

namespace PeopleSearch.Wpf.Client.ViewModels
{
    public interface IPersonSearchViewModel
    {
        IObservableTask<IList<Person>> People { get; }
        ICommand SearchByName { get; }
    }
}
