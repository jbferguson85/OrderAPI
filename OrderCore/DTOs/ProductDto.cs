﻿using System;
namespace OrderCore.DTOs
{
    public class ProductDto
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public string ItemCode { get; set; }

        public decimal Price { get; set; }

        public string Name { get; set; }
    }
}
