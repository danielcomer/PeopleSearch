using System.Collections.Generic;
using System.Linq;
using PeopleSearch.Data.Entity.Model;
using PeopleSearch.Data.Migrations;
using PeopleSearch.Wpf.Client.Mvvm;

namespace PeopleSearch.Wpf.Client.ViewModels
{
    public class DesignTimePersonInterestsViewModel : IPersonInterestsViewModel
    {
        public IObservableTask<List<Interest>> Interests => new FakeObservableTask<List<Interest>>
        {
            Result = FakeDataFactory.CreateInterests().Take(60).ToList(),
            IsSuccessfullyCompleted = true
        };
    }
}
