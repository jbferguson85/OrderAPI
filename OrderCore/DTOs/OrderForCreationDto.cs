using System;
using System.Collections.Generic;

namespace OrderCore.DTOs
{
    public class OrderForCreationDto
    {
        public string OrderNumber { get; set; }

        public string OrderName { get; set; }

        public int CustomerId { get; set; }

        public List<LineItemForCreationDto> LineItems { get; set; } = new List<LineItemForCreationDto>();
    }
}