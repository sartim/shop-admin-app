using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopAdminApp.Services;
using Xamarin.Forms;

namespace ShopAdminApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            // Simulate loading time
            Device.StartTimer(TimeSpan.FromSeconds(2), () =>
            {
                // Navigate to the login page after 2 seconds
                Application.Current.MainPage = new NavigationPage(new LoginPage());
                return false;
            });
        }
    }
}


