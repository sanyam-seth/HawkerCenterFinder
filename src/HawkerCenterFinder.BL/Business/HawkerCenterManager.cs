using HawkerCenterFinder.BL.Helpers;
using HawkerCenterFinder.BL.Interface;
using HawkerCenterFinder.BL.Parser;
using HawkerCenterFinder.DataLayer.Interface;
using HawkerCenterFinder.DataLayer.Parser;
using HawkerCenterFinder.Model;
using HawkerCenterFinder.Model.DataContract;

namespace HawkerCenterFinder.BL.Business
{
    public class HawkerCenterManager : IHawkerCenterManager
    {
        public readonly IHawkerCenterRepository _hawkerCenterRepository;

        public HawkerCenterManager(IHawkerCenterRepository hawkerCenterRepository)
        {
            _hawkerCenterRepository = hawkerCenterRepository;
        }

        /// <summary>
        /// Gets the N closest hawker centers based on the search request 
        /// </summary>
        /// <param name="searchRequest">Params for the search request</param>
        /// <returns><see cref="Task{HawkerCenterResponse}"/>Data for the hawker Centers</returns>
        public List<HawkerCenterResponse> GetNClosestHawkerCenters(HawkerSearchRequest searchRequest)
        {
            if (searchRequest == null)
                throw new ArgumentNullException(nameof(searchRequest));
            if (searchRequest.numberOfClosest <= 0)
            {
                throw new ArgumentOutOfRangeException("Number of closest cannot be less than equal to zero");
            }
            try
            {
                List<Hawker> hawkers = _hawkerCenterRepository.GetAllHawkers();

                hawkers = hawkers
                    .OrderBy(x => MetricsHelper.GetDistance(searchRequest.latitude, searchRequest.longitude, double.Parse(x.Latitude), double.Parse(x.Longitude)))
                    .Take(searchRequest.numberOfClosest)
                    .ToList();

                return hawkers.Select(x => new HawkerCenterResponse { ImgUrl = x.ImgUrl, Name = x.Name }).ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Updates the data in DB from file  
        /// </summary>
        /// <returns><see cref="bool"/>Indicating success/failure</returns>
        public async Task<bool> UpdateHawkerCenterData()
        {
            try
            {
                var fileHawkerData = HawkerCenterClient.GetDataFromFile();
                var parsedHawkerData = HawkerDataHTMLParser.ParseHawkerDataToHawker(fileHawkerData);

                var exisitngHawkerData = this._hawkerCenterRepository.GetAllHawkers();
                var newHawkerData = parsedHawkerData.Where(y => !exisitngHawkerData.Any(z => z.Name == y.Name
                && z.ImgUrl == y.ImgUrl
                && z.Latitude == y.Latitude
                && y.Longitude == y.Longitude)).ToList();

                await this._hawkerCenterRepository.InsertHawkerCentersAsync(newHawkerData);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
