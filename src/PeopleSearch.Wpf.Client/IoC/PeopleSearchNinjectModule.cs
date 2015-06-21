using Ninject.Extensions.NamedScope;
using Ninject.Modules;
using PeopleSearch.Data.Entity;
using PeopleSearch.Wpf.Client.ViewModels;

namespace PeopleSearch.Wpf.Client.IoC
{
    public class PeopleSearchNinjectModule : NinjectModule
    {
        public override void Load()
        {
            // see: http://stackoverflow.com/questions/7647912/why-re-initiate-the-dbcontext-when-using-the-entity-framework
            Bind<IPeopleSearchDbContext>().To<PeopleSearchDbContext>().InParentScope();
            Bind<IPersonSearchViewModel>().To<PersonSearchViewModel>().InTransientScope();
        }
    }
}
