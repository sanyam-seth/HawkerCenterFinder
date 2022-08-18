using HawkerCenterFinder.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HawkerCenterFinder.DataLayer.Interface
{
    public interface IUserCredentialRepository
    {
        /// <summary>
        /// Get Employee Credentials 
        /// </summary>
        /// <param name="username"> username of the employee</param>
        /// <returns><see cref="UserCredentials"/></returns>
        Task<UserCredentials?> GetEmployeeCredentialsAsync(string username);
    }
}
