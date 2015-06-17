using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PeopleSearch.Common.Http
{
    public interface IRestfulClient<T> : IDisposable
    {
        Task<IEnumerable<T>> GetAll();

        Task<T> Get(int id);

        Task<IEnumerable<T>> Search(string searchTerm, string searchValue);
    }
}
