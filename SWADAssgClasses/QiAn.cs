// Chua Qi An IT04 S10258309E

using SWADAssgClasses;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace SWADAssgClasses
{
    class QiAn
    {
        static void Main(string[] args)
        {
            // set a fixed current date and time
            DateTime currentDateTime = DateTime.ParseExact("2024-08-05 10:00", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture);
            Console.WriteLine("Current Date/Time: " + currentDateTime.ToString("yyyy-MM-dd HH:mm"));

            // create a sample renter
            Renter renter = new Renter("1", "John Doe", "123 Main St", "john@example.com", "password", true,
                "D1234567", "Credit Card", 200m, false, true, DateTime.ParseExact("1990-01-01", "yyyy-MM-dd", CultureInfo.InvariantCulture), "123 Main St");

            Car car = new Car("C1", "Toyota", "Camry", 2020, 50000, true, 50m, "Available", "SGX1234A");

            car.AvailabilitySlots.Add(new AvailabilitySlot("S1", DateTime.ParseExact("2024-08-05 12:00", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                DateTime.ParseExact("2024-08-15 12:00", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture)));

            // create multiple bookings, some inactive and one active
            Booking pastBooking1 = new Booking("B0", DateTime.ParseExact("2024-07-01 10:00", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                DateTime.ParseExact("2024-07-07 10:00", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture), 300m, "Credit Card", "Return Location", "Pick Up Location", false);

            Booking pastBooking2 = new Booking("B2", DateTime.ParseExact("2024-07-10 10:00", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                DateTime.ParseExact("2024-07-15 10:00", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture), 400m, "Credit Card", "Return Location", "Pick Up Location", false);

            Booking activeBooking = new Booking("B1", DateTime.ParseExact("2024-08-07 10:00", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                DateTime.ParseExact("2024-08-12 10:00", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture), 250m, "Credit Card", "Return Location", "Pick Up Location", true)
            {
                RentedCar = car,
                Renter = renter
            };

            // add bookings to renter
            renter.AddBooking(pastBooking1);
            renter.AddBooking(pastBooking2);
            renter.AddBooking(activeBooking);

            // Set the boolean value based on whether an active booking exists or not
            bool hasBooking = activeBooking != null && activeBooking.isActive;

            if (!hasBooking)
            {
                Console.WriteLine("No active booking found. Please make a reservation first.");
                return;
            }

            // get current reservation details from the active booking
            var currentDetails = activeBooking.GetCurrentReservationDetails();
            Console.WriteLine("Current Booking Start Date: " + currentDetails.startDate.ToString("yyyy-MM-dd HH:mm"));
            Console.WriteLine("Current Booking End Date: " + currentDetails.endDate.ToString("yyyy-MM-dd HH:mm"));

            // check if modification is allowed for start date
            if ((currentDetails.startDate - currentDateTime).TotalHours < 24)
            {
                Console.WriteLine("Modification not allowed within 24 hours of the start date/time.");
                return;
            }

            while (true) // loop until a valid modification is made or user decides to exit
            {
                // ask the user what they want to modify
                Console.WriteLine("Do you want to modify the start date or end date? (Enter 'start' or 'end')");
                string choice = Console.ReadLine().ToLower();

                if (choice == "start")
                {
                    // generate available start times from the current date onwards, ensuring no past dates are shown
                    List<DateTime> availableStartTimes = GenerateAvailableStartTimes(currentDateTime.AddDays(1), currentDetails.endDate.AddMinutes(-1), car);

                    DisplayAvailableTimes(availableStartTimes);

                    DateTime newStartDate;

                    // loop to ensure valid input
                    while (true)
                    {
                        Console.WriteLine("Enter new start date and time from the available options (yyyy-MM-dd HH:mm): ");
                        if (DateTime.TryParseExact(Console.ReadLine(), "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out newStartDate))
                        {
                            if (availableStartTimes.Contains(newStartDate))
                            {
                                break; // valid input, exit loop
                            }
                            else
                            {
                                Console.WriteLine("Invalid selection. Please choose a date/time from the available list.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid date/time format. Please enter a date/time in yyyy-MM-dd HH:mm format.");
                        }
                    }

                    // modify the start date
                    bool modificationSuccess = activeBooking.ModifyBookingDates(newStartDate, currentDetails.endDate, currentDateTime);

                    if (modificationSuccess)
                    {
                        activeBooking.UpdateBookingDetails();
                        activeBooking.NotifyRenter(); // displays "Reservation modified successfully."
                        Console.WriteLine("New Booking Start Date: " + activeBooking.bookingStartDate.ToString("yyyy-MM-dd HH:mm"));
                        Console.WriteLine("Booking End Date: " + activeBooking.bookingEndDate.ToString("yyyy-MM-dd HH:mm"));
                        break; // Exit loop after successful modification
                    }
                    else
                    {
                        Console.WriteLine("Reservation modification failed.");
                    }
                }
                else if (choice == "end")
                {
                    // generate available end times starting from the current end date onwards for 5 days
                    List<DateTime> availableEndTimes = GenerateAvailableEndTimes(currentDetails.startDate, currentDetails.endDate.AddDays(5), car);

                    DisplayAvailableTimes(availableEndTimes);

                    DateTime newEndDate;

                    // loop to ensure valid input
                    while (true)
                    {
                        Console.WriteLine("Enter new end date and time from the available options (yyyy-MM-dd HH:mm): ");
                        if (DateTime.TryParseExact(Console.ReadLine(), "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out newEndDate))
                        {
                            if (availableEndTimes.Contains(newEndDate))
                            {
                                break; // valid input, exit loop
                            }
                            else
                            {
                                Console.WriteLine("Invalid selection. Please choose a date/time from the available list.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid date/time format. Please enter a date/time in yyyy-MM-dd HH:mm format.");
                        }
                    }

                    // modify the end date
                    bool modificationSuccess = activeBooking.ModifyBookingDates(currentDetails.startDate, newEndDate, currentDateTime);

                    if (modificationSuccess)
                    {
                        activeBooking.UpdateBookingDetails();
                        activeBooking.NotifyRenter(); // displays "Reservation modified successfully."
                        Console.WriteLine("Booking Start Date: " + activeBooking.bookingStartDate.ToString("yyyy-MM-dd HH:mm"));
                        Console.WriteLine("New Booking End Date: " + activeBooking.bookingEndDate.ToString("yyyy-MM-dd HH:mm"));
                        break; // Exit loop after successful modification
                    }
                    else
                    {
                        Console.WriteLine("Reservation modification failed.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please enter 'start' or 'end'.");
                }
            }
        }

        // method to generate available start time slots for modification
        static List<DateTime> GenerateAvailableStartTimes(DateTime startDate, DateTime endDate, Car car)
        {
            List<DateTime> availableTimes = new List<DateTime>();

            foreach (var slot in car.AvailabilitySlots)
            {
                DateTime slotStart = slot.startDate > startDate ? slot.startDate : startDate;
                DateTime slotEnd = slot.endDate < endDate ? slot.endDate : endDate;

                for (DateTime date = slotStart.Date; date <= slotEnd.Date; date = date.AddDays(1))
                {
                    for (int hour = 10; hour <= 20; hour++)
                    {
                        DateTime timeSlot = new DateTime(date.Year, date.Month, date.Day, hour, 0, 0);
                        if (timeSlot >= slotStart && timeSlot <= slotEnd)
                        {
                            availableTimes.Add(timeSlot);
                        }
                    }
                }
            }

            return availableTimes;
        }

        // method to generate available end time slots for modification
        static List<DateTime> GenerateAvailableEndTimes(DateTime startDate, DateTime endDate, Car car)
        {
            List<DateTime> availableTimes = new List<DateTime>();

            foreach (var slot in car.AvailabilitySlots)
            {
                DateTime slotStart = slot.startDate > startDate ? slot.startDate : startDate;
                DateTime slotEnd = slot.endDate < endDate ? slot.endDate : endDate;

                for (DateTime date = slotStart.Date; date <= slotEnd.Date; date = date.AddDays(1))
                {
                    for (int hour = 10; hour <= 20; hour++)
                    {
                        DateTime timeSlot = new DateTime(date.Year, date.Month, date.Day, hour, 0, 0);
                        if (timeSlot >= slotStart && timeSlot <= slotEnd)
                        {
                            availableTimes.Add(timeSlot);
                        }
                    }
                }
            }

            return availableTimes;
        }

        // method to display available times to the user
        static void DisplayAvailableTimes(List<DateTime> availableTimes)
        {
            Console.WriteLine("Available Date/Time Slots:");
            foreach (var time in availableTimes)
            {
                Console.WriteLine(time.ToString("yyyy-MM-dd HH:mm"));
            }
        }
    }
}
