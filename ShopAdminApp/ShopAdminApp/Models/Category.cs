using System.Collections.Generic;

namespace ShopAdminApp.Models
{
    public class Category
    {
        public string count { get; set; }
        public string next { get; set; }
        public string previous { get; set; }
        public List<CategoryDetail> results { get; set; }

        public string message { get; set; }
    }

    public class CategoryDetail
    {
        public string id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string deleted { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
    }
}