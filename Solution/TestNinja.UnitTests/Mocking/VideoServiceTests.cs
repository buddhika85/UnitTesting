using Moq;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    public class VideoServiceTests
    {
        private VideoService _videoService;

        //[SetUp]
        //public void SetUp()
        //{
        //    _videoService = new VideoService();
        //}

        #region WITH_FAKES
        [Test]
        [TestCase("Error parsing the video.")]
        public void ReadVideoTitle_WhenVideosNull_ReturnErrorMessage(string errorMessage)
        {
            // arrange 
            _videoService = new VideoService(new FakeFileReader(isEmpty: true));

            // act
            var error = _videoService.ReadVideoTitle();

            // assert
            Assert.That(error, Is.EqualTo(errorMessage));
        }

        [Test]
        public void ReadVideoTitle_WhenVideosIsNotNull_ReturnsTitle()
        {
            // arrange 
            _videoService = new VideoService(new FakeFileReader(isEmpty: false));

            // act
            var title = _videoService.ReadVideoTitle();

            // assert
            Assert.That(title, Is.EqualTo("abc"));
        }

        #endregion WITH_FAKES

        #region WITH_MOCKS
        [Test]
        [TestCase("Error parsing the video.")]
        public void ReadVideoTitle_WithMoqWhenVideosNull_ReturnErrorMessage(string errorMessage)
        {
            // arrange 
            var mockFileReader = new Mock<IFileReader>();
            mockFileReader.Setup(x => x.Read("video.txt")).Returns("");
            _videoService = new VideoService(mockFileReader.Object);

            // act
            var error = _videoService.ReadVideoTitle();

            // assert
            Assert.That(error, Is.EqualTo(errorMessage));
        }

        public void ReadVideoTitle_WithMoqWhenVideosIsNotNull_ReturnsTitle()
        {
            // arrange 
            var mockFileReader = new Mock<IFileReader>();
            mockFileReader.Setup(x => x.Read("video.txt")).Returns("{id: 1, Title: \"abc\", IsProcessed: true}");
            _videoService = new VideoService(new FakeFileReader(isEmpty: false));

            // act
            var title = _videoService.ReadVideoTitle();

            // assert
            Assert.That(title, Is.EqualTo("abc"));
        }

        #endregion WITH_MOCKS
    }
}
