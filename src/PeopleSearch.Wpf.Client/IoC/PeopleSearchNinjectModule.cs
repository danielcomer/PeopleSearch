using System.Configuration;
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
            Bind<IPeopleServiceContext>()
                .To<PeopleServiceContext>()
                .InParentScope()
                .WithConstructorArgument(typeof (string),
                    ConfigurationManager.AppSettings["PeopleServiceContext:DbConnectionString"]);

            Bind<IPersonSearchViewModel>().To<PersonSearchViewModel>().InTransientScope();
        }
    }
}
