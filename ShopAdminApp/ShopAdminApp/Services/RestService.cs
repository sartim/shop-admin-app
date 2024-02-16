using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ShopAdminApp.Services
{
    public class RestService : BaseService
    {
        public async Task<T> GetAsync<T>(string url, string authToken)
        {
            return await SendRequestAsync<T>(HttpMethod.Get, url, null, authToken);
        }

        public async Task<T> PostAsync<T>(string url, object data, string authToken)
        {
            return await SendRequestAsync<T>(HttpMethod.Post, url, data, authToken);
        }

        public async Task<T> PutAsync<T>(string url, object data, string authToken)
        {
            return await SendRequestAsync<T>(HttpMethod.Put, url, data, authToken);
        }

        public async Task<T> DeleteAsync<T>(string url, string authToken)
        {
            return await SendRequestAsync<T>(HttpMethod.Delete, url, null, authToken);
        }
    }
}
