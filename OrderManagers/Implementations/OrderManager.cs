﻿using System;
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