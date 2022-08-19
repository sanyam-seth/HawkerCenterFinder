using HawkerCenterFinder.BL.Interface;
using HawkerCenterFinder.Model.DataContract;
using Microsoft.AspNetCore.Mvc;

namespace HawkerCenterFinder.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class HawkerCenterController : Controller
    {
        private readonly IHawkerCenterManager _hawkerCenterManager;
        private readonly ILogger<HawkerCenterController> _logger;

        public HawkerCenterController(ILogger<HawkerCenterController> logger, IHawkerCenterManager hawkerCenterManager)
        {
            _logger = logger;
            _hawkerCenterManager = hawkerCenterManager;
        }

        [Route("searchclosest")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult SearchClosestHawkers(HawkerSearchRequest searchRequest)
        {
            try
            {
                if (searchRequest == null
                || searchRequest.numberOfClosest <= 0)
                {
                    this._logger.LogError($"Returning BadRequest due to validation Errors");
                    return BadRequest("The search request cannot be null");
                }

                var result = this._hawkerCenterManager.GetNClosestHawkerCenters(searchRequest);
                return Ok(result);
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

        [HttpGet]
        [Route("sync")]
        public IActionResult GetLatestHawkersCenters()
        {
            try
            {
                return Accepted();
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