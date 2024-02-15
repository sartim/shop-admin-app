using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ShopAdminApp.Models
{
    public class Order
    {
        public string count { get; set; }

        public string next { get; set; }

        public string previous { get; set; }

        public List<OrderDetail> results { get; set; }

    }

    public class OrderDetail
    {
        public string id { get; set; }

        public string order_total { get; set; }

    }
}

