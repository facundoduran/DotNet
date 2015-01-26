using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace AdvancedTechniques.Web.Wcf.DataContracts
{
    [DataContract]
    public class BookingContract
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public DateTime? FromTime { get; set; }

        [DataMember]
        public DateTime? ToTime { get; set; }

        [DataMember]
        public CustomerContract Customer { get; set; }

        [DataMember]
        public int DinersQuantity { get; set; }

        [DataMember]
        public int CustomerId { get; set; }

        [DataMember]
        public int TableId { get; set; }

        [DataMember]
        public SalesChannelContract salesChannel { get; set; }
    }
}