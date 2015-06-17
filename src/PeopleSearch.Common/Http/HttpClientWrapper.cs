using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace PeopleSearch.Common.Http
{
    public class HttpClientWrapper : IHttpClient
    {
        private readonly HttpClient _client = new HttpClient();

        public Task<Stream> GetStreamAsync(Uri requestUri)
        {
            return _client.GetStreamAsync(requestUri);
        }

        public Task<HttpResponseMessage> PostAsync(Uri requestUri, HttpContent content)
        {
            return _client.PostAsync(requestUri, content);
        }

        public void Dispose()
        {
            _client.Dispose();
        }
    }
}
