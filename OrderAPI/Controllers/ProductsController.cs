﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OrderCore.DTOs;
using OrderManagers.Interfaces;

namespace OrderAPI.Controllers
{
    [ApiController]
    [Route("api/Products")]
    public class ProductsController : ControllerBase
    {
        private readonly IOrderManager _orderManager;

        public ProductsController(IOrderManager orderManager)
        {
            _orderManager = orderManager;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await _orderManager.GetProductAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts(string searchTerm)
        {
            var products = await _orderManager.GetProductsAsync(searchTerm);

            if (products.Count == 0)
            {
                return NotFound();
            }

            return Ok(products);
        }
    }
}
