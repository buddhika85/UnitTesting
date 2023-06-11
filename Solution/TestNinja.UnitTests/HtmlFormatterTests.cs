using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class HtmlFormatterTests
    {
        private HtmlFormatter _htmlFormatter;


        [SetUp]
        public void Setup()
        {
            _htmlFormatter = new HtmlFormatter();
        }

        [TestCase("Hello")]
        [TestCase("World")]
        [TestCase("Hello World")]
        public void FormatAsBold_WhenCalled_ReturnBold(string input)
        {
            // arrange            
            var expected = $"<strong>{input}</strong>";

            // act
            var actual = _htmlFormatter.FormatAsBold(input);

            // assert
            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
