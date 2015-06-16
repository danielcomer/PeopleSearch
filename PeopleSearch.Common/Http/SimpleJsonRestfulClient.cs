using System;
using System.IO;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace PeopleSearch.Common.Http
{
    public class SimpleJsonRestfulClient<T> : IRestfulClient<T>
    {
        private readonly IHttpClient _client;
        private readonly DataContractJsonSerializer _serializer;
        private readonly Uri _baseUri;

        public SimpleJsonRestfulClient(string baseUrl)
        {
            _serializer = new DataContractJsonSerializer(typeof(T));
            _baseUri = new Uri(baseUrl);
            //_client = new HttpClient();
        }

        public async Task<T> Get(string path)
        {
            Uri url;
            if (!Uri.TryCreate(_baseUri, path, out url))
            {
                throw new ArgumentException("Invalid path.", nameof(path));
            }

            using (var result = await _client.GetStreamAsync(url).ConfigureAwait(false))
            {
                return (T)_serializer.ReadObject(result);
            }
        }

        public async Task<T> Post(string path, HttpContent content)
        {
            var response = await PostString(path, content).ConfigureAwait(false);
            return (T)_serializer.ReadObject(new MemoryStream(Encoding.UTF8.GetBytes(response)));
        }

        private async Task<string> PostString(string path, HttpContent content)
        {
            Uri url;
            if (!Uri.TryCreate(_baseUri, path, out url))
            {
                throw new ArgumentException("Invalid path.", nameof(path));
            }

            using (var result = await _client.PostAsync(url, content).ConfigureAwait(false))
            {
                return await result.Content.ReadAsStringAsync().ConfigureAwait(false);
            }
        }
        
        public void Dispose()
        {
            _client.Dispose();
        }
    }
}
