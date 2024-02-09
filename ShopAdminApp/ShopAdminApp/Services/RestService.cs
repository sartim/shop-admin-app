using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Newtonsoft.Json;
using ShopAdminApp.Models;

namespace ShopAdminApp.Services
{
	public class RestService
	{
        HttpClient client;

        public RestService()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://flask-shop-api.vercel.app/");
        }

        public async Task<bool> Authenticate(string email, string password)
        {
            var json = $"{{\"email\": \"{email}\", \"password\": \"{password}\"}}";
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            HttpResponseMessage response = await client.PostAsync("api/v1/auth/generate-jwt", content);
            try
            {
                await SecureStorage.SetAsync("jwt", response.ToString());
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                Console.WriteLine("Possible that device doesn't support secure storage on device.");
            }
            Console.WriteLine(response);
            return response.IsSuccessStatusCode;
        }

        public async Task<Product> ListProducts()
        {
            HttpResponseMessage response = await client.GetAsync("api/v1/products");
            var jsonResponse = await response.Content.ReadAsStringAsync();
            Product product = JsonConvert.DeserializeObject<Product>(jsonResponse);
            Console.WriteLine($"{jsonResponse}\n");

            return product;
        }
    }
}

