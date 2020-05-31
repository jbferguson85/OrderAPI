﻿using System;
using System.Collections.Generic;

namespace OrderData.Entities
{
    public class Order
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string ZipCode { get; set; }

        public DateTime CreatedDate { get; set; }

        List<OrderProduct> OrderProducts { get; set; }
    }
}
