using System;
using System.Collections.Generic;

namespace ShopAdminApp.Models
{
    public class User
    {
        public string count { get; set; }

        public string next { get; set; }

        public string previous { get; set; }

        public List<UserDetail> results { get; set; }

    }

    public class UserDetail
    {
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
    }
}

