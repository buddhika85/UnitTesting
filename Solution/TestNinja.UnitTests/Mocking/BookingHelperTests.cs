using Moq;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    public class BookingHelperTests
    {
        private Booking _booking = null!;
        private Mock<IBookingRepository> _bookingRepositoryMock;

        [SetUp]
        public void SetUp()
        {
            _booking = new Booking();
            _bookingRepositoryMock = new Mock<IBookingRepository>();
        }


        [Test]
        public void OverlappingBookingsExist_BookingStatusCancelled_ReturnsEmptyStr()
        {
            // arrange
            _booking.Status = "Cancelled";

            // act
            var actual = BookingHelper.OverlappingBookingsExist(_booking,
                _bookingRepositoryMock.Object);

            // assert
            Assert.That(actual, Is.Not.Null);
            Assert.That(actual, Is.EqualTo(string.Empty));
        }

        [Test]
        public void OverlappingBookingsExist_BookingWithOverlapExists_ReturnsReference()
        {
        }

        [Test]
        public void OverlappingBookingsExist_NoBookingWithOverlap_ReturnsEmptyStr()
        {
        }
    }
}
