using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWADAssgClasses
{
    public class AvailabilitySlot
    {
        public string slotId { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public AvailabilitySlot(string slotId, DateTime startDate, DateTime endDate)
        {
            this.slotId = slotId;
            this.startDate = startDate;
            this.endDate = endDate;
        }
    }
}
