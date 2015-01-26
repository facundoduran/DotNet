using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace AdvancedTechniques.Web.Wcf.DataContracts
{
    [DataContract]
    public class CustomerContract
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public string Telephone { get; set; }

        [DataMember]
        public string Email { get; set; }
    }
}