using System;
using System.Collections.Generic;

namespace OrderCore.Entities
{
    public class OrderEntity
    {
        public Guid? Id { get; set; }

        public string OrderNumber { get; set; }

        public string OrderStatus { get; set; }

        public string OrderName { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime CompletedDate { get; set; }

        public CustomerEntity Customer { get; set; }

        public List<LineItemEntity> LineItems { get; set; }
    }
}