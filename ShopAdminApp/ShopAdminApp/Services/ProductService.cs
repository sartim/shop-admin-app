using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ShopAdminApp.Services
{
    public class ProductService : BaseService
    {
        public async Task<T> GetAsync<T>(string url)
        {
            return await SendRequestAsync<T>(HttpMethod.Get, url);
        }

        public async Task<T> PostAsync<T>(string url, object data)
        {
            return await SendRequestAsync<T>(HttpMethod.Post, url, data);
        }

        public async Task<T> PutAsync<T>(string url, object data)
        {
            return await SendRequestAsync<T>(HttpMethod.Put, url, data);
        }

        public async Task<bool> DeleteAsync(string url)
        {
            HttpResponseMessage response = await _client.DeleteAsync(url);
            return response.IsSuccessStatusCode;
        }
    }
}
