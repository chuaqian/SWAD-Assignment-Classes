using System;
using SWADAssgClasses;

public class Rayann
{
    public static void Main()
    {
        RegisterCar();
    }

    public static void RegisterCar()
    {
        Console.Write("Enter car make: ");
        string carMake = Console.ReadLine();

        Console.Write("Enter car model: ");
        string carModel = Console.ReadLine();

        Console.Write("Enter car year: ");
        int carYear = int.Parse(Console.ReadLine());

        Console.Write("Enter car mileage: ");
        int carMileage = int.Parse(Console.ReadLine());

        Console.Write("Enter car insurance (true/false): ");
        bool carInsurance = bool.Parse(Console.ReadLine());

        Console.Write("Enter rental rate: $");
        decimal rentalRate = decimal.Parse(Console.ReadLine());

        string carId;
        Car car = new Car("", "", "", 0, 0, false, 0, "");

        while (true)
        {
            Console.Write("Enter car ID: ");
            carId = Console.ReadLine();

            if (car.VerifyCarId(carId))
            {
                break;
            }
            else
            {
                Console.WriteLine($"Car {carId} already exists. Please enter a unique car ID.");
            }
        }

        string status = "Available";

        car = new Car(carId, carMake, carModel, carYear, carMileage, carInsurance, rentalRate, status);
        car.AddCar(car);

        Console.WriteLine("Car registration successful!");
        Console.WriteLine($"Car {car.carId} is registered and available for rent.");
    }
}
