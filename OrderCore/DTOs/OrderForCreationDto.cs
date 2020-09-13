using System;
using System.Collections.Generic;

namespace OrderCore.DTOs
{
    public class OrderForCreationDto
    {
        public int Id { get; set; }
        
        public string OrderNumber { get; set; }

        public string OrderStatus { get; set; }

        public string OrderName { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime CompletedDate { get; set; }

        public List<LineItemForCreationDto> LineItems { get; set; }
    }
}