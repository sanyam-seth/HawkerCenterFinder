using HawkerCenterFinder.BL.Interface;
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
            try
            {
                List<Hawker> hawkers = _hawkerCenterRepository.GetAllHawkers();

                hawkers = hawkers
                    .OrderBy(x => GetDistance(searchRequest.latitude, searchRequest.longitude, double.Parse(x.Latitude), double.Parse(x.Longitude)))
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
            var fileHawkerData = HawkerCenterParser.GetDataFromFile();
            var parsedHawkerData = HawkerCenterParser.ParseHawkerDataToHawker(fileHawkerData);


            return await Task.FromResult(true);
        }



        private double GetDistance(double longitude, double latitude, double otherLongitude, double otherLatitude)
        {
            var d1 = latitude * (Math.PI / 180.0);
            var num1 = longitude * (Math.PI / 180.0);
            var d2 = otherLatitude * (Math.PI / 180.0);
            var num2 = otherLongitude * (Math.PI / 180.0) - num1;
            var d3 = Math.Pow(Math.Sin((d2 - d1) / 2.0), 2.0) + Math.Cos(d1) * Math.Cos(d2) * Math.Pow(Math.Sin(num2 / 2.0), 2.0);

            return 6376500.0 * (2.0 * Math.Atan2(Math.Sqrt(d3), Math.Sqrt(1.0 - d3)));
        }

    }
}
