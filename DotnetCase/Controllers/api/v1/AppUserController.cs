using DotnetCase.Business.Interfaces;
using DotnetCase.Business.Models.Requests.AppUser;
using Microsoft.AspNetCore.Mvc;

namespace DotnetCase.API.Controllers.api.v1
{
    [Route("/api/v1/users")]
    public class AppUserController : ControllerBase
    {
        private readonly IAppUserService _appUserService;

        public AppUserController(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }

        /// <summary>
        /// These controller using for creating users.
        /// </summary>
        /// <param name="payload"></param>
        /// <returns></returns>
        [HttpPost("create")]
        public async Task<IActionResult> CreateAsync([FromBody] UserCreateRequest payload)
        {
            var result = await _appUserService.CreateAsync(payload);

            if (!result.Succeeded) return UnprocessableEntity(result);

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
            var result = await _appUserService.GetUserActivitiesAsync(userId);

            if (!result.Success) return UnprocessableEntity(result);

            return Ok(result);
        }

    }
}
