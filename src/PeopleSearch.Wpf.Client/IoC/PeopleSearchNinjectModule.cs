using System;
using System.Configuration;
using Ninject.Extensions.NamedScope;
using Ninject.Modules;
using PeopleSearch.Core.Infrastructure;
using PeopleSearch.Data.Entity;
using PeopleSearch.Wpf.Client.Mvvm;
using PeopleSearch.Wpf.Client.ViewModels;

namespace PeopleSearch.Wpf.Client.IoC
{
    public class PeopleSearchNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IEventAggregator>().To<DefaultEventAggregator>().InSingletonScope();

            Bind<IObservableTaskFactory>()
                .To<DefaultObservableTaskFactory>()
                .InSingletonScope()
                .WithConstructorArgument(typeof (TimeSpan?),
                    TimeSpan.FromMilliseconds(
                        int.Parse(ConfigurationManager.AppSettings["SimulatedDelayInMilleseconds"])));

            Bind<IPeopleServiceContext>()
                .To<PeopleServiceDbContext>()
                .InParentScope()
                .WithConstructorArgument(typeof (string),
                    ConfigurationManager.AppSettings["PeopleServiceContext:DbConnectionString"]);

            Bind<IPersonSearchViewModel>().To<PersonSearchViewModel>().InTransientScope();
            Bind<IPersonInterestsViewModel>().To<PersonInterestsViewModel>().InTransientScope();
        }
    }
}
