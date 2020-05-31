using System;
using System.Collections.Generic;

namespace OrderAccessors.Entities
{
    public class Product
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public string ItemCode { get; set; }

        public decimal Price { get; set; }

        public string Name { get; set; }
    }
}
