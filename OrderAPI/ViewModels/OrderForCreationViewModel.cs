using System;
using System.Collections.Generic;

namespace OrderAPI.ViewModels
{
    public class OrderForCreationViewModel
    {
        public Guid? Id { get; set; }

        public string OrderNumber { get; set; }

        public string OrderStatus { get; set; }

        public string OrderName { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime CompletedDate { get; set; }

        public List<LineItemForCreationViewModel> LineItems { get; set; }
    }
}