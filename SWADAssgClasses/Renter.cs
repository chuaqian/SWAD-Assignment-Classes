
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWADAssgClasses
{
    public class Renter : User
    {
        public string driverLicense { get; set; }
        public string paymentMethod { get; set; }
        public decimal monthlySpending { get; set; }
        public bool roadsideAssistanceDiscount { get; set; }
        public bool isPrime { get; set; }
        public DateTime dateOfBirth { get; set; }
        public string renterAddress { get; set; }
        public List<Booking> bookings { get; set; }

        public Renter(string userId, string fullName, string contactDetails, string email, string password, bool isVerified,
            string driverLicense, string paymentMethod, decimal monthlySpending, bool roadsideAssistanceDiscount,
            bool isPrime, DateTime dateOfBirth, string renterAddress)
            : base(userId, fullName, contactDetails, email, password, isVerified)
        {
            this.driverLicense = driverLicense;
            this.paymentMethod = paymentMethod;
            this.monthlySpending = monthlySpending;
            this.roadsideAssistanceDiscount = roadsideAssistanceDiscount;
            this.isPrime = isPrime;
            this.dateOfBirth = dateOfBirth;
            this.renterAddress = renterAddress;
            this.bookings = new List<Booking>();
        }

        /*
        public bool ModifyReservation(DateTime newStartDate, DateTime newEndDate)
        {
            if (bookings == null)
            {
                Console.WriteLine("no active booking to modify.");
                return false;
            }

            return bookings.ModifyBookingDates(newStartDate, newEndDate);
        }
        */
        public void AddBooking(Booking booking)
        {
            bookings.Add(booking);
        }
    }
}
