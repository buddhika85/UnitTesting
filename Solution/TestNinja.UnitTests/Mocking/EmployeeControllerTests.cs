using Moq;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    public class EmployeeControllerTests
    {

        [Test]
        public void DeleteEmployee_WhenIdPassed_InteractsWithStorage()
        {
            // arrange
            const int id = 1;
            var mockStorage = new Mock<IEmployeeStorage>();
            var mockEmployeeController = new EmployeeController(mockStorage.Object);

            // act
            mockEmployeeController.DeleteEmployee(id);

            // assert
            // we only need to check for interaction with storage object here
            // no need to check the actual deletion - because deletion is responsibility of storage not employee controller 
            mockStorage.Verify(x => x.DeleteEmployee(id));
        }
    }
}
