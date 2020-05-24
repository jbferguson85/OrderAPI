using System;
using OrderData.Contexts;

namespace OrderAPI.Controllers
{
    public class ProductsController
    {
        private OrderDbContext _context;
        public ProductsController(OrderDbContext context)
        {
            _context = context;
        }
    }
}
