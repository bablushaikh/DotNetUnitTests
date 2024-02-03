using HotelReservationCancellation.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HotelReservationCancellation.UnitTests
{
    [TestClass]
    public class ReservationCancellationTests
    {
        [TestMethod]
        public void CanBeCancelledBy_Admin_ReturnsTrue()
        {
            // Arrange
            var reservation = new Reservation();

            // Act
            var res = reservation.CanBeCancelledBy(new User { IsAdmin = true });

            // Assert
            Assert.IsTrue(res);
        }

        [TestMethod]
        public void CanBeCancelledBy_BookedUser_ReturnsTrue()
        {
            // Arrange
            var user = new User ();
            var reservation = new Reservation { CreatedBy = user};

            // Act
            var res = reservation.CanBeCancelledBy(user);

            // Assert
            Assert.IsTrue(res);
        }

        [TestMethod]
        public void CanBeCancelledBy_RandomUser_ReturnsFalse()
        {
            // Arrange
            var user = new User();
            var reservation = new Reservation { CreatedBy = new User() };

            // Act
            var res = reservation.CanBeCancelledBy(new User());

            // Assert
            Assert.IsFalse(res);
        }
    }
}
