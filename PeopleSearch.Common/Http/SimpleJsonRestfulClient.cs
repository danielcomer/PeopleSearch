using System;
using System.Collections.Generic;
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

        public SimpleJsonRestfulClient(IHttpClient client, string baseUrl)
        {
            _serializer = new DataContractJsonSerializer(typeof(T));
            _baseUri = new Uri(baseUrl);
            _client = client;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            using (var result = await _client.GetStreamAsync(_baseUri).ConfigureAwait(false))
            {
                return (IEnumerable<T>)_serializer.ReadObject(result);
            }
        }

        public async Task<T> Get(int id)
        {
            using (var result = await _client.GetStreamAsync(new Uri(_baseUri, id.ToString())).ConfigureAwait(false))
            {
                return (T)_serializer.ReadObject(result);
            }
        }

        public async Task<T> Post(HttpContent content)
        {
            var response = await PostString(content).ConfigureAwait(false);
            return (T)_serializer.ReadObject(new MemoryStream(Encoding.UTF8.GetBytes(response)));
        }

        private async Task<string> PostString(HttpContent content)
        {
            using (var result = await _client.PostAsync(_baseUri, content).ConfigureAwait(false))
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
