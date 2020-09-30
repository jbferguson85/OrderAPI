using System;
using OrderAccessors.Accessors.Implementations;
using OrderAccessors.Accessors.Interfaces;
using OrderCore.DTOs;
using OrderManagers.Implementations;
using OrderManagers.Interfaces;
using OrderUnitTests.MockSetups;
using Xunit;

namespace OrderUnitTests
{
    public class OrderAccessorUpdateTests
    {
        [Fact]
        public async void IfOrderIsNotFoundThenReturnNull()
        {
            // Arrange
            var manager = new OrderManager(new MockOrderAccessor().MockOrderNotFound(null).Object);
            
            // Act
            var result = await manager.UpdateOrderAsync(new OrderForUpdateDto{Id = 5});

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void IfNoCustomerIsSentWithOrderUpdateThenReturnNull()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public void NewLineItemsShouldBeAdded()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public void LineItemsInDbNotPassedInWithUpdateDtoShouldBeDeleted()
        {
            throw new NotImplementedException(); 
        }

        [Fact]
        public void LineItemsInDbAndUpdateDtoShouldBeUpdated()
        {
            throw new NotImplementedException();
        }
    }
}