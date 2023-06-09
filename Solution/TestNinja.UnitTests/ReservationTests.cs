using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class ReservationTests
    {
        public Reservation Reservation { get; set; } = null!;

        [SetUp]
        public void Setup()
        {
            Reservation = new Reservation();
        }

        [Test]
        public void CanBeCancelledBy_IsAdmin_ReturnsTrue()
        {
            // arrange
            var admin = new User { IsAdmin = true };
            Reservation.MadeBy = new User { IsAdmin = false };

            // act
            var result = Reservation.CanBeCancelledBy(admin);

            // assert
            Assert.That(result, Is.True);
        }
    }
}