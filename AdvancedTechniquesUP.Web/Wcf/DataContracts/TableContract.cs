using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace AdvancedTechniques.Web.Wcf.DataContracts
{
    [DataContract]
    public class TableContract
    {
        [DataMember]
        public int TableId { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public int Capacity { get; set; }

        [DataMember]
        public virtual List<BookingContract> Bookings { get; set; }
    }
}