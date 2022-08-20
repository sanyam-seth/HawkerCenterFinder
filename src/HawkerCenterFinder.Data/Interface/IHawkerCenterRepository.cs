using HawkerCenterFinder.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HawkerCenterFinder.DataLayer.Interface
{
    public interface IHawkerCenterRepository
    {
        /// <summary>
        /// Gets all the hawker centers
        /// </summary>
        /// <returns><see cref="List{Hawker}"/></returns>
        public List<Hawker> GetAllHawkers();

        /// <summary>
        /// Adds the new Hawker Centers in DB
        /// </summary>
        Task InsertHawkerCentersAsync(List<Hawker> hawkersList);
    }
}
