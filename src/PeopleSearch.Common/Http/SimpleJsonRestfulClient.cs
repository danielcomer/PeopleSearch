using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;

namespace PeopleSearch.Common.Http
{
    public abstract class SimpleJsonRestfulClient<T> : IRestfulClient<T>
    {
        private readonly IHttpClient _client;
        private readonly DataContractJsonSerializer _serializer;
        private readonly DataContractJsonSerializer _listSerializer;
        private readonly Uri _baseUri;

        protected SimpleJsonRestfulClient(IHttpClient client, string baseUrl)
        {
            _serializer = new DataContractJsonSerializer(typeof(T));
            _listSerializer = new DataContractJsonSerializer(typeof(IEnumerable<T>));
            _baseUri = new Uri(baseUrl);
            _client = client;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            using (var result = await _client.GetStreamAsync(_baseUri).ConfigureAwait(false))
            {
                return (IEnumerable<T>)_listSerializer.ReadObject(result);
            }
        }

        public async Task<IEnumerable<T>> Search(string searchTerm, string searchValue)
        {
            using (var result = await _client.GetStreamAsync(new Uri(_baseUri, "search/" + searchTerm + "/" + searchValue)).ConfigureAwait(false))
            {
                return (IEnumerable<T>)_listSerializer.ReadObject(result);
            }
        }

        public async Task<T> Get(int id)
        {
            using (var result = await _client.GetStreamAsync(new Uri(_baseUri, id.ToString())).ConfigureAwait(false))
            {
                return (T)_serializer.ReadObject(result);
            }
        }
        
        public void Dispose()
        {
            _client.Dispose();
        }
    }
}
