using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderCore.Entities
{
    public class OrderEntity
    {
        public int Id { get; set; }

        public string OrderNumber { get; set; }

        public string OrderStatus { get; set; }

        public string OrderName { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? CompletedDate { get; set; }
        public int CustomerId { get; set; }

        [ForeignKey("CustomerId")]
        [Required]
        public CustomerEntity Customer { get; set; }

        public List<LineItemEntity> LineItems { get; set; }
    }
}