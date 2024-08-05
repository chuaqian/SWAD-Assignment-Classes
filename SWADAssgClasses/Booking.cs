using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWADAssgClasses
{
    public class Booking
    {
        public string bookingId { get; set; }
        public DateTime bookingStartDate { get; set; }
        public DateTime bookingEndDate { get; set; }
        public decimal bookingRentalFee { get; set; }
        public string bookingPayment { get; set; }
        public string returnLocation { get; set; }
        public string pickUpLocation { get; set; }
        public Car RentedCar { get; set; }
        public Renter Renter { get; set; }

        public Booking(string bookingId, DateTime startDate, DateTime endDate)
        {
            this.bookingId = bookingId;
            this.bookingStartDate = startDate;
            this.bookingEndDate = endDate;
        }

        public bool ModifyBookingDates(DateTime newStartDate, DateTime newEndDate)
        {
            if ((newStartDate - DateTime.Now).TotalHours < 24)
            {
                Console.WriteLine("Modification not allowed within 24 hours of the start date.");
                return false;
            }

            // additional logic to check availability and conflicts could be added here
            bookingStartDate = newStartDate;
            bookingEndDate = newEndDate;
            Console.WriteLine("Booking dates modified successfully.");
            return true;
        }

        public void UpdateBookingDetails()
        {
            // logic to update booking details
            Console.WriteLine("Booking details updated.");
        }

        public void NotifyRenter()
        {
            // logic to notify the renter of the successful modification
            Console.WriteLine("Reservation modified successfully.");
        }

        public (DateTime startDate, DateTime endDate) GetCurrentReservationDetails()
        {
            return (bookingStartDate, bookingEndDate);
        }
    }
}
