﻿using System;
namespace OrderCore.DTOs
{
    public class CustomerDto
    {
        public CustomerDto()
        {
        }

        public int Id { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string ZipCode { get; set; }

        public string CustomerNumber { get; set; }

        public string CustomerName { get; set; }
    }
}
