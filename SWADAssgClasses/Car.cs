using System;
using System.Collections.Generic;
using System.IO;

namespace SWADAssgClasses
{
    public class Car
    {
        private const string FilePath = "car_listings.csv";

        public string carPlate { get; set; }
        public string carMake { get; set; }
        public string carModel { get; set; }
        public int carYear { get; set; }
        public decimal rentalRate { get; set; }
        public bool carInsurance { get; set; }
        public int carMileage { get; set; }
        public string status { get; set; }

        public List<AvailabilitySlot> AvailabilitySlots { get; set; }

        public Car(string carPlate, string carMake, string carModel, int carYear, int carMileage, bool carInsurance, decimal rentalRate, string status)
        {
            this.carPlate = carPlate;
            this.carMake = carMake;
            this.carModel = carModel;
            this.carYear = carYear;
            this.carMileage = carMileage;
            this.carInsurance = carInsurance;
            this.rentalRate = rentalRate;
            this.status = status;
            AvailabilitySlots = new List<AvailabilitySlot>();

            if (!File.Exists(FilePath))
            {
                File.Create(FilePath).Close();
            }
        }

        public bool CheckAvailability(DateTime startDate, DateTime endDate)
        {
            foreach (var slot in AvailabilitySlots)
            {
                if (slot.startDate <= startDate && slot.endDate >= endDate)
                {
                    return true;
                }
            }
            return false;
        }

        public void DisplayCarDetails()
        {
            Console.WriteLine($"Car Plate: {carPlate}, Make: {carMake}, Model: {carModel}, Year: {carYear}, Mileage: {carMileage}, Insurance: {carInsurance}, Rental Rate: {rentalRate}, Status: {status}");
        }

        public static Car FindCar(List<Car> cars, string carPlate)
        {
            return cars.Find(car => car.carPlate == carPlate);
        }

        public bool IsAvailable(DateTime startDate, DateTime endDate)
        {
            foreach (var slot in AvailabilitySlots)
            {
                if (slot.startDate <= startDate && slot.endDate >= endDate)
                {
                    return true;
                }
            }
            return false;
        }

        public void AddAvailabilitySlot(AvailabilitySlot slot)
        {
            AvailabilitySlots.Add(slot);
        }

        public string ToCsv()
        {
            return $"{carPlate},{carMake},{carModel},{carYear},{carMileage},{carInsurance},{rentalRate},{status}";
        }

        public bool VerifyCarPlate(string carPlate)
        {
            var cars = GetAllCars();
            foreach (var car in cars)
            {
                if (car.carPlate == carPlate)
                {
                    return false;
                }
            }
            return true;
        }

        public void AddCar(Car car)
        {
            using (var writer = new StreamWriter(FilePath, true))
            {
                writer.WriteLine(car.ToCsv());
            }
        }

        public List<Car> GetAllCars()
        {
            var cars = new List<Car>();
            var lines = File.ReadAllLines(FilePath);

            foreach (var line in lines)
            {
                var values = line.Split(',');
                var car = new Car(
                    values[0],
                    values[1],
                    values[2],
                    int.Parse(values[3]),
                    int.Parse(values[4]),
                    bool.Parse(values[5]),
                    decimal.Parse(values[6]),
                    values[7]
                );
                cars.Add(car);
            }

            return cars;
        }
    }
}
