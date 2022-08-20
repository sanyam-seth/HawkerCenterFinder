using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HawkerCenterFinder.Model.DataContract
{
    [DataContract]
    public class UserLogin
    {
        [Required(ErrorMessage = "User Name is required")]
        [DataMember]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataMember]
        public string Password { get; set; }
    }
}
