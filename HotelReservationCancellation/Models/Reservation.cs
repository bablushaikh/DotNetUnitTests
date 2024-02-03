using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationCancellation.Models
{
    public class Reservation
    {
        public User CreatedBy { get; set; }
        public bool CanBeCancelledBy(User user)
        {

            return (user.IsAdmin == true || CreatedBy == user);
        }
    }

    public class User
    {
        public bool IsAdmin { get; set; }
    }
}
