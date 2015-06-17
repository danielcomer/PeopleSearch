using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace PeopleSearch.Common.Http
{
    public interface IRestfulClient<T> : IDisposable
    {
        Task<IEnumerable<T>> GetAll();

        Task<T> Get(int id);

        Task<T> Post(HttpContent content);
    }
}
