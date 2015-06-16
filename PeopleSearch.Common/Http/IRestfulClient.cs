using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace PeopleSearch.Common.Http
{
    public interface IRestfulClient<T> : IDisposable
    {
        Task<T> Get(string parameters);
        Task<T> Post(string apiPath, HttpContent content);
    }
}
