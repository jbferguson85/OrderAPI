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
        private readonly IMapper _mapper;
        public OrderManager(IOrderDataAccessor orderDataAccessor, IMapper mapper) 
        {
            _orderAccessor = orderDataAccessor;
            _mapper = mapper;
        }

        public async Task<List<ProductDto>> GetProductsAsync()
        {
            var productEntities = await _orderAccessor.GetProductsAsync();
            return _mapper.Map<List<ProductDto>>(productEntities);
        }
    }
}
