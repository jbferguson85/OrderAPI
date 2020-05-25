using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OrderCore.DTOs;

namespace OrderManagers.Interfaces
{
    public interface IOrderManager
    {
        Task<List<ProductDto>> GetProductsAsync();
    }
}
