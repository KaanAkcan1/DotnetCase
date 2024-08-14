using DotnetCase.Business.Interfaces;
using DotnetCase.Business.Models.Requests.AppUser;
using DotnetCase.Common.Entities.Common;
using DotnetCase.Common.Enums.Common;
using DotnetCase.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DotnetCase.Business.Services
{
    public class AppUserService : IAppUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IActivityService _activityService;

        public AppUserService(UserManager<AppUser> userManager, IActivityService activityService)
        {
            _activityService = activityService;
            _userManager = userManager;
        }

        /// <summary>
        /// A service used to record users.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<IdentityResult> CreateAsync(UserCreateRequest request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            var user = new AppUser();

            var validationResult = await ValidateBeforeCreateAsync(request);

            if (!validationResult.Succeeded) return validationResult;

            user.StatusId = request.StatusId == null
                ? RepositoryDefaults.DefaultEntityStatus
                : request.StatusId.Value;

            user.Email = request.Email;
            user.UserName = request.Name;
            user.PhoneNumber = request.PhoneNumber;
            user.ModifiedOn = DateTime.UtcNow;
            user.CreatedOn = DateTime.UtcNow;
            user.Id = Guid.NewGuid();
            user.PhoneNumberConfirmed = true;
            user.EmailConfirmed = true;

            var createUserResult = await _userManager.CreateAsync(user);

            if (!createUserResult.Succeeded) return createUserResult;

            return IdentityResult.Success;

        }


        /// <summary>
        /// A service that validates the request before starting the operations.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        private async Task<IdentityResult> ValidateBeforeCreateAsync(UserCreateRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Email?.Trim() ?? ""))
            {
                return IdentityResult.Failed(new IdentityError()
                {
                    Description = "E-posta adresi zorunludur"
                });
            }

            if (!string.IsNullOrWhiteSpace(request.Email))
            {
                if (await _userManager.Users.AnyAsync(x => x.Email == request.Email && x.StatusId != (int)EntityStatus.Deleted))
                {
                    return IdentityResult.Failed(new IdentityError()
                    {
                        Description =
                            "Aynı e-posta adresi ile kayıtlı başka bir kullanıcı kayıdı daha var. Kontrol edip tekrar deneyiniz."
                    });
                }
            }

            return IdentityResult.Success;
        }


        /// <summary>
        /// A service that retrieves activities based on a specific user ID.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<DataResponse<List<Activity>>> GetUserActivitiesAsync(string request)
        {
            var result = new DataResponse<List<Activity>>();

            var user = await _userManager.FindByIdAsync(request);

            if (user == null)
            {
                result.SetError("User doesn't exist");

                return result;
            }

            var activitiesServiceResult = _activityService.GetActivitiesFromUserId(Guid.Parse(request));

            if (!activitiesServiceResult.Success)
            {
                result.SetRecordCouldNotFound();

                return result;
            }

            result.SetSuccessList(activitiesServiceResult.Data);

            return result;
        }
    }
}
