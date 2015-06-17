using Ninject.Extensions.NamedScope;
using Ninject.Modules;
using PeopleSearch.Common.Configuration;
using PeopleSearch.Common.Http;
using PeopleSearch.Entities;
using PeopleSearch.Model.Http;
using PeopleSearch.ViewModel;
using PeopleSearch.Wpf.Client.Configuration;

namespace PeopleSearch.Wpf.Client.IoC
{
    public class PeopleSearchNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IConfigurationProvider>().To<ConfigurationProvider>();
            Bind<IHttpClient>().To<HttpClientWrapper>().InParentScope();
            Bind<SimpleJsonRestfulClient<Person>>().To<PeopleRestfulClient>().InSingletonScope();
            Bind<PersonSearchViewModel>().ToSelf().InTransientScope();
        }
    }
}
