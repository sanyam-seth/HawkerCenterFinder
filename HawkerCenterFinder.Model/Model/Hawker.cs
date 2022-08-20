using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HawkerCenterFinder.Model
{
    [DataContract]
    public class Hawker
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        [Required]
        public string Latitude { get; set; }

        [DataMember]
        [Required]
        public string Longitude { get; set; }

        [DataMember]
        [Required]
        public string ImgUrl { get; set; }

        [DataMember]
        [Required]
        public string Name { get; set; }

        public Hawker(string latitude, string longitude, string imgUrl, string name)
        {
            Name = name;
            ImgUrl = imgUrl;
            Latitude = latitude;
            Longitude = longitude;
        }

        public Hawker()
        {
        }
    }
}
