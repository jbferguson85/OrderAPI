using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OrderAccessors.Accessors.Interfaces;
using OrderCore.DTOs;
using OrderAccessors.Contexts;

namespace OrderAccessors.Accessors.Implementations
{
    public class OrderDataAccessor : IOrderDataAccessor
    {
        private readonly OrderDbContext _context;
        private readonly IMapper _mapper;
        public OrderDataAccessor(OrderDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ProductDto>> GetProductsAsync()
        {
            var entities = await _context.Products.ToListAsync();
            return _mapper.Map<List<ProductDto>>(entities);
        }

        public async Task<List<ProductDto>> SearchProductsAsync(string searchTerm)
        {
            var entities = await _context.Products.Where(p => p.Description.ToUpper().Contains(searchTerm.ToUpper())
            || p.Name.ToUpper().Contains(searchTerm.ToUpper())
            || p.ItemCode.ToUpper().Contains(searchTerm.ToUpper())).ToListAsync();
            return _mapper.Map<List<ProductDto>>(entities);
        }

        public async Task<ProductDto> GetProductAsync(int productId)
        {
            var entity = await _context.Products.FirstOrDefaultAsync(p => p.Id == productId);
            return _mapper.Map<ProductDto>(entity);
        }

        public async Task<CustomerDto> GetCustomerAsync(int customerId)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(cust => cust.Id == customerId);
            return _mapper.Map<CustomerDto>(customer);
        }

        public async Task<List<CustomerDto>> GetCustomersAsync()
        {
            var customers = await _context.Customers.ToListAsync();
            return _mapper.Map<List<CustomerDto>>(customers);
        }

        public async Task<List<CustomerDto>> SearchCustomersAsync(string searchTerm)
        {
            var entities = await _context.Customers.Where(c => c.CustomerName.ToUpper().Contains(searchTerm.ToUpper())
            || c.CustomerNumber.ToUpper().Contains(searchTerm.ToUpper())
            || c.City.ToUpper().Contains(searchTerm.ToUpper())).ToListAsync();
            return _mapper.Map<List<CustomerDto>>(entities);
        }
    }
}
