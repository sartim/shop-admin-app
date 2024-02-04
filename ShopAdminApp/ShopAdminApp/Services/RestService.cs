using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

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
            Console.WriteLine(response);
            return response.IsSuccessStatusCode;
        }
    }
}

