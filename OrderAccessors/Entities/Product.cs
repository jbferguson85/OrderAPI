using System;
using System.Collections.Generic;

namespace OrderData.Entities
{
    public class Product
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public string ItemCode { get; set; }

        public Price Price { get; set; }

        public string Name { get; set; }

        List<OrderProduct> OrderProducts { get; set; }
    }
}
