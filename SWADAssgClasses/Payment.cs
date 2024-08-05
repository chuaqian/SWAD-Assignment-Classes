using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWADAssgClasses
{
    public class Payment
    {
        public string paymentId { get; set; }
        public decimal paymentAmount { get; set; }
        public string paymentMethod { get; set; }
        public DateTime paymentDate { get; set; }
        public string paymentStatus { get; set; }
    }
}
