using SWADAssgClasses;
using System;
using System.Collections.Generic;

class Dexter
{
    static List<Car> cars = new List<Car>();
    static List<Booking> bookings = new List<Booking>();

    static void Main(string[] args)
    {
        // Sample Data
        InitializeSampleData();

        // Create a sample Renter
        Renter renter = new Renter("Renter001", "John Doe", "123 Main St", "john.doe@example.com", "password123", true,
                                    "D1234567", "Credit Card", 500.00m, true, true, new DateTime(1985, 5, 15), "123 Renter St");

        Console.WriteLine("Welcome to the iCar Booking System!");
        Console.WriteLine("Type 'exit' at any time to cancel the booking process.");

        // Display all available cars
        Console.WriteLine("Available Cars:");
        foreach (var car in cars)
        {
            car.DisplayCarDetails();
        }

        Car selectedCar = null;
        while (selectedCar == null)
        {
            Console.Write("Please enter the Car ID of the car you want to book: ");
            string carId = Console.ReadLine();

            if (carId.ToLower() == "exit")
            {
                Console.WriteLine("Exiting the booking process. Goodbye!");
                return;
            }

            selectedCar = Car.FindCar(cars, carId);
            if (selectedCar == null)
            {
                Console.WriteLine("Invalid Car ID. Please input a car that is available.");
            }
            else if (selectedCar.status == "Unavailable")
            {
                Console.WriteLine("The car is currently unavailable. Please select another car.");
                selectedCar = null;
            }
            else
            {
                selectedCar.DisplayCarDetails();
                Console.WriteLine("Available Dates for the Car:");
                foreach (var slot in selectedCar.AvailabilitySlots)
                {
                    Console.WriteLine($"From {slot.startDate:dd-MM-yyyy} to {slot.endDate:dd-MM-yyyy}");
                }
            }
        }

        DateTime startDate, endDate;
        while (true)
        {
            Console.Write("Please enter the start date (dd-MM): ");
            string startDateInput = Console.ReadLine();

            if (startDateInput.ToLower() == "exit")
            {
                Console.WriteLine("Exiting the booking process. Goodbye!");
                return;
            }

            if (!TryParseDate(startDateInput, out startDate))
            {
                Console.WriteLine("Invalid date format. Please try again.");
                continue;
            }

            // Check if the start date is at least 2 days after the current date
            if (startDate <= DateTime.Now.AddDays(1))
            {
                Console.WriteLine("The start date must be at least 2 days after today's date. Please try again.");
                continue;
            }

            Console.Write("Please enter the end date (dd-MM): ");
            string endDateInput = Console.ReadLine();

            if (endDateInput.ToLower() == "exit")
            {
                Console.WriteLine("Exiting the booking process. Goodbye!");
                return;
            }

            if (!TryParseDate(endDateInput, out endDate))
            {
                Console.WriteLine("Invalid date format. Please try again.");
                continue;
            }

            if (selectedCar.IsAvailable(startDate, endDate))
            {
                break;
            }
            else
            {
                Console.WriteLine("The car is not available during the specified dates. Please try again.");
            }
        }

        string pickUpMethod = string.Empty;
        while (true)
        {
            Console.WriteLine("Please select the pickup method:");
            Console.WriteLine("1. Delivery to Location");
            Console.WriteLine("2. iCar Station PickUp/DropOff");
            Console.Write("Enter 1 or 2: ");
            string pickUpMethodOption = Console.ReadLine();

            if (pickUpMethodOption.ToLower() == "exit")
            {
                Console.WriteLine("Exiting the booking process. Goodbye!");
                return;
            }

            if (pickUpMethodOption == "1")
            {
                pickUpMethod = "Delivery to Location";
                break;
            }
            else if (pickUpMethodOption == "2")
            {
                pickUpMethod = "iCar Station PickUp/DropOff";
                break;
            }
            else
            {
                Console.WriteLine("Invalid option. Please try again.");
            }
        }

        Console.Write("Please enter the pickup location: ");
        string pickUpLocation = Console.ReadLine();

        if (pickUpLocation.ToLower() == "exit")
        {
            Console.WriteLine("Exiting the booking process. Goodbye!");
            return;
        }

        string dropOffMethod = string.Empty;
        while (true)
        {
            Console.WriteLine("Please select the drop-off method:");
            Console.WriteLine("1. Delivery to Location");
            Console.WriteLine("2. iCar Station PickUp/DropOff");
            Console.Write("Enter 1 or 2: ");
            string dropOffMethodOption = Console.ReadLine();

            if (dropOffMethodOption.ToLower() == "exit")
            {
                Console.WriteLine("Exiting the booking process. Goodbye!");
                return;
            }

            if (dropOffMethodOption == "1")
            {
                dropOffMethod = "Delivery to Location";
                break;
            }
            else if (dropOffMethodOption == "2")
            {
                dropOffMethod = "iCar Station PickUp/DropOff";
                break;
            }
            else
            {
                Console.WriteLine("Invalid option. Please try again.");
            }
        }

        Console.Write("Please enter the drop-off location: ");
        string dropOffLocation = Console.ReadLine();

        if (dropOffLocation.ToLower() == "exit")
        {
            Console.WriteLine("Exiting the booking process. Goodbye!");
            return;
        }

        Console.Write("Please confirm your booking (Yes/No): ");
        string confirmation = Console.ReadLine();

        if (confirmation.ToLower() == "exit")
        {
            Console.WriteLine("Exiting the booking process. Goodbye!");
            return;
        }

        if (confirmation.ToLower() == "yes")
        {
            Booking newBooking = new Booking(Guid.NewGuid().ToString(), startDate, endDate, selectedCar.rentalRate, "Payment details in payment page", dropOffLocation, pickUpLocation, true);
            renter.AddBooking(newBooking);

            selectedCar.status = "Booked";

            Console.WriteLine("Booking confirmed!");
            Console.WriteLine($"Car ID: {selectedCar.carId}");
            Console.WriteLine($"Start Date: {startDate:dd-MM-yyyy}");
            Console.WriteLine($"End Date: {endDate:dd-MM-yyyy}");
            Console.WriteLine("Booking details have been recorded and a confirmation email has been sent.");
        }
        else
        {
            Console.WriteLine("Booking not confirmed. Exiting...");
        }

        Console.WriteLine("Thank you for using the iCar Booking System!");
    }

