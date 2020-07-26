using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OrderManagers.Interfaces;

namespace OrderAPI.Controllers
{
    [Route("api/Customers")]
    public class CustomersController : Controller
    {
        private readonly IOrderManager _orderManager;
        public CustomersController(IOrderManager orderManager)
        {
            _orderManager = orderManager;
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomer(int id)
        {
            var customer = await _orderManager.GetCustomerAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts(string searchTerm)
        {
            var customers = await _orderManager.GetCustomersAsync(searchTerm);

            if (!customers.Any())
            {
                return NotFound();
            }

            return Ok(customers);
        }
    }
}