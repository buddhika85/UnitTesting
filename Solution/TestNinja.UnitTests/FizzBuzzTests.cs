using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class FizzBuzzTests
    {
        private string _inputDivisbleBy3Str;
        private string _inputDivisbleBy5Str;
        private string _inputDivisbleBy3And5Str;

        [SetUp]
        public void Setup()
        {
            _inputDivisbleBy3Str = "Fizz";
            _inputDivisbleBy5Str = "Buzz";
            _inputDivisbleBy3And5Str = "FizzBuzz";
        }

        [TestCase(3)]
        [TestCase(6)]
        [Test]
        public void GetOutput_InputDivisbleBy3_ReturnFizz(int input)
        {
            // act
            var actual = FizzBuzz.GetOutput(input);
            // assert
            Assert.That(actual, Is.Not.Null);
            Assert.That(actual, Is.Not.Empty);
            Assert.That(actual, Is.EqualTo(_inputDivisbleBy3Str));
        }

        [TestCase(5)]
        [TestCase(10)]
        [Test]
        public void GetOutput_InputDivisbleBy5_ReturnBuzz(int input)
        {
            // act
            var actual = FizzBuzz.GetOutput(input);
            // assert
            Assert.That(actual, Is.Not.Null);
            Assert.That(actual, Is.Not.Empty);
            Assert.That(actual, Is.EqualTo(_inputDivisbleBy5Str));
        }

        [TestCase(0)]
        [TestCase(15)]
        [TestCase(30)]
        [Test]
        public void GetOutput_InputDivisbleBy3And5_ReturnFizzBuzz(int input)
        {
            // act
            var actual = FizzBuzz.GetOutput(input);
            // assert
            Assert.That(actual, Is.Not.Null);
            Assert.That(actual, Is.Not.Empty);
            Assert.That(actual, Is.EqualTo(_inputDivisbleBy3And5Str));
        }


        [TestCase(1)]
        [TestCase(2)]
        [TestCase(19)]
        [Test]
        public void GetOutput_InputNotDvisibleBy3or5_ReturnNumber(int input)
        {
            // act
            var actual = FizzBuzz.GetOutput(input);
            // assert
            Assert.That(actual, Is.Not.Null);
            Assert.That(actual, Is.Not.Empty);
            Assert.That(actual, Is.EqualTo(input.ToString()));
        }
    }
}
