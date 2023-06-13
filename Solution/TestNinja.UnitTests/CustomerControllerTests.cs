using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class CustomerControllerTests
    {
        private CustomerController _customerController;

        [SetUp]
        public void Setup()
        {
            _customerController = new CustomerController();
        }

        [Test]
        public void GetCustomer_IdZero_ReturnNotFound()
        {
            // arrange
            var id = 0;

            // act
            var actionResult = _customerController.GetCustomer(id);

            // assert
            Assert.That(actionResult, Is.Not.Null);
            Assert.That(actionResult is NotFound);
        }

        [Test]
        public void GetCustomer_IdNonZero_ReturnOk()
        {
            // arrange
            var id = 1;

            // act
            var actionResult = _customerController.GetCustomer(id);

            // assert
            Assert.That(actionResult, Is.Not.Null);
            Assert.That(actionResult is Ok);
        }
    }
}
