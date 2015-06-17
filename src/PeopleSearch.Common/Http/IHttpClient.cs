using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace PeopleSearch.Common.Http
{
    public interface IHttpClient : IDisposable
    {
        Task<Stream> GetStreamAsync(Uri requestUri);
        Task<HttpResponseMessage> PostAsync(Uri requestUri, HttpContent content);
    }
}
