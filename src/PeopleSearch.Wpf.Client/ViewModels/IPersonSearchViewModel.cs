using System.Collections.Generic;
using System.Windows.Input;
using PeopleSearch.Data.Entity;
using PeopleSearch.Wpf.Client.Mvvm;

namespace PeopleSearch.Wpf.Client.ViewModels
{
    public interface IPersonSearchViewModel
    {
        string SearchString { get; set; }
        IObservableTask<IList<Person>> People { get; }

        ICommand SearchByNameCommand { get; }
    }
}
