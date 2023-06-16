using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class DemeritPointsCalculatorTests
    {
        private DemeritPointsCalculator _demeritPointsCalculator;

        [SetUp]
        public void SetUp()
        {
            _demeritPointsCalculator = new DemeritPointsCalculator();
        }

        [Test]
        [TestCase(-1)]
        [TestCase(301)]
        public void CalculateDemeritPoints_SpeedNegetiveOrGreaterToMaxSpeed_ThrowsArgumentOutOfRangeException(int speed)
        {
            // arrange
            // was done in setup

            // act & assert
            //Assert.That(() => _demeritPointsCalculator.CalculateDemeritPoints(speed),
            //        Throws.);
            Assert.Throws<ArgumentOutOfRangeException>(() => _demeritPointsCalculator.CalculateDemeritPoints(speed));
        }

        [Test]
        [TestCase(1)]       // check non zero yet less than speed limit
        [TestCase(64)]      // less than speed limit
        [TestCase(65)]      // equal to speed limit
        public void CalculateDemeritPoints_SpeedValidRange_ReturnsZero(int speed)
        {
            // arrange
            // act
            var actual = _demeritPointsCalculator.CalculateDemeritPoints(speed);

            // assert
            Assert.That(actual, Is.Zero);
        }

        [Test]
        [TestCase(66, 65, 5, 0)]   // 1 greater than speed limit but less than max speed - integer devision result 0
        [TestCase(70, 65, 5, 1)]   // 1 greater than speed limit but less than max speed - integer devision result 1
        [TestCase(71, 65, 5, 1)]   // 1 greater than speed limit but less than max speed - integer devision result 1
        [TestCase(75, 65, 5, 2)]   // 1 greater than speed limit but less than max speed - integer devision result 46
        [TestCase(299, 65, 5, 46)]  // 1 less than max speed but greater than speed limit
        public void CalculateDemeritPoints_SpeedGreaterToSpeedLimit_ReturnsZero(int speed, int speedLimit, int kmPerDemeritPoint, int expected)
        {
            // arrange
            //var expected = (speed - speedLimit) / kmPerDemeritPoint;

            // act
            var actual = _demeritPointsCalculator.CalculateDemeritPoints(speed);

            // assert
            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