    static bool TryParseDate(string input, out DateTime date)
    {
        date = DateTime.MinValue;
        if (DateTime.TryParseExact(input + "-" + DateTime.Now.Year, "dd-MM-yyyy", null, System.Globalization.DateTimeStyles.None, out date))
        {
            return true;
        }
        return false;
    }

    static void InitializeSampleData()
    {
        var car1 = new Car("Car001", "Toyota", "Camry", 2020, 15000, true, 50.00m, "Available");
        car1.AddAvailabilitySlot(new AvailabilitySlot("Slot001", DateTime.Now.AddDays(-5), DateTime.Now.AddDays(10)));
        car1.AddAvailabilitySlot(new AvailabilitySlot("Slot002", DateTime.Now.AddDays(15), DateTime.Now.AddDays(20)));

        var car2 = new Car("Car002", "Honda", "Civic", 2019, 20000, true, 45.00m, "Available");
        car2.AddAvailabilitySlot(new AvailabilitySlot("Slot003", DateTime.Now.AddDays(5), DateTime.Now.AddDays(12)));
        car2.AddAvailabilitySlot(new AvailabilitySlot("Slot004", DateTime.Now.AddDays(20), DateTime.Now.AddDays(25)));

        var car3 = new Car("Car003", "Ford", "Focus", 2018, 30000, true, 40.00m, "Available");
        car3.AddAvailabilitySlot(new AvailabilitySlot("Slot005", DateTime.Now.AddDays(3), DateTime.Now.AddDays(8)));
        car3.AddAvailabilitySlot(new AvailabilitySlot("Slot006", DateTime.Now.AddDays(18), DateTime.Now.AddDays(22)));

        var car4 = new Car("Car004", "Nissan", "Altima", 2017, 35000, true, 35.00m, "Unavailable");
        car4.AddAvailabilitySlot(new AvailabilitySlot("Slot007", DateTime.Now.AddDays(1), DateTime.Now.AddDays(6)));
        car4.AddAvailabilitySlot(new AvailabilitySlot("Slot008", DateTime.Now.AddDays(10), DateTime.Now.AddDays(15)));

        cars.Add(car1);
        cars.Add(car2);
        cars.Add(car3);
        cars.Add(car4);
    }
}
