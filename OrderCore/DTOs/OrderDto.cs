using System;
using System.Collections.Generic;

namespace OrderCore.DTOs
{
    public class OrderDto
    {
        public OrderDto()
        {
        }

        public int? Id { get; set; }

        public string OrderNumber { get; set; }

        public string OrderStatus { get; set; }

        public string OrderName { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime CompletedDate { get; set; }

        public CustomerDto Customer { get; set; }

        public List<LineItemDto> LineItems { get; set; }
    }
}
