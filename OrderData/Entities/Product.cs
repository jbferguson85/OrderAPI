using System;
namespace OrderData.Entities
{
    public class Product
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public string ItemCode { get; set; }

        public Price Price { get; set; }
    }
}
