using System.Collections.Generic;
using System.Linq;
using PeopleSearch.Data.Entity.Model;
using PeopleSearch.Data.Migrations;
using PeopleSearch.Wpf.Client.Mvvm;

namespace PeopleSearch.Wpf.Client.ViewModels
{
    public class DesignTimePersonInterestsViewModel : IPersonInterestsViewModel
    {
        public IObservableTask<IList<Interest>> Interests => new FakeObservableTask<IList<Interest>>
        {
            Result = FakeDataFactory.CreateInterests().Take(60).ToList(),
            IsSuccessfullyCompleted = true
        };
    }
}
