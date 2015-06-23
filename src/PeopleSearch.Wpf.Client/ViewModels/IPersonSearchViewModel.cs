using System.Collections.Generic;
using System.Windows.Input;
using PeopleSearch.Data.Entity.Model;
using PeopleSearch.Wpf.Client.Mvvm;

namespace PeopleSearch.Wpf.Client.ViewModels
{
    public interface IPersonSearchViewModel
    {
        Person SelectedPerson { get; }
        IObservableTask<IList<Person>> People { get; }
        ICommand SearchByName { get; }
    }
}
