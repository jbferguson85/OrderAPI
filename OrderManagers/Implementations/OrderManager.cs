using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OrderCore.DTOs;
using OrderManagers.Interfaces;
using OrderAccessors.Accessors.Interfaces;
using AutoMapper;

namespace OrderManagers.Implementations
{
    public class OrderManager : IOrderManager
    {
        private readonly IOrderDataAccessor _orderAccessor;
        public OrderManager(IOrderDataAccessor orderDataAccessor) 
        {
            _orderAccessor = orderDataAccessor;
        }

        public async Task<ProductDto> GetProductAsync(int productId)
        {
            return await _orderAccessor.GetProductAsync(productId);
        }

        public async Task<List<ProductDto>> GetProductsAsync(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return await _orderAccessor.GetProductsAsync();
            }
            return await _orderAccessor.SearchProductsAsync(searchTerm.Trim());
        }
    }
}