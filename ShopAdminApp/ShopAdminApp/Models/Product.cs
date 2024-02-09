using System;
using System.Collections.Generic;

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

        public string count { get; set; }

        public string brand { get; set; }

        public string price { get; set; }
    }
}

