using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HawkerCenterFinder.Model.DataContract
{
    [DataContract]
    public class HawkerCenterResponse
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string ImgUrl { get; set; }
    }
}
