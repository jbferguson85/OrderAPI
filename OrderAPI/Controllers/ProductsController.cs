using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OrderCore.DTOs;
using OrderManagers.Interfaces;

namespace OrderAPI.Controllers
{
    [Route("api/Products")]
    public class ProductsController : ControllerBase
    {
        private readonly IOrderManager _orderManager;

        public ProductsController(IOrderManager orderManager)
        {
            _orderManager = orderManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _orderManager.GetProductsAsync();
            return Ok(products);
        }
    }
}
