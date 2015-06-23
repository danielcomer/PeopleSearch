using System.Collections.Generic;
using PeopleSearch.Data.Entity.Model;
using PeopleSearch.Wpf.Client.Mvvm;

namespace PeopleSearch.Wpf.Client.ViewModels
{
    public interface IPersonInterestsViewModel
    {
        IObservableTask<IList<Interest>> Interests { get; }
    }
}