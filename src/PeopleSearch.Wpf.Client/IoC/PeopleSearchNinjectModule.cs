using Ninject.Modules;
using PeopleSearch.Common.Http;
using PeopleSearch.Entities;
using PeopleSearch.Model.Http;
using PeopleSearch.ViewModel;

namespace PeopleSearch.Wpf.Client.IoC
{
    public class PeopleSearchNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IHttpClient>().To<HttpClientWrapper>().InTransientScope();
            Bind<SimpleJsonRestfulClient<Person>>().To<PeopleRestfulClient>().InSingletonScope();
            Bind<PersonSearchViewModel>().ToSelf().InTransientScope();
        }
    }
}
