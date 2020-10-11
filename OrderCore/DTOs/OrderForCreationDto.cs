using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OrderCore.DTOs
{
    public class OrderForCreationDto
    {
        public string OrderNumber { get; set; }

        public string OrderName { get; set; }

        [Required]
        public int CustomerId { get; set; }

        [Required]
        public List<LineItemForCreationDto> LineItems { get; set; } = new List<LineItemForCreationDto>();
    }
}