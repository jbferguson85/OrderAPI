using System;
namespace OrderData.Entities
{
    public class Price
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public decimal ProductPrice { get; set; }
    }
}
