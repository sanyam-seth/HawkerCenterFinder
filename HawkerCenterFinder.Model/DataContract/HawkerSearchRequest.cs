using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HawkerCenterFinder.Model.DataContract
{
    [DataContract]
    public class HawkerSearchRequest
    {
        [DataMember]
        public string latitude { get; set; }

        [DataMember]
        public string longitude { get; set; }

        [DataMember]
        public int numberOfClosest { get; set; }
    }
}
