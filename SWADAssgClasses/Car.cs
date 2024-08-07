using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWADAssgClasses
{
    public class Car
    {
        public string carId { get; set; }
        public string carMake { get; set; }
        public string carModel { get; set; }
        public int carYear { get; set; }
        public decimal rentalRate { get; set; }
        public bool carInsurance { get; set; }
        public int carMileage { get; set; }
        public string status { get; set; }

        public List<AvailabilitySlot> AvailabilitySlots { get; set; }

        public Car(string carId, string carMake, string carModel, int carYear, int carMileage, bool carInsurance, decimal rentalRate, string status)
        {
            this.carId = carId;
            this.carMake = carMake;
            this.carModel = carModel;
            this.carYear = carYear;
            this.carMileage = carMileage;
            this.carInsurance = carInsurance;
            this.rentalRate = rentalRate;
            this.status = status;
            AvailabilitySlots = new List<AvailabilitySlot>();
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
            Console.WriteLine($"Car ID: {carId}, Make: {carMake}, Model: {carModel}, Year: {carYear}, Mileage: {carMileage}, Insurance: {carInsurance}, Rental Rate: {rentalRate}, Status: {status}");
        }

        public static Car FindCar(List<Car> cars, string carId)
        {
            return cars.Find(car => car.carId == carId);
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
    }
}
