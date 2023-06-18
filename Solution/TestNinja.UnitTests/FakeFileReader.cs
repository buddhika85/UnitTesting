using TestNinja.Mocking;

namespace TestNinja.UnitTests
{
    public class FakeFileReader : IFileReader
    {
        public string Read(string path)
        {
            //return "[" +
            //    "{id: 1, Title: \"abc\", IsProcessed: true}" +
            //    "{id: 2, Title: \"def\", IsProcessed: false}" +
            //    "]";
            return "";
        }
    }
}
