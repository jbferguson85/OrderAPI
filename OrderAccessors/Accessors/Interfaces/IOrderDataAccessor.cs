using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OrderData.Entities;

namespace OrderAccessors.Accessors.Interfaces
{
    public interface IOrderDataAccessor
    {
        Task<List<Product>> GetProductsAsync();
    }
}
