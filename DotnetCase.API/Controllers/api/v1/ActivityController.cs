using Azure.Core;
using DotnetCase.Business.Interfaces;
using DotnetCase.Business.Models.Requests.Activity;
using Microsoft.AspNetCore.Mvc;

namespace DotnetCase.API.Controllers.api.v1
{
    [Route("/api/v1/activities")]
    public class ActivityController : ControllerBase
    {
        private readonly ILogger<ActivityController> _logger;
        private readonly IActivityService _activityService;

        public ActivityController(IActivityService activityService, ILogger<ActivityController> logger)
        {
            _activityService = activityService;
            _logger = logger;
        }

        /// <summary>
        /// This controller using for creating activity.
        /// </summary>
        /// <param name="payload"></param>
        /// <returns></returns>
        [HttpPost()]
        public async Task<IActionResult> CreateAsync([FromBody] ActivityCreateRequest request)
        {
            _logger.LogInformation("ActivityController-CreateAsync request worked: {request}", request);

            var result = await _activityService.CreateAsync(request);

            if (!result.Success)
            {
                _logger.LogError("This is an error at CreateAsync Service : {message}", result.Message);

                return UnprocessableEntity(result);
            }

            _logger.LogInformation("CreateAsync Service operation was successfully completed.");

            return Ok(result);
        }

        /// <summary>
        /// This controller is used to retrieve activities either with or without filtering
        /// </summary>
        /// <param name="payload"></param>
        /// <returns></returns>
        [HttpGet()]
        public IActionResult FindAll([FromQuery]ActivityFilterRequest request)
        {
            _logger.LogInformation("ActivityController-FindAll request worked: {request}", request);

            var result = _activityService.FindAll(request);

            if (!result.Success)
            {
                _logger.LogError("This is an error at FindAll Service : {message}", result.Message);

                return UnprocessableEntity(result);
            }

            _logger.LogInformation("FindAll Service operation was successfully completed.");

            return Ok(result);
        }

    }
}
