using System;
using System.Threading.Tasks;
using ShopAdminApp.Models;
using ShopAdminApp.Services;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ShopAdminApp
{
    public partial class OrdersPage : ContentPage
    {
        private readonly RestService _restService;

        public OrdersPage()
        {
            InitializeComponent();
            GetOrders();
        }

        public async void GetOrders()
        {
            try
            {
                if (NetworkCheck.IsInternet())
                {
                    string authToken = await SecureStorage.GetAsync("jwt");

                    // Offload the network request to a background thread
                    var orders = await Task.Run(() => _restService.GetAsync<Order>("api/v1/orders", authToken));

                    // Update the UI on the main thread
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        //Binding listview with server response    
                        listviewOrders.ItemsSource = orders.results;
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
                await DisplayAlert("Error", $"Failed to load orders: {ex.Message}", "OK");
                ProgressLoader.IsVisible = false;
            }
        }
    }
}

