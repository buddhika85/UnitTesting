using TestNinja.Mocking;

namespace TestNinja.UnitTests
{
    public class FakeFileReader : IFileReader
    {
        private string _fileContentJson = "{id: 1, Title: \"abc\", IsProcessed: true}";
        public FakeFileReader(bool isEmpty)
        {
            if (isEmpty)
                _fileContentJson = "";
        }
        public string Read(string path)
        {
            return _fileContentJson;
        }
    }
}
