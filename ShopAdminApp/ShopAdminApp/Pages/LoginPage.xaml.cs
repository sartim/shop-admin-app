using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using ShopAdminApp.Services;

namespace ShopAdminApp
{
    public partial class LoginPage : ContentPage
    {
        private readonly AuthService _authService;

        public LoginPage()
        {
            InitializeComponent();

            CheckForJwtAsync();
            _authService = new AuthService();
        }

        async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            string email = EmailEntry.Text;
            string password = PasswordEntry.Text;

            bool isAuthenticated = await _authService.Authenticate(email, password);

            if (isAuthenticated)
            {
                // Navigate to the home page upon successful login
                await Navigation.PushAsync(new HomePage());
            }
            else
            {
                await DisplayAlert("Invalid credentials", "Please try again", "OK");
            }
        }

        async void CheckForJwtAsync()
        {
            try
            {
                var jwt = await SecureStorage.GetAsync("jwt");

                if (!string.IsNullOrEmpty(jwt))
                {
                    await Navigation.PushAsync(new HomePage());
                }
            }
            catch (Exception ex)
            {
                // Possible that device doesn't support secure storage on device.
                await DisplayAlert("Error", ex.Message, "OK");
                Console.WriteLine($"Error: {ex.Message}");
                // Navigate to the login page
                Application.Current.MainPage = new NavigationPage(new LoginPage());
            }
        }
    }
}


