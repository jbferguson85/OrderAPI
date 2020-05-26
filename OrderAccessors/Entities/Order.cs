using System;
using System.Collections.Generic;

namespace OrderData.Entities
{
    public class Order
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime CreatedDate { get; set; }

        List<OrderProduct> OrderProducts { get; set; }
    }
}
