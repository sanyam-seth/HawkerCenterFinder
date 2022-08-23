using HawkerCenterFinder.BL.Interface;
using HawkerCenterFinder.DataLayer.Interface;
using HawkerCenterFinder.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HawkerCenterFinder.BL.Business
{
    public class CredentialManager : ICredentialManager
    {
        private readonly IUserCredentialRepository _userCredentialRepository;
        public CredentialManager(IUserCredentialRepository userCredentialRepository)
        {
            _userCredentialRepository = userCredentialRepository;
        }

        /// <summary>
        /// Validating the input user credentials 
        /// </summary>
        /// <param name="username">Username of the employee</param>
        /// <param name="password">Password of the employee</param>
        /// <returns><see cref="bool"/>Value stating the validation of the credentials</returns>
        public async Task<bool> ValidateUserCredentials(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                throw new ArgumentNullException("Username or Password cannot be empty");
            }

            UserCredentials credentials = await _userCredentialRepository.GetUserCredentialsAsync(username);

            if (credentials == null)
                return false;

            return credentials.Username == username && credentials.Password == password;
        }
    }
}

