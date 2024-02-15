﻿using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ShopAdminApp.Services
{
    public class BaseService
    {
        protected readonly HttpClient _client;

        public BaseService()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("https://flask-shop-api.vercel.app/");
        }

        protected async Task<T> SendRequestAsync<T>(HttpMethod method, string url, object data = null)
        {
            HttpRequestMessage request = new HttpRequestMessage(method, url);

            if (data != null)
            {
                string jsonData = JsonConvert.SerializeObject(data);
                request.Content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            }

            HttpResponseMessage response = await _client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(jsonResponse);
            }
            else
            {
                Console.WriteLine($"Request failed: {response.StatusCode}");
                return default;
            }
        }
    }
}
