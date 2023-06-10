

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class MathTests
    {
        [Test]
        public void Add_PassTwoNums_ReturnSum()
        {
            // arrange
            var math = new TestNinja.Fundamentals.Math();
            var a = 1;
            var b = 2;
            var sum = a + b;

            // act 
            var result = math.Add(a, b);

            // assert
            Assert.That(result, Is.EqualTo(sum));
        }
    }
}
