﻿using System;
using System.Collections.Generic;
 using System.Linq;
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

        public async Task<ProductDto> GetProductAsync(int productId)
        {
            return await _orderAccessor.GetProductAsync(productId);
        }

        public async Task<List<CustomerDto>> GetCustomersAsync(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return await _orderAccessor.GetCustomersAsync();
            }

            return await _orderAccessor.SearchCustomersAsync(searchTerm);
        }

        public async Task<CustomerDto> GetCustomerAsync(int customerId)
        {
            return await _orderAccessor.GetCustomerAsync(customerId);
        }

        public async Task<OrderDto> CreateOrderAsync(OrderDto order)
        {
            order.OrderStatus = "Processing";
            order.CreatedDate = DateTime.Now; // yeah, i know. 
            order.OrderNumber = new Random(1000).ToString();
            return await _orderAccessor.CreateOrderAsync(order);
        }

        public async Task<OrderDto> GetOrderAsync(int orderId)
        {
            return await _orderAccessor.GetOrderAsync(orderId);
        }

        public async Task<List<OrderDto>> GetOrdersAsync()
        {
            return await _orderAccessor.GetOrdersAsync();
        }

        public async Task<OrderDto> UpdateOrderAsync(OrderForUpdateDto order)
        {
            var orderInDb = await _orderAccessor.GetOrderAsync(order.Id);
            if (orderInDb == null)
            {
                return null;
            }

            var incomingProductIds = order.LineItems.Select(x => x.ProductId).ToList();
            var dbProductIds = orderInDb.LineItems.Select(x => x.ProductId).ToList();
            var lineItemsToDelete = orderInDb.LineItems
                .Where(x => !incomingProductIds
                    .Contains(x.ProductId))
                .ToList();
            if (lineItemsToDelete.Any())
            {
                await _orderAccessor.DeleteLineItems(lineItemsToDelete);
            }

            var lineItemsToAdd = order.LineItems
                .Where(x => !dbProductIds.Contains(x.ProductId)).ToList();

            if (lineItemsToAdd.Any())
            {
                await _orderAccessor.AddLineItems(_mapper.Map<List<LineItemDto>>(lineItemsToAdd));
            }
            
            return await _orderAccessor.UpdateOrderAsync(order);
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