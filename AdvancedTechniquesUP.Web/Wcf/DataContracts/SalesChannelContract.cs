using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace AdvancedTechniques.Web.Wcf.DataContracts
{
    [DataContract]
    public enum SalesChannelContract
    {
        Web = 0,
        Desktop = 1
    }
}