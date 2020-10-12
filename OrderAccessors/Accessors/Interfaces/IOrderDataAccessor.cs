using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OrderCore.DTOs;

namespace OrderAccessors.Accessors.Interfaces
{
    public interface IOrderDataAccessor
    {
        Task<List<ProductDto>> GetProductsAsync();

        Task<List<ProductDto>> SearchProductsAsync(string searchTerm);

        Task<ProductDto> GetProductAsync(int productId);

        Task<CustomerDto> GetCustomerAsync(int customerId);

        Task<List<CustomerDto>> GetCustomersAsync();

        Task<List<CustomerDto>> SearchCustomersAsync(string searchTerm);

        Task<OrderDto> CreateOrderAsync(OrderDto order);
        
        Task<OrderDto> GetOrderAsync(int orderId);
        Task<List<OrderDto>> GetOrdersAsync();
        void UpdateOrderAsync(OrderForUpdateDto order);
        Task DeleteOrderAsync(int orderId);
        Task<bool> OrderExistsAsync(int orderId);

        Task<List<LineItemDto>> GetLineItemsForOrderAsync(int orderId);

        void DeleteLineItems(List<LineItemDto> lineItems);

        Task AddLineItems(List<LineItemDto> lineItems);

        void UpdateLineItems(List<LineItemForUpdateDto> lineItems);

        Task Commit();
    }
}
