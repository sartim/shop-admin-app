using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ShopAdminApp.Models
{
    public class Product
	{
        public string count { get; set; }

        public string next { get; set; }

        public string previous { get; set; }

        public List<ProductDetail> results { get; set; }
       
    }

    public class ProductDetail
    {
        public string name { get; set; }

        public string image_urls { get; set; }

        //public CategoryDetail category { get; set; }

        public string brand { get; set; }

        public string price { get; set; }
    }
}

