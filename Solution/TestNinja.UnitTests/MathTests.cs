

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class MathTests
    {
        private TestNinja.Fundamentals.Math _math;

        [SetUp]
        public void Setup()
        {
            // before each test method _math object will be executed
            // common logic for all the tests
            _math = new TestNinja.Fundamentals.Math();
        }

        [Test]
        [Ignore("Because Max_WhenCalled_ReturngreaterValue pametrised test covers this")]
        public void Add_PassTwoNums_ReturnSum()
        {
            // arrange           
            var a = 1;
            var b = 2;
            var sum = a + b;

            // act 
            var result = _math.Add(a, b);

            // assert
            Assert.That(result, Is.EqualTo(sum));
        }

        [Test]
        public void Max_FirstIsMax_ReturnFirst()
        {
            // arrange            
            var first = 1;
            var second = 0;

            // act
            var max = _math.Max(first, second);

            // assert
            Assert.That(max, Is.EqualTo(first));
        }

        [Test]
        [Ignore("Because Max_WhenCalled_ReturngreaterValue pametrised test covers this")]
        public void Max_SecondIsMax_ReturnSecond()
        {
            // arrange            
            var first = 1;
            var second = 2;

            // act
            var max = _math.Max(first, second);

            // assert
            Assert.That(max, Is.EqualTo(second));
        }

        [Test]
        [Ignore("Because Max_WhenCalled_ReturngreaterValue pametrised test covers this")]
        public void Max_ArgsEqual_ReturnSameArg()
        {
            // arrange             
            var arg = 1;

            // act
            var max = _math.Max(arg, arg);

            // assert
            Assert.That(max, Is.EqualTo(arg));
        }

        [Test]
        [TestCase(5, 6, 6)]     // arg1 < arg2
        [TestCase(6, 5, 6)]     // arg1 > arg2
        [TestCase(5, 5, 5)]     // arg1 == arg2
        public void Max_WhenCalled_ReturngreaterValue(int argOne, int argTwo, int expected)
        {
            // act
            var max = _math.Max(argOne, argTwo);

            // assert
            Assert.That(max, Is.EqualTo(expected));
        }
    }
}
