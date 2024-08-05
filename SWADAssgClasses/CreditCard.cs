using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWADAssgClasses
{
    public class CreditCard : Payment
    {
        public string cardNumber { get; set; }
        public string cardHolderName { get; set; }
        public string expirationDate { get; set; }
        public string cvv { get; set; }
    }
}
