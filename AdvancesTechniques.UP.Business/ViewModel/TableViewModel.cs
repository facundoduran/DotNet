using AdvancedTechniques.UP.Business.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTechniques.UP.Business.ViewModel
{
    public class TableViewModel
    {
        public int TableId { get; set; }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public virtual List<Booking> Bookings { get; set; }
    }
}
