
using System;
using Newtonsoft.Json;
using ShopAdminApp.Models;
using ShopAdminApp.Services;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ShopAdminApp
{
	public partial class ProductsPage : ContentPage
	{
        private RestService restService;

        public ProductsPage()
        {
			InitializeComponent();
            restService = new RestService();
            GetProducts();
        }

        public async void GetProducts()
        {
            //Check network status   
            if (NetworkCheck.IsInternet())
            {
                var products = await restService.ListProducts();

                //Binding listview with server response    
                listviewProducts.ItemsSource = products.results;
            }
            else
            {
                await DisplayAlert("JSONParsing", "No network is available.", "Ok");
            }
            //Hide loader after server response    
            ProgressLoader.IsVisible = false;
        }
    }
}

