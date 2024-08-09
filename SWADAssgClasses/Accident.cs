using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWADAssgClasses
{
    public class Accident
    {
        private static int _nextId = 1;

        public int AccidentId { get; private set; }
        public DateTime AccidentDate { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public string ResolvingDetails { get; set; }

        public Accident(DateTime accidentDate, string description, bool status, string resolvingDetails)
        {
            AccidentId = _nextId++;
            AccidentDate = accidentDate;
            Description = description;
            Status = status;
            ResolvingDetails = resolvingDetails;
        }
    }
}
