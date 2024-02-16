using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ShopAdminApp.Models;
using ShopAdminApp.Services;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ShopAdminApp
{
    public partial class StatusPage : ContentPage
    {
        private readonly RestService _restService;

        public StatusPage()
        {
            InitializeComponent();
            _restService = new RestService();
            GetStatus();
        }

        public async void GetStatus()
        {
            try
            {
                if (NetworkCheck.IsInternet())
                {
                    string storedAuthResponse = await SecureStorage.GetAsync("jwt");
                    AuthResponse authResponse = JsonConvert.DeserializeObject<AuthResponse>(storedAuthResponse);
                    string token = authResponse.access_token;

                    // Offload the network request to a background thread
                    var statuses = await Task.Run(() => _restService.GetAsync<Status>("api/v1/statuses", token));

                    // Update the UI on the main thread
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        //Binding listview with server response    
                        listviewStatuses.ItemsSource = statuses.results;
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
                await DisplayAlert("Error", $"Failed to load statuses: {ex.Message}", "OK");
                ProgressLoader.IsVisible = false;
            }
        }
    }
}

