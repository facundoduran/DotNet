using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTechniques.UP.Business.Model
{
    public class Booking
    {
        public int BookingId { get; set; }

        public DateTime FromTime { get; set; }

        public DateTime ToTime { get; set; }

        public Customer Customer { get; set; }

        public Table Table { get; set; }

        public int CustomerId { get; set; }

        public int TableId { get; set; }

        public SalesChannel salesChannel { get; set; }

        public string Code { get; set; }

        public bool IsOverlap(DateTime fromTime, DateTime toTime) 
        {
            /*
            return ((from >= this.FromTime && from < this.ToTime)
                || (to <= this.ToTime && to > this.FromTime)
                || (from <= this.FromTime && to >= this.ToTime));
             */
            if (this.FromTime > this.ToTime || fromTime > toTime)
                return true;

            if (this.FromTime == this.ToTime || fromTime == toTime)
                return false; // No actual date range

            if (this.FromTime == fromTime || this.ToTime == toTime)
                return true; 

            if (this.FromTime < fromTime)
            {
                if (this.ToTime > fromTime && this.ToTime < toTime)
                    return true; // Condition 1

                if (this.ToTime > toTime)
                    return true; // Condition 3
            }
            else
            {
                if (toTime > this.FromTime && toTime < this.ToTime)
                    return true; // Condition 2

                if (toTime > this.ToTime)
                    return true; // Condition 4
            }

            return false;
        }
    }
}
