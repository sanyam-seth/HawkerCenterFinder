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
    public class HawkerCenterRepository : IHawkerCenterRepository
    {
        /// <summary>
        /// Gets the N closest hawker centers based on the search request
        /// </summary>
        /// <returns><see cref="List{Hawker}"/></returns>
        public List<Hawker> GetAllHawkers()
        {
            try
            {
                using (var db = new HawkerDbContext())
                {
                    var hawkerDbSet = db.Set<Hawker>();
                    if (!hawkerDbSet.Any())
                        return new List<Hawker>();
                    return hawkerDbSet.ToList();
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Adds the new Hawker Centers in DB
        /// </summary>
        public async Task InsertHawkerCentersAsync(List<Hawker> hawkersList)
        {
            if (hawkersList == null || hawkersList.Count == 0)
                return;
            try
            {
                using (var db = new HawkerDbContext())
                {
                    var hawkerDbSet = db.Set<Hawker>();
                    hawkerDbSet.AddRange(hawkersList);
                    await db.SaveChangesAsync();
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
