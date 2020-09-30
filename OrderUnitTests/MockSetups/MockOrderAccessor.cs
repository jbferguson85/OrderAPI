using System.Collections.Generic;
using Moq;
using OrderAccessors.Accessors.Interfaces;
using OrderCore.Entities;

namespace OrderUnitTests.MockSetups
{
    public class MockOrderAccessor : Mock<IOrderDataAccessor>
    {
        public MockOrderAccessor MockGetExistingLineItems(List<LineItemEntity> results)
        {
            //Setup(x => x.Get)
            return this;
        }
    }
}