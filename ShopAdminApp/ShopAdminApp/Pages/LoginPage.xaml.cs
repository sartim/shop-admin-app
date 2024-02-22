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
            ProgressLoader.IsVisible = false;
            EmailEntryLabel.IsVisible = false;
            PasswordEntryLabel.IsVisible = false;

            CheckForJwtAsync();
            _authService = new AuthService();

        }

        async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            ProgressLoader.IsVisible = true;
            EmailEntryLabel.IsVisible = false;
            PasswordEntryLabel.IsVisible = false;

            string email = EmailEntry.Text;
            string password = PasswordEntry.Text;

            if (email == null)
            {
                EmailEntryLabel.IsVisible = true;
            }

            if (password == null)
            {
                PasswordEntryLabel.IsVisible = true;
            }

            if (email != null && password != null)
            {
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
            

            ProgressLoader.IsVisible = false;
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
                await Navigation.PushAsync(new LoginPage());
            }
        }
    }
}


