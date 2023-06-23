using Moq;
using System.Net;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    public class InstallerHelperTests
    {
        private InstallerHelper _installerHelper = null!;
        private Mock<IFileDownloader> _fileDownloaderMock;

        [SetUp]
        public void SetUp()
        {

        }

        [Test]
        public void DownloadInstaller_WhenNoWebException_ReturnTrue()
        {
            // arrange
            _fileDownloaderMock = new Mock<IFileDownloader>();
            _installerHelper = new InstallerHelper(_fileDownloaderMock.Object);

            // act
            var actual = _installerHelper.DownloadInstaller("", "");

            // assert
            Assert.That(actual, Is.True);
        }

        [Test]
        public void DownloadInstaller_WhenFileDownloaderIsNull_ThrowsNullException()
        {
            // arrange
            _installerHelper = new InstallerHelper(null);

            // act assert
            Assert.Throws<NullReferenceException>(() => _installerHelper.DownloadInstaller("", ""));
        }

        [Test]
        public void DownloadInstaller_WhenWebExceptionThrownWithSpecificStrings_ReturnsFalse()
        {
            // arrange
            var customerName = "customer";
            var installerName = "installer";
            _fileDownloaderMock = new Mock<IFileDownloader>();
            _fileDownloaderMock.Setup(x =>
                x.DownloadFile($"https://example.com/{customerName}/{installerName}", null)).Throws<WebException>();
            _installerHelper = new InstallerHelper(_fileDownloaderMock.Object);

            // act
            var actual = _installerHelper.DownloadInstaller(customerName, installerName);

            // assert
            Assert.That(actual, Is.False);
        }


        [Test]
        public void DownloadInstaller_WhenWebExceptionThrownWithAnyString_ReturnsFalse()
        {
            // arrange

            _fileDownloaderMock = new Mock<IFileDownloader>();

            //'It' is class from Moq - It.IsAny<string>() - says it can be any string
            _fileDownloaderMock.Setup(x =>
                x.DownloadFile(It.IsAny<string>(), It.IsAny<string>())).Throws<WebException>();
            _installerHelper = new InstallerHelper(_fileDownloaderMock.Object);

            // act
            var actual = _installerHelper.DownloadInstaller("any string...", "any string ..");

            // assert
            Assert.That(actual, Is.False);
        }
    }
}
