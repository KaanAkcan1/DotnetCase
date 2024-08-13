using DotnetCase.Business.Interfaces;
using DotnetCase.Business.Models.Requests.Activity;
using Microsoft.AspNetCore.Mvc;

namespace DotnetCase.API.Controllers.api.v1
{
    [Route("/api/v1/activities")]
    public class ActivityController : ControllerBase
    {
        private readonly IActivityService _activityService;

        public ActivityController(IActivityService activityService)
        {
            _activityService = activityService;
        }

        /// <summary>
        /// This controller using for creating activity.
        /// </summary>
        /// <param name="payload"></param>
        /// <returns></returns>
        [HttpPost()]
        public async Task<IActionResult> CreateAsync([FromBody] ActivityCreateRequest payload)
        {
            var result = await _activityService.CreateAsync(payload);

            if (!result.Success) return UnprocessableEntity(result);

            return Ok(result);
        }

        /// <summary>
        /// This controller is used to retrieve activities either with or without filtering
        /// </summary>
        /// <param name="payload"></param>
        /// <returns></returns>
        [HttpGet()]
        public IActionResult FindAll([FromQuery]ActivityFilterRequest payload)
        {
            var result = _activityService.FindAll(payload);

            if (!result.Success) return UnprocessableEntity(result);

            return Ok(result);
        }

    }
}
