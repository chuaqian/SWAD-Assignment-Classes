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
        public string carInsurance { get; set; }
        public int carMileage { get; set; }
        public string status { get; set; }

        public List<AvailabilitySlot> AvailabilitySlots { get; set; }

        public Car()
        {
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
    }
}
