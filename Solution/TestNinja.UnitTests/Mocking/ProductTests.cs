using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    public class ProductTests
    {
        private Product? _product;

        [SetUp]
        public void Setup()
        {
            _product = new Product { ListPrice = 100.0f };
        }

        [Test]
        public void GetPrice_GoldCustomer_Apply30PercentDiscount()
        {
            // arrange 
            var customer = new Customer { IsGold = true };

            // act
            var actual = _product?.GetPrice(customer);
            var expected = _product?.ListPrice * 0.7f;

            // assert
            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
