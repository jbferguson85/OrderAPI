using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OrderCore.DTOs;
using OrderManagers.Interfaces;

namespace OrderAPI.Controllers
{
    [ApiController]
    [Route("api/Orders")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderManager _orderManager;
        private readonly IMapper _mapper;

        public OrdersController(IOrderManager orderManager, IMapper mapper)
        {
            _orderManager = orderManager;
            _mapper = mapper;
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrder(int id)
        {
            var order = await _orderManager.GetOrderAsync(id);

            if (order == null)
            {
                return NotFound();
            }
            
            return Ok(order);
        }
        
        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            var orders = await _orderManager.GetOrdersAsync();

            if (orders.Count == 0)
            {
                return NotFound();
            }

            return Ok(orders);
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody]OrderForCreationDto order)
        {
            var orderDto = _mapper.Map<OrderForCreationDto, OrderDto>(order);
            var newOrder = await _orderManager.CreateOrderAsync(orderDto);
            return Ok(newOrder);
            // return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrder([FromBody] OrderForUpdateDto order)
        {
            var newOrder = await _orderManager.UpdateOrderAsync(order);
            return Ok(newOrder);
        }
    }
}