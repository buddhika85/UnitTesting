using Moq;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    public class EmployeeControllerTests
    {
        private readonly int _empId = 1;
        private EmployeeController _mockEmployeeController = null!;
        private Mock<IEmployeeStorage> _mockStorage = null!;

        [SetUp]
        public void Setup()
        {
            _mockStorage = new Mock<IEmployeeStorage>();
            _mockEmployeeController = new EmployeeController(_mockStorage.Object);

        }

        [Test]
        public void DeleteEmployee_WhenIdPassed_InteractsWithStorage()
        {
            // arrange
            // was done in setup

            // act
            _mockEmployeeController.DeleteEmployee(_empId);

            // assert
            // we only need to check for interaction with storage object here
            // no need to check the actual deletion - because deletion is responsibility of storage not employee controller 
            _mockStorage.Verify(x => x.DeleteEmployee(_empId));
        }

        [Test]
        public void DeleteEmployee_WhenIdPassed_ReturnsActionResult()
        {
            // arrange
            // was done in setup

            // act
            var actual = _mockEmployeeController.DeleteEmployee(_empId);

            // assert
            Assert.That(actual, Is.Not.Null);
            Assert.That(actual, Is.InstanceOf<ActionResult>());
            Assert.That(actual, Is.InstanceOf<RedirectResult>());
        }
    }
}
