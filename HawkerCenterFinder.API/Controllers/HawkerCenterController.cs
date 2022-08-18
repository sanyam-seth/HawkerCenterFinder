using HawkerCenterFinder.Model.DataContract;
using Microsoft.AspNetCore.Mvc;

namespace HawkerCenterFinder.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class HawkerCenterController : ControllerBase
    {
        private readonly ILogger<HawkerCenterController> _logger;

        public HawkerCenterController(ILogger<HawkerCenterController> logger)
        {
            _logger = logger;
        }

        [HttpPost(Name = "GetClosestHawkers")]
        public async Task<IActionResult> GetClosestHawkers(HawkerSearchRequest searchRequest)
        {
            try
            {
                if (searchRequest == null)
                {
                    this._logger.LogError($"Returning BadRequest due to validation Errors");
                    return BadRequest("The search request cannot be null");
                }

                return Ok();
            }
            catch (InvalidOperationException e)
            {
                this._logger.LogError(e.Message);
                return StatusCode(400, e.Message);
            }
            catch (Exception e)
            {
                this._logger.LogError(e.Message);
                return StatusCode(500, e.Message);
            }
        }
    }
}