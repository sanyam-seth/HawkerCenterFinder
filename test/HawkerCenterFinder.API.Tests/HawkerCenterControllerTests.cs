using HawkerCenterFinder.API.Controllers;
using HawkerCenterFinder.BL.Helpers;
using HawkerCenterFinder.BL.Interface;
using HawkerCenterFinder.BL.Tests.Data;
using HawkerCenterFinder.Controllers;
using HawkerCenterFinder.Model.DataContract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;

namespace HawkerCenterFinder.API.Tests
{
    [TestClass]
    public class HawkerCenterControllerTests
    {
        private Mock<IHawkerCenterManager> _hawkerCenterManagerMock;
        private Mock<ILogger> _loggerMock;

        [TestInitialize]
        public void BeforeEach()
        {
            this._hawkerCenterManagerMock = new Mock<IHawkerCenterManager>();
            this._loggerMock = new Mock<ILogger>();
        }

        /// <summary>
        /// Test the N closest hawkers with a valid input
        /// </summary>
        [TestMethod]
        public void GetNClosestHawkerCenters_ValidInput()
        {
            HawkerSearchRequest searchRequest = new HawkerSearchRequest
            {
                latitude = 103.915761950557,
                longitude = 1.30577514781108,
                numberOfClosest = 5
            };
            this._hawkerCenterManagerMock.Setup(a => a.GetNClosestHawkerCenters(searchRequest)).Returns(MockData.mockHawkerResponseData);
            var hawkerCenterController = new HawkerCenterController(this._loggerMock.Object, this._hawkerCenterManagerMock.Object);
            IActionResult result = hawkerCenterController.SearchClosestHawkers(searchRequest);
            this._hawkerCenterManagerMock.Verify(a => a.GetNClosestHawkerCenters(searchRequest), Times.Exactly(1));

            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult.Value);

        }

        /// <summary>
        /// Test with a non valid input for getting an non exisiting User 
        /// </summary>
        [TestMethod]
        public void GetNClosestHawkerCenters_InvalidInput()
        {
            HawkerSearchRequest searchRequest = new HawkerSearchRequest
            {
                latitude = 103.915761950557,
                longitude = 1.30577514781108,
                numberOfClosest = 0
            };
            this._hawkerCenterManagerMock.Setup(a => a.GetNClosestHawkerCenters(searchRequest)).Returns(MockData.mockHawkerResponseData);
            var hawkerCenterController = new HawkerCenterController(this._loggerMock.Object, this._hawkerCenterManagerMock.Object);
            IActionResult result = hawkerCenterController.SearchClosestHawkers(searchRequest);
            var badRequestObjectResult = result as BadRequestObjectResult;
            Assert.AreEqual(badRequestObjectResult.Value, "The search request cannot be null or number of closest cannot be less than equal to zero");
        }
    }
}