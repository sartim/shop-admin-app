using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ShopAdminApp.Models;
using ShopAdminApp.Services;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ShopAdminApp
{
    public partial class UsersPage : ContentPage
    {
        private readonly RestService _restService;

        public UsersPage()
        {
            InitializeComponent();
            _restService = new RestService();
            GetUsers();
        }

        public async void GetUsers()
        {
            try
            {
                if (NetworkCheck.IsInternet())
                {
                    string storedAuthResponse = await SecureStorage.GetAsync("jwt");
                    AuthResponse authResponse = JsonConvert.DeserializeObject<AuthResponse>(storedAuthResponse);
                    string token = authResponse.access_token;

                    // Offload the network request to a background thread
                    var users = await Task.Run(() => _restService.GetAsync<User>("api/v1/users", token));

                    // Update the UI on the main thread
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        //Binding listview with server response    
                        listviewUsers.ItemsSource = users.results;
                    });
                }
                else
                {
                    await DisplayAlert("JSONParsing", "No network is available.", "Ok");
                }
                ProgressLoader.IsVisible = false;
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Failed to load users: {ex.Message}", "OK");
                ProgressLoader.IsVisible = false;
            }
        }
    }
}

