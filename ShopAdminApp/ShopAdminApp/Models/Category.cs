using System.Collections.Generic;

namespace ShopAdminApp.Models
{
    public class Category
    {
        public string count { get; set; }

        public string next { get; set; }

        public string previous { get; set; }

        public List<CategoryDetail> results { get; set; }
    }

    public class CategoryDetail
    {
        public string name { get; set; }

        public string description { get; set; }

        public string deleted { get; set; }
    }
}