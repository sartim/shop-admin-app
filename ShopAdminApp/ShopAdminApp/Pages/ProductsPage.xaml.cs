
using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ShopAdminApp.Models;
using ShopAdminApp.Services;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ShopAdminApp
{
	public partial class ProductsPage : ContentPage
	{
        private readonly RestService _restService;

        public ProductsPage()
        {
			InitializeComponent();
            _restService = new RestService();
            GetProducts();
        }

        public async void GetProducts()
        {
            try
            { 
                if (NetworkCheck.IsInternet())
                {
                    // Offload the network request to a background thread
                    var products = await Task.Run(() => _restService.GetAsync<Product>("api/v1/products", null));

                    // Update the UI on the main thread
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        //Binding listview with server response    
                        listviewProducts.ItemsSource = products.results;
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
                await DisplayAlert("Error", $"Failed to load products: {ex.Message}", "OK");
                ProgressLoader.IsVisible = false;
            }
        }
    }
}

