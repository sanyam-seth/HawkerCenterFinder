using HawkerCenterFinder.DataLayer.Interface;
using HawkerCenterFinder.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HawkerCenterFinder.DataLayer.Query
{
    public class UserCredentialRepository : IUserCredentialRepository
    {
        /// <summary>
        /// Get User Credentials 
        /// </summary>
        /// <param name="username"> username</param>
        /// <returns><see cref="UserCredentials"/></returns>
        public async Task<UserCredentials?> GetUserCredentialsAsync(string username)
        {
            if (string.IsNullOrEmpty(username))
                throw new ArgumentNullException("Username cannot be empty");
            try
            {
                using (var db = new HawkerDbContext())
                {
                    var userDbSet = db.Set<UserCredentials>();
                    var credentials = await userDbSet.FindAsync(username);
                    return credentials;
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
