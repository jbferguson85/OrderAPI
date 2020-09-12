using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OrderCore.DTOs;

namespace OrderManagers.Interfaces
{
    public interface IOrderManager
    {
        Task<List<ProductDto>> GetProductsAsync(string searchTerm);
        Task<ProductDto> GetProductAsync(int productId);
        Task<List<CustomerDto>> GetCustomersAsync(string searchTerm);
        Task<CustomerDto> GetCustomerAsync(int customerId);
        Task<OrderDto> CreateOrderAsync(OrderDto order);

        Task<OrderDto> GetOrderAsync(Guid orderId);
        Task<List<OrderDto>> GetOrdersAsync();
    }
}
