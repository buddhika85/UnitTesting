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
            _booking = new Booking { Id = 1 };
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
        public void OverlappingBookingsExist_BookingWithOverlapExists_ReturnsFirstReference()
        {
            // arrange
            _booking.Status = "Active";
            _booking.ArrivalDate = new DateTime(2000, 1, 5);
            _booking.DepartureDate = new DateTime(2000, 1, 8);
            var bookings = new List<Booking>
            {
                new()
                {
                    Id = _booking.Id,
                    Status = "Active",
                    ArrivalDate = _booking.DepartureDate.AddDays(-1),
                    DepartureDate = _booking.ArrivalDate.AddDays(1),
                    Reference = "Ref1"
                },
                new()
                {
                    Id = _booking.Id,
                    Status = "Active",
                    ArrivalDate = _booking.DepartureDate.AddDays(-1),
                    DepartureDate = _booking.ArrivalDate.AddDays(1),
                    Reference = "Ref2"
                },
                new()
                {
                    Id = _booking.Id,
                    Status = "Active",
                    ArrivalDate = _booking.DepartureDate,
                    DepartureDate = _booking.ArrivalDate,
                    Reference = "Ref3"
                },
            };
            var queryable = bookings.AsQueryable();
            _bookingRepositoryMock.Setup(x => x.FindActiveBookings(_booking.Id))
                .Returns(queryable);

            // act
            var actual = BookingHelper.OverlappingBookingsExist(_booking,
                _bookingRepositoryMock.Object);

            // assert
            Assert.That(actual, Is.Not.Null);
            Assert.That(actual, Is.EqualTo("Ref1"));    // first bookings reference
        }

        [Test]
        public void OverlappingBookingsExist_NoBookingWithOverlap_ReturnsEmptyStr()
        {
        }
    }
}
