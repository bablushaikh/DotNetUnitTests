using HotelReservationCancellation.Models;
using NUnit.Framework;

// Install the below packages on HotelReservationCancellation.NUnit.Tests to run NUnit Test
//install-package Nunit -Version 3.8.1
//install-package NUnit3TestAdapter -Version 3.8.0
namespace HotelReservationCancellation.NUnit.Tests
{
    [TestFixture]
    public class ReservationCancellationNUnitTests
    {
        [Test]
        public void CanBeCancelledBy_Admin_ReturnsTrue()
        {
            // Arrange
            var reservation = new Reservation();

            // Act
            var res = reservation.CanBeCancelledBy(new User { IsAdmin = true });

            // Assert
            Assert.That(res, Is.True);
        }

        [Test]
        public void CanBeCancelledBy_BookedUser_ReturnsTrue()
        {
            // Arrange
            var user = new User();
            var reservation = new Reservation { CreatedBy = user };

            // Act
            var res = reservation.CanBeCancelledBy(user);

            // Assert
            Assert.That(res, Is.True);
        }

        [Test]
        public void CanBeCancelledBy_RandomUser_ReturnsFalse()
        {
            // Arrange
            var user = new User();
            var reservation = new Reservation { CreatedBy = new User() };

            // Act
            var res = reservation.CanBeCancelledBy(new User());

            // Assert
            Assert.That(res, Is.False);
        }
    }
}
