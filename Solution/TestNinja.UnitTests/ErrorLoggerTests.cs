using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class ErrorLoggerTests
    {
        private ErrorLogger _errorLogger;

        [SetUp]
        public void Setup()
        {
            // arrange part for all tests in this class
            _errorLogger = new ErrorLogger();
        }

        [Test]
        [TestCase("testError", "testError")]
        [TestCase("123", "123")]
        public void Log_WhenCalledWithNonNullNonEmpty_ChangeLastError(string error, string expected)
        {
            // act
            _errorLogger.Log(error);

            // assert
            Assert.That(_errorLogger.LastError, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase("  ")]
        public void Log_WhenCalledWithNullOrEmpty_ChangeLastError(string error)
        {
            Assert.That(() => _errorLogger.Log(error), Throws.ArgumentNullException);
        }

    }
}
