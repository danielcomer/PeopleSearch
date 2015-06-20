using Ninject.Modules;
using PersonSearchViewModel = PeopleSearch.Wpf.Client.ViewModels.PersonSearchViewModel;

namespace PeopleSearch.Wpf.Client.IoC
{
    public class PeopleSearchNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<PersonSearchViewModel>().ToSelf().InTransientScope();
        }
    }
}
