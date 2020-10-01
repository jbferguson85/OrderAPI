using System.Collections.Generic;
using Moq;
using OrderAccessors.Accessors.Interfaces;
using OrderCore.DTOs;
using OrderCore.Entities;

namespace OrderUnitTests.MockSetups
{
    public class MockOrderAccessor : Mock<IOrderDataAccessor>
    {
        public MockOrderAccessor MockOrderNotFound(OrderDto result)
        {
            result = null;
            Setup(x => x.GetOrderAsync(It.IsAny<int>())).ReturnsAsync(result);
            return this;
        }

        public MockOrderAccessor MockOrderInDb(OrderDto order)
        {
            Setup(x => x.GetOrderAsync(It.IsAny<int>())).ReturnsAsync(order);

            return this;
        }

        public MockOrderAccessor VerifyDeleteLineItems(Times timesCalled)
        {
            Verify(x => x.DeleteLineItems(It.IsAny<List<LineItemDto>>()), timesCalled);

            return this;
        }
    }
}