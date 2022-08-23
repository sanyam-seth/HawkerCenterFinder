using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HawkerCenterFinder.BL.Interface
{
    public interface ICredentialManager
    {
        /// <summary>
        /// Validating the input user credentials 
        /// </summary>
        /// <param name="username">Username of the user</param>
        /// <param name="password">Password of the user</param>
        /// <returns><see cref="bool"/>Value stating the validation of the credentials</returns>
        Task<bool> ValidateUserCredentials(string username, string password);
    }
}
