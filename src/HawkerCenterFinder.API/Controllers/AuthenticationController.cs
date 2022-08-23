using HawkerCenterFinder.BL.Helpers;
using HawkerCenterFinder.BL.Interface;
using HawkerCenterFinder.Model.DataContract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace HawkerCenterFinder.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AuthenticationController : Controller
    {
        private readonly ICredentialManager _credentialManager;

        private readonly IConfiguration _configuration;

        public AuthenticationController(ICredentialManager userHierarchyManager, IConfiguration configuration)
        {
            _credentialManager = userHierarchyManager;
            _configuration = configuration;
        }

        /// <summary>
        /// Login API For users
        /// </summary>
        /// <param name="model"/> User Login Model</param>
        /// <returns><see cref="IActionResult"/> Authenticated Result</returns>
        [AllowAnonymous]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] UserLogin model)
        {
            try
            {
                if (model == null)
                {
                    throw new ArgumentNullException(nameof(model));
                }

                bool isUserValidated = await _credentialManager.ValidateUserCredentials(model.Username, AuthenticationHelper.ComputePasswordHash(model.Password));
                if (isUserValidated)
                {
                    JwtSecurityToken tokenString = AuthenticationHelper.GenerateJSONWebToken(model.Username, _configuration);
                    return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(tokenString), expiration = tokenString.ValidTo });
                }
                else
                {
                    return Unauthorized("Username and Password does not match our records");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
