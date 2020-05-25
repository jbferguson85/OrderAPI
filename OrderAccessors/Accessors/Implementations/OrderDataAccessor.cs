using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OrderAccessors.Accessors.Interfaces;
using OrderData.Contexts;
using OrderData.Entities;

namespace OrderAccessors.Accessors.Implementations
{
    public class OrderDataAccessor : IOrderDataAccessor
    {
        private OrderDbContext _context;
        public OrderDataAccessor(OrderDbContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            return await _context.Products.Include(p => p.Price).ToListAsync();
        }
    }
}
