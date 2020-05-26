using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OrderAccessors.Accessors.Interfaces;
using OrderCore.DTOs;
using OrderData.Contexts;
using OrderData.Entities;

namespace OrderAccessors.Accessors.Implementations
{
    public class OrderDataAccessor : IOrderDataAccessor
    {
        private OrderDbContext _context;
        private readonly IMapper _mapper;
        public OrderDataAccessor(OrderDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ProductDto>> GetProductsAsync()
        {
            var entities = await _context.Products.Include(p => p.Price).ToListAsync();
            return _mapper.Map<List<ProductDto>>(entities);
        }

        public async Task<List<ProductDto>> SearchProductsAsync(string searchTerm)
        {
            var entities = await _context.Products.Include(p => p.Price).Where(p => p.Description.ToUpper().Contains(searchTerm.ToUpper())
            || p.Name.ToUpper().Contains(searchTerm.ToUpper())
            || p.ItemCode.ToUpper().Contains(searchTerm.ToUpper())).ToListAsync();
            return _mapper.Map<List<ProductDto>>(entities);
        }

        public async Task<ProductDto> GetProductAsync(int productId)
        {
            var entity = await _context.Products.Include(p => p.Price).FirstOrDefaultAsync(p => p.Id == productId);
            return _mapper.Map<ProductDto>(entity);
        }
    }
}
