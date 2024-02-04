using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ShopAdminApp.Services;

namespace ShopAdminApp
{
    public partial class LoginPage : ContentPage
    {
        private string LoginMessage;
        private RestService restService; // Create an instance variable

        public LoginPage()
        {
            InitializeComponent();
            restService = new RestService(); // Initialize the RestService instance
        }

        async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            string email = EmailEntry.Text;
            string password = PasswordEntry.Text;

            bool isAuthenticated = await restService.Authenticate(email, password);

            if (isAuthenticated)
            {
                // Navigate to the home page upon successful login
                await Navigation.PushAsync(new HomePage());
            }
            else
            {
                LoginMessage = "Invalid credentials. Please try again.";
                Console.WriteLine(LoginMessage);
            }
        }
    }
}


