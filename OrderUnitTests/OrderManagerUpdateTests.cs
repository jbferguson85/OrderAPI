using System;
using System.Collections.Generic;
using Moq;
using OrderCore.DTOs;
using OrderManagers.Implementations;
using OrderUnitTests.MockSetups;
using Xunit;

namespace OrderUnitTests
{
    public class OrderManagerUpdateTests
    {
        [Fact]
        public async void IfOrderIsNotFoundThenReturnNull()
        {
            // Arrange
            var manager = new OrderManager(new MockOrderAccessor().MockOrderNotFound(null).Object, new MockAutoMapper().Object);
            
            // Act
            var result = await manager.UpdateOrderAsync(new OrderForUpdateDto{Id = 5});

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async void NewLineItemsShouldBeAdded()
        {
            // Arrange
            var orderInDb = new OrderDto
            {
                Id = 1,
                Customer = new CustomerDto {Id = 1},
                LineItems = new List<LineItemDto>
                {
                    new LineItemDto {OrderId = 1, ProductId = 1}
                }
            };
            var orderToUpdate = new OrderForUpdateDto
            {
                Id = 1,
                CustomerId = 1,
                LineItems = new List<LineItemForUpdateDto>
                {
                    new LineItemForUpdateDto {OrderId = 1, ProductId = 1},
                    new LineItemForUpdateDto {OrderId = 1, ProductId = 3}
                }
            };
            var mockAccessor = new MockOrderAccessor().MockOrderInDb(orderInDb);
            var manager = new OrderManager(mockAccessor.Object, new MockAutoMapper().Object);
            
            // Act
            var result = await manager.UpdateOrderAsync(orderToUpdate);

            // Assert
            mockAccessor.VerifyAddLineItems(Times.Once());
        }

        [Fact]
        public async void LineItemsInDbNotPassedInWithUpdateDtoShouldBeDeleted()
        {
            // Arrange
            var orderInDb = new OrderDto
            {
                Id = 1,
                Customer = new CustomerDto {Id = 1},
                LineItems = new List<LineItemDto>
                {
                    new LineItemDto {OrderId = 1, ProductId = 1},
                    new LineItemDto {OrderId = 1, ProductId = 2}
                }
            };
            var orderToUpdate = new OrderForUpdateDto
            {
                Id = 1,
                CustomerId = 1,
                LineItems = new List<LineItemForUpdateDto>
                {
                    new LineItemForUpdateDto {OrderId = 1, ProductId = 1}
                }
            };
            var mockAccessor = new MockOrderAccessor().MockOrderInDb(orderInDb);
            var manager = new OrderManager(mockAccessor.Object, new MockAutoMapper().Object);
            
            // Act
            var result = await manager.UpdateOrderAsync(orderToUpdate);

            // Assert
            mockAccessor.VerifyDeleteLineItems(Times.Once());
        }

        [Fact]
        public async void LineItemsInDbAndUpdateDtoShouldBeUpdated()
        {
            // Arrange
            var orderInDb = new OrderDto
            {
                Id = 1,
                Customer = new CustomerDto {Id = 1},
                LineItems = new List<LineItemDto>
                {
                    new LineItemDto {OrderId = 1, ProductId = 1},
                }
            };
            var orderToUpdate = new OrderForUpdateDto
            {
                Id = 1,
                CustomerId = 1,
                LineItems = new List<LineItemForUpdateDto>
                {
                    new LineItemForUpdateDto {OrderId = 1, ProductId = 1}
                }
            };
            var mockAccessor = new MockOrderAccessor().MockOrderInDb(orderInDb);
            var manager = new OrderManager(mockAccessor.Object, new MockAutoMapper().Object);
            
            // Act
            var result = await manager.UpdateOrderAsync(orderToUpdate);

            // Assert
            mockAccessor.VerifyUpdateLineItems(Times.Once());
        }
    }
}