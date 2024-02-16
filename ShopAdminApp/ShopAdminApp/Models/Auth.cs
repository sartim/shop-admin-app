using System;
namespace ShopAdminApp.Models
{
    public class AuthRequest
    {
        public string email { get; set; }
        public string password { get; set; }
    }

    public class AuthResponse
    {
        public string access_token { get; set; }
        public UserDetail user { get; set; }
    }
}

