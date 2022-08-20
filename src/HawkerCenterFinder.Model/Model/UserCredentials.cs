using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace HawkerCenterFinder.Model
{
    [DataContract]
    public class UserCredentials
    {
        [DataMember]
        [Required]
        public string Username { get; set; }

        [DataMember]
        public string Password { get; set; }

        public UserCredentials(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}