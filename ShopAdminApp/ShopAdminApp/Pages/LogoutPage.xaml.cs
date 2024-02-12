using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using ShopAdminApp.Services;

namespace ShopAdminApp
{
    public partial class LogoutPage : ContentPage
    {
        public LogoutPage()
        {
            InitializeComponent();
            Logout();
        }

        async void Logout()
        {
            SecureStorage.Remove("jwt");
            await Navigation.PushAsync(new LoginPage());
        }
    }
}

