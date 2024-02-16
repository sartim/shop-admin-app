using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ShopAdminApp.Models;
using ShopAdminApp.Services;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ShopAdminApp
{
    public partial class CategoryPage : ContentPage
    {
        private readonly RestService _restService;

        public CategoryPage()
        {
            InitializeComponent();
            _restService = new RestService();
            GetCategories();
        }

        public async void GetCategories()
        {
            try
            {
                if (NetworkCheck.IsInternet())
                {
                    string storedAuthResponse = await SecureStorage.GetAsync("jwt");
                    AuthResponse authResponse = JsonConvert.DeserializeObject<AuthResponse>(storedAuthResponse);
                    string token = authResponse.access_token;

                    // Offload the network request to a background thread
                    var categories = await Task.Run(() => _restService.GetAsync<Category>("api/v1/categories", token));

                    // Update the UI on the main thread
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        //Binding listview with server response    
                        listviewCategories.ItemsSource = categories.results;
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
                await DisplayAlert("Error", $"Failed to load categories: {ex.Message}", "OK");
                ProgressLoader.IsVisible = false;
            }
        }
    }
}

