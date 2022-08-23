using HawkerCenterFinder.API.Controllers;
using HawkerCenterFinder.BL.Helpers;
using HawkerCenterFinder.BL.Interface;
using HawkerCenterFinder.Model.DataContract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Moq;

namespace HawkerCenterFinder.API.Tests
{
    [TestClass]
    public class AuthenticationControllerTests
    {
        private Mock<ICredentialManager> _credentialManagerMock;
        private Mock<IConfiguration> _configurationMock;
        private readonly string mockUserName = "testUserName";
        private readonly string mockUserPassword = "testUserName";


        [TestInitialize]
        public void BeforeEach()
        {
            this._credentialManagerMock = new Mock<ICredentialManager>();
            this._configurationMock = new Mock<IConfiguration>();
        }

        /// <summary>
        /// Test the login for getting an existing User 
        /// </summary>
        [TestMethod]
        public async Task Login_ValidUserAsync()
        {
            this._credentialManagerMock.Setup(a => a.ValidateUserCredentials(mockUserName, AuthenticationHelper.ComputePasswordHash(mockUserPassword))).ReturnsAsync(true);
            var authenticateController = new AuthenticationController(this._credentialManagerMock.Object, this._configurationMock.Object);
            IActionResult result = await authenticateController.Login(new UserLogin { Username = mockUserName, Password = mockUserPassword });
            this._credentialManagerMock.Verify(a => a.ValidateUserCredentials(mockUserName, AuthenticationHelper.ComputePasswordHash(mockUserPassword)), Times.Exactly(1));

            var okResult = result as OkObjectResult;
            Assert.IsNotNull(result);

        }

        /// <summary>
        /// Test the login for getting an non exisiting User 
        /// </summary>
        [TestMethod]
        public async Task Login_InvalidUserAsync()
        {
            var authenticateController = new AuthenticationController(this._credentialManagerMock.Object, this._configurationMock.Object);
            IActionResult result = await authenticateController.Login(new UserLogin { Username = mockUserName, Password = mockUserPassword });
            this._credentialManagerMock.Verify(a => a.ValidateUserCredentials(mockUserName, AuthenticationHelper.ComputePasswordHash(mockUserPassword)), Times.Exactly(1));
            var unauthorizedResult = result as UnauthorizedObjectResult;
            Assert.AreEqual(unauthorizedResult.Value, "Username and Password does not match our records");
        }
    }
}