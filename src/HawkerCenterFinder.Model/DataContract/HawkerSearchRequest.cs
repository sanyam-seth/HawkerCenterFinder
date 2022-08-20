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
        public double latitude { get; set; }

        [DataMember]
        public double longitude { get; set; }

        [DataMember]
        public int numberOfClosest { get; set; }
    }
}
