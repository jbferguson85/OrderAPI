using System;
using System.Collections.Generic;
using OrderAccessors.Entities;

namespace OrderData.Entities
{
    public class Order
    {
        public int Id { get; set; }

        public string OrderNumber { get; set; }

        public string OrderStatus { get; set; }

        public string OrderName { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime CompletedDate { get; set; }

        public Customer Customer { get; set; }

        public List<LineItem> LineItems { get; set; }
    }
}
