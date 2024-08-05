using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWADAssgClasses
{
    public class Accident
    {
        public string accidentId { get; set; }
        public DateTime accidentDate { get; set; }
        public string description { get; set; }
        public string status { get; set; }
        public string resolvingDetails { get; set; }
    }
}
