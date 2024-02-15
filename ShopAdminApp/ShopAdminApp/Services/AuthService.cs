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

            HttpResponseMessage response = await _client.PostAsync("api/v1/auth/generate-jwt", content);
            if (response.IsSuccessStatusCode)
            {
                try
                {
                    await SecureStorage.SetAsync("jwt", response.ToString());
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
