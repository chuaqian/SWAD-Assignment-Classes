using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWADAssgClasses
{
    public class CarOwner : User
    {
        public decimal earnings { get; set; }
        public List<Car> ownedCars { get; set; }

        public CarOwner(string userId, string fullName, string contactDetails, string email, string password, bool isVerified, decimal earnings)
            : base(userId, fullName, contactDetails, email, password, isVerified)
        {
            this.earnings = earnings; 
            ownedCars = new List<Car>();
        }
    }
}
