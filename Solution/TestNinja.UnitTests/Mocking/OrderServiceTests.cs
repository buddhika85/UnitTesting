using Moq;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    public class OrderServiceTests
    {

        [Test]
        public void PlaceOrder_PassOrder_StoreAndReturnOrderId()
        {
            // arrange
            var mockStorage = new Mock<IStorage>();
            var mockOrder = new Mock<Order>();
            mockStorage.Setup(x => x.Store(mockOrder.Object)).Returns(1);
            var orderService = new OrderService(mockStorage.Object);

            // act
            var actualId = orderService.PlaceOrder(mockOrder.Object);

            // assert
            Assert.That(actualId, Is.EqualTo(1));
        }
    }
}
