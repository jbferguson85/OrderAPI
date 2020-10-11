using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OrderCore.DTOs
{
    public class OrderForUpdateDto
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "ID is required.")]
        public int Id { get; set; }

        public string OrderStatus { get; set; }

        public string OrderName { get; set; }
        
        public DateTime CompletedDate { get; set; }

        [Required]
        public int CustomerId { get; set; }

        [Required]
        public List<LineItemForUpdateDto> LineItems { get; set; }
    }
}