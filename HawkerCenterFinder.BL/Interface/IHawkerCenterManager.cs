using HawkerCenterFinder.Model.DataContract;

namespace HawkerCenterFinder.BL.Interface
{
    public interface IHawkerCenterManager
    {
        /// <summary>
        /// Gets the N closest hawker centers based on the search request 
        /// </summary>
        /// <param name="searchRequest">Params for the search request</param>
        /// <returns><see cref="Task{HawkerCenterResponse}"/>Data for the hawker Centers</returns>
        List<HawkerCenterResponse> GetNClosestHawkerCenters(HawkerSearchRequest searchRequest);
        
        /// <summary>
        /// Updates the data in DB from file  
        /// </summary>
        /// <returns><see cref="bool"/>Indicating success/failure</returns>
        Task<bool> UpdateHawkerCenterData();
    }
}
