using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace ShopAdminApp.Services
{
    public class AuthService : BaseService
    {
        public async Task<bool> Authenticate(string email, string password)
        {
            var json = $"{{\"email\": \"{email}\", \"password\": \"{password}\"}}";
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            HttpResponseMessage response = await _client.PostAsync("api/v1/auth/generate-jwt", content);

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    await SecureStorage.SetAsync("jwt", jsonResponse);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    Console.WriteLine("Possible that device doesn't support secure storage on device.");
                }
            }

            return response.IsSuccessStatusCode;
        }
    }
}
