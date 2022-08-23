using HawkerCenterFinder.BL.Business;
using HawkerCenterFinder.BL.Tests.Data;
using HawkerCenterFinder.DataLayer.Interface;
using HawkerCenterFinder.Model;
using HawkerCenterFinder.Model.DataContract;
using Moq;
using System.Reflection;

namespace HawkerCenterFinder.BL.Tests
{
    [TestClass]
    public class HawkerCenterManagerTests
    {
        private Mock<IHawkerCenterRepository> _hawkerCenterRepository;

        [TestInitialize]
        public void BeforeEach()
        {
            this._hawkerCenterRepository = new Mock<IHawkerCenterRepository>();
        }

        /// <summary>
        /// Test for valid search request for existing hawker centers 
        /// </summary>
        [TestMethod]
        public async Task GetNClosestHawkers_ValidInput()
        {
            HawkerSearchRequest searchRequest = new HawkerSearchRequest
            {
                latitude = 103.915761950557,
                longitude = 1.30577514781108,
                numberOfClosest = 1
            };
            this._hawkerCenterRepository.Setup(a => a.GetAllHawkers()).Returns(MockData.mockHawkersData);
            var hawkerCenterManager = new HawkerCenterManager(this._hawkerCenterRepository.Object);
            List<HawkerCenterResponse> actualResult = hawkerCenterManager.GetNClosestHawkerCenters(searchRequest);
            this._hawkerCenterRepository.Verify(a => a.GetAllHawkers(), Times.Exactly(1));
            Hawker expectedHawker = MockData.mockHawkersData.Where(x => x.Id == 5).FirstOrDefault();
            Assert.AreEqual(expectedHawker.Name, actualResult.FirstOrDefault().Name);
            Assert.AreEqual(expectedHawker.ImgUrl, actualResult.FirstOrDefault().ImgUrl);
        }

        /// <summary>
        /// Test for invalid search request for existing hawker centers 
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task GetNClosestHawkers_InvalidInput()
        {
            this._hawkerCenterRepository.Setup(a => a.GetAllHawkers()).Returns(MockData.mockHawkersData);
            var hawkerCenterManager = new HawkerCenterManager(this._hawkerCenterRepository.Object);
            List<HawkerCenterResponse> actualResult = hawkerCenterManager.GetNClosestHawkerCenters(null);
            this._hawkerCenterRepository.Verify(a => a.GetAllHawkers(), Times.Exactly(1));
        }
    }
}