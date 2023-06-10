

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

        [Test]
        public void Max_FirstIsMax_ReturnFirst()
        {
            // arrange 
            var math = new TestNinja.Fundamentals.Math();
            var first = 1;
            var second = 0;

            // act
            var max = math.Max(first, second);

            // assert
            Assert.That(max, Is.EqualTo(first));
        }

        [Test]
        public void Max_SecondIsMax_ReturnSecond()
        {
            // arrange 
            var math = new TestNinja.Fundamentals.Math();
            var first = 1;
            var second = 2;

            // act
            var max = math.Max(first, second);

            // assert
            Assert.That(max, Is.EqualTo(second));
        }
    }
}
