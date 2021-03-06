﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OrderAccessors.Accessors.Interfaces;
using OrderCore.DTOs;
using OrderAccessors.Contexts;
using OrderCore.Entities;

namespace OrderAccessors.Accessors.Implementations
{
    public class OrderDataAccessor : IOrderDataAccessor
    {
        private readonly OrderDbContext _context;
        private readonly IMapper _mapper;
        public OrderDataAccessor(OrderDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ProductDto>> GetProductsAsync()
        {
            var entities = await _context.Products.ToListAsync();
            return _mapper.Map<List<ProductDto>>(entities);
        }

        public async Task<List<ProductDto>> SearchProductsAsync(string searchTerm)
        {
            var entities = await _context.Products.Where(p => p.Description.ToUpper().Contains(searchTerm.ToUpper())
            || p.Name.ToUpper().Contains(searchTerm.ToUpper())
            || p.ItemCode.ToUpper().Contains(searchTerm.ToUpper())).ToListAsync();
            return _mapper.Map<List<ProductDto>>(entities);
        }

        public async Task<ProductDto> GetProductAsync(int productId)
        {
            var entity = await _context.Products.FirstOrDefaultAsync(p => p.Id == productId);
            return _mapper.Map<ProductDto>(entity);
        }

        public async Task<CustomerDto> GetCustomerAsync(int customerId)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(cust => cust.Id == customerId);
            return _mapper.Map<CustomerDto>(customer);
        }

        public async Task<List<CustomerDto>> GetCustomersAsync()
        {
            var customers = await _context.Customers.ToListAsync();
            return _mapper.Map<List<CustomerDto>>(customers);
        }

        public async Task<List<CustomerDto>> SearchCustomersAsync(string searchTerm)
        {
            var entities = await _context.Customers.Where(c => c.CustomerName.ToUpper().Contains(searchTerm.ToUpper())
            || c.CustomerNumber.ToUpper().Contains(searchTerm.ToUpper())
            || c.City.ToUpper().Contains(searchTerm.ToUpper())).ToListAsync();
            return _mapper.Map<List<CustomerDto>>(entities);
        }

        public async Task<OrderDto> CreateOrderAsync(OrderDto order)
        {
            if (_context.Orders.Any())
            {
                order.Id = _context.Orders.Max(i => i.Id) + 1;
            }
            else
            {
                order.Id = 1;
            }
            order.LineItems.ForEach(item => item.OrderId = order.Id);
            var entity = _mapper.Map<OrderEntity>(order);
            _context.Entry(entity.Customer).State = EntityState.Unchanged;
            await _context.Orders.AddAsync(entity);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task<OrderDto> GetOrderAsync(int orderId)
        {
            var order = await _context.Orders
                .Include(li => li.LineItems)
                .Include(cust => cust.Customer)
                .FirstOrDefaultAsync(x => x.Id == orderId);
            return _mapper.Map<OrderDto>(order);
        }

        public async Task<List<OrderDto>> GetOrdersAsync()
        {
            var orders = await _context.Orders
                .Include(li => li.LineItems)
                .Include(cust => cust.Customer)
                .ToListAsync();
            return _mapper.Map<List<OrderDto>>(orders);
        }

        public void UpdateOrderAsync(OrderForUpdateDto order)
        {
            var orderEntity = _mapper.Map<OrderEntity>(order);
            _context.Entry(orderEntity).State = EntityState.Modified;
            _context.Entry(orderEntity).Property(x => x.CreatedDate).IsModified = false;
            _context.Entry(orderEntity).Property(x => x.OrderNumber).IsModified = false;
        }

        public async Task DeleteOrderAsync(int orderId)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(x => x.Id == orderId);
            if (order != null)
            {
                _context.Orders.Remove(order);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> OrderExistsAsync(int orderId)
        {
            return await _context.Orders.AnyAsync(x => x.Id == orderId);
        }

        public async Task<List<LineItemDto>> GetLineItemsForOrderAsync(int orderId)
        {
            var lineItems = await _context.LineItems.Where(x => x.OrderId == orderId).ToListAsync();
            return _mapper.Map<List<LineItemEntity>, List<LineItemDto>>(lineItems);
        }

        public void DeleteLineItems(List<LineItemDto> lineItems)
        {
            var entities = _mapper.Map<List<LineItemEntity>>(lineItems);
            foreach (var lineItem in entities)
            {
                _context.Entry(lineItem).State = EntityState.Deleted;
            }
        }

        public async Task AddLineItems(List<LineItemDto> lineItems)
        {
            await _context.LineItems.AddRangeAsync(_mapper.Map<List<LineItemEntity>>(lineItems));
        }

        public void UpdateLineItems(List<LineItemForUpdateDto> lineItems)
        {
            var entities = _mapper.Map<List<LineItemEntity>>(lineItems);
            foreach (var lineItem in entities)
            {
                _context.Entry(lineItem).State = EntityState.Modified;
            }
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }

        private async Task<List<LineItemEntity>> GetExistingLineItems(int orderId)
        {
            return await _context.LineItems.Where(x => x.OrderId == orderId).ToListAsync();
        }
        
        private IQueryable<LineItemEntity> GetLineItemsQueryable(int orderId)
        {
            return _context.LineItems.Where(x => x.OrderId == orderId).AsQueryable();
        }
    }
}
