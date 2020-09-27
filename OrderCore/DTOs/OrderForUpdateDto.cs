using System;
using System.Collections.Generic;

namespace OrderCore.DTOs
{
    public class OrderForUpdateDto
    {
        public int Id { get; set; }

        public string OrderStatus { get; set; }

        public string OrderName { get; set; }
        
        public DateTime CompletedDate { get; set; }

        public int CustomerId { get; set; }

        public List<LineItemForUpdateDto> LineItems { get; set; }
    }
}