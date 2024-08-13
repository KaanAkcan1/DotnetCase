using DotnetCase.Business.Interfaces;
using DotnetCase.Business.Models.Requests.AppUser;
using Microsoft.AspNetCore.Mvc;

namespace DotnetCase.API.Controllers.api.v1
{
    [Route("/api/v1/users")]
    public class AppUserController : ControllerBase
    {
        private readonly ILogger<ActivityController> _logger;
        private readonly IAppUserService _appUserService;

        public AppUserController(IAppUserService appUserService, ILogger<ActivityController> logger)
        {
            _appUserService = appUserService;
            _logger = logger;
        }

        /// <summary>
        /// These controller using for creating users.
        /// </summary>
        /// <param name="payload"></param>
        /// <returns></returns>
        [HttpPost("create")]
        public async Task<IActionResult> CreateAsync([FromBody] UserCreateRequest payload)
        {
            _logger.LogInformation("AppUserController-CreateAsync request worked: {payload}", payload);

            var result = await _appUserService.CreateAsync(payload);

            if (!result.Succeeded)
            {
                _logger.LogError("This is an error at CreateAsync Service");

                return UnprocessableEntity(result);
            }

            _logger.LogInformation("CreateAsync Service operation was successfully completed.");

            return Ok(result);
        }
        /// <summary>
        /// These controllers are used to list a user's activities.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>

        [HttpGet("{userId}/activities")]
        public async Task<IActionResult> GetUserActivitiesAsync(string userId)
        {
            _logger.LogInformation("AppUserController-GetUserActivitiesAsync request worked: {payload}", userId);

            var result = await _appUserService.GetUserActivitiesAsync(userId);

            if (!result.Success)
            {
                _logger.LogError("This is an error at GetUserActivitiesAsync Service : {message}", result.Message);

                return UnprocessableEntity(result);
            }

            _logger.LogInformation("GetUserActivitiesAsync Service operation was successfully completed.");

            return Ok(result);
        }

    }
}
