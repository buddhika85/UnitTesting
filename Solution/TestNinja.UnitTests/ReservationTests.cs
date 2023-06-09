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

        [Test]
        public void CanBeCancelledBy_IsNotAdmin_ReturnsFalse()
        {
            // arrange
            var nonAdmin = new User { IsAdmin = false };
            Reservation.MadeBy = new User { IsAdmin = false };

            // act
            var result = Reservation.CanBeCancelledBy(nonAdmin);

            // assert
            Assert.That(result, Is.False);
        }

        [Test]
        public void CanBeCancelledBy_IsMadeByUser_ReturnsTrue()
        {
            // arrange
            var madebyUser = new User { IsAdmin = false };
            Reservation.MadeBy = madebyUser;

            // act
            var result = Reservation.CanBeCancelledBy(madebyUser);

            // assert
            Assert.That(result, Is.True);
        }
    }
}