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
    }
}
