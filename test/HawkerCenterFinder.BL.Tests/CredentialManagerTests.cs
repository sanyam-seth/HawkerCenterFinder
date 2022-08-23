using HawkerCenterFinder.BL.Business;
using HawkerCenterFinder.DataLayer.Interface;
using Moq;
using System.Reflection;

namespace HawkerCenterFinder.BL.Tests
{
    [TestClass]
    public class CredentialManagerTests
    {
        private Mock<IUserCredentialRepository> _userLoginRepository;
        private readonly string mockUserUsername = "UserName";
        private readonly string mockNonExisitingUserUsername = "nonExisitngUserName";
        private readonly string mockPassword = "testmanagerName";


        [TestInitialize]
        public void BeforeEach()
        {
            this._userLoginRepository = new Mock<IUserCredentialRepository>();
        }

        /// <summary>
        /// Test for validating an existing user credentials 
        /// </summary>
        [TestMethod]
        public async Task ValidateUserCredentials_ValidUser()
        {
            this._userLoginRepository.Setup(a => a.GetUserCredentialsAsync(mockUserUsername)).ReturnsAsync(new Model.UserCredentials(mockUserUsername, mockPassword));
            var userCredentialManager = new CredentialManager(this._userLoginRepository.Object);
            bool actualResult = await userCredentialManager.ValidateUserCredentials(mockUserUsername, mockPassword);
            this._userLoginRepository.Verify(a => a.GetUserCredentialsAsync(mockUserUsername), Times.Exactly(1));
            Assert.IsTrue(actualResult);

        }

        /// <summary>
        /// Test for validating an existing user credentials 
        /// </summary>
        [TestMethod]
        public async Task ValidateUserCredentials_InvalidUser()
        {
            this._userLoginRepository.Setup(a => a.GetUserCredentialsAsync(mockUserUsername)).ReturnsAsync(new Model.UserCredentials(mockUserUsername, mockPassword));
            var userCredentialManager = new CredentialManager(this._userLoginRepository.Object);
            bool actualResult = await userCredentialManager.ValidateUserCredentials(mockNonExisitingUserUsername, mockPassword);
            this._userLoginRepository.Verify(a => a.GetUserCredentialsAsync(mockUserUsername), Times.Exactly(0));
            Assert.IsFalse(actualResult);
        }
    }
}