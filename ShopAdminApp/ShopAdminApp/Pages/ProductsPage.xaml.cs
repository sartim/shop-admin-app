
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
        private readonly ProductService _productService;

        public ProductsPage()
        {
			InitializeComponent();
            _productService = new ProductService();
            GetProducts();
        }

        public async void GetProducts()
        {
            //Check network status   
            if (NetworkCheck.IsInternet())
            {
                var products = await _productService.GetAsync<Product>("api/v1/products");

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

