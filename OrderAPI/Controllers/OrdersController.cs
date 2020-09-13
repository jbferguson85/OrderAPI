using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OrderAPI.ViewModels;
using OrderManagers.Interfaces;

namespace OrderAPI.Controllers
{
    [ApiController]
    [Route("api/Orders")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderManager _orderManager;

        public OrdersController(IOrderManager orderManager)
        {
            _orderManager = orderManager;
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrder(Guid id)
        {
            var order = await _orderManager.GetOrderAsync(id);

            if (order == null)
            {
                return NotFound();
            }
            
            return Ok(order);
        }

        public async Task<IActionResult> GetOrders()
        {
            var orders = await _orderManager.GetOrdersAsync();

            if (orders.Count == 0)
            {
                return NotFound();
            }

            return Ok(orders);
        }

        public async Task<IActionResult> CreateOrder(OrderForCreationViewModel order)
        {
            
        }
    }
}