﻿using HawkerCenterFinder.DataLayer.Interface;
using HawkerCenterFinder.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HawkerCenterFinder.DataLayer.Query
{
    internal class UserCredentialRepository : IUserCredentialRepository
    {
        /// <summary>
        /// Get Employee Credentials 
        /// </summary>
        /// <param name="username"> username of the employee</param>
        /// <returns><see cref="UserCredentials"/></returns>
        public async Task<UserCredentials?> GetEmployeeCredentialsAsync(string username)
        {
            if (string.IsNullOrEmpty(username))
                throw new ArgumentNullException("Username cannot be empty");
            try
            {
                using (var db = new HawkerDbContext())
                {
                    var employeeDbSet = db.Set<UserCredentials>();
                    var credentials = await employeeDbSet.FindAsync(username);
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