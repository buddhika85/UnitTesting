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
        public void ReadVideoTitle_WhenVideosIsNotNull_ReturnsTitleOfFirst()
        {
            // arrange 
            _videoService = new VideoService(new FakeFileReader(isEmpty: false));

            // act
            var title = _videoService.ReadVideoTitle();

            // assert
            Assert.That(title, Is.EqualTo("abc"));
        }
    }
}
