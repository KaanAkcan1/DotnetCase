using DotnetCase.Business.Interfaces;
using DotnetCase.Business.Models.Requests.Activity;
using DotnetCase.Business.Strategies;
using DotnetCase.Common.Core;
using DotnetCase.Common.Entities.Common;
using DotnetCase.Common.Enums.App;
using DotnetCase.Data.Models;
using DotnetCase.Data.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System.Linq.Expressions;

namespace DotnetCase.Business.Services
{
    public class ActivityService : IActivityService
    {
        private readonly IUnitOfWork _unitOfWorkRepository;
        private readonly UserManager<AppUser> _userManager;
        private readonly IServiceProvider _serviceProvider;

        public ActivityService(IUnitOfWork unitOfWorkRepository, UserManager<AppUser> userManager, IServiceProvider serviceProvider)
        {
            _unitOfWorkRepository = unitOfWorkRepository;
            _userManager = userManager;
            _serviceProvider = serviceProvider;
        }


        public async Task<DataResponse<Activity>> CreateAsync(ActivityCreateRequest request)
        {
            var result = new DataResponse<Activity>();

            var validationResult = await ValidateBeforeCreate(request);

            if (!validationResult.Success)
            {
                result.SetError(validationResult.Message);

                return result;
            }

            var activity = new Activity()
            {
                Id = Guid.NewGuid(),
                CreatedBy = RepositoryDefaults.UserId.Anonymous,
                ModifiedBy = RepositoryDefaults.UserId.Anonymous,
                Description = request.Description,
                ActivityType = request.ActivityType,
                AppUserId = request.UserId,
                AppUser = await _userManager.FindByIdAsync(request.UserId.ToString())
            };

            IActivityStrategy strategy = activity.ActivityType switch
            {
                (int)ActivityTypes.UserLogin => _serviceProvider.GetService<UserLoginActivityStrategy>(),
                (int)ActivityTypes.UserLogout => _serviceProvider.GetService<UserLogoutActivityStrategy>(),
                (int)ActivityTypes.PageView => _serviceProvider.GetService<PageViewActivityStrategy>(),
                (int)ActivityTypes.ExecuteOperation => _serviceProvider.GetService<ExecuteOperationActivityStrategy>(),
                _ => throw new ArgumentException("Invalid activity type", nameof(activity.ActivityType))
            };

            var context = new ActivityContext(strategy);
            context.ApplyStrategy(activity);

            var repositoryResult = await _unitOfWorkRepository.activityRepository.CreateAsync(activity);

            if (!repositoryResult.Success)
            {
                result.SetErrorCreate();

                return result;
            }

            result.SetSuccesCreate(activity);

            return result;
        }

        private async Task<Response> ValidateBeforeCreate(ActivityCreateRequest request)
        {
            var result = new Response();

            if (!Enum.IsDefined(typeof(ActivityTypes), request.ActivityType))
            {
                result.SetError("No suitable value found for the given value of ActivityType");

                return result;
            }

            var user = await _userManager.FindByIdAsync(request.UserId.ToString());

            if (user == null)
            {
                result.SetError("No suitable user found for the given value of UserId");

                return result;
            }

            result.SetSuccess();

            return result;
        }

        public DataResponse<List<Activity>> GetActivitiesFromUserId(Guid request)
        {
            var result = new DataResponse<List<Activity>>();

            var activities = _unitOfWorkRepository.activityRepository.FindAll(x => x.AppUserId == request);

            result.SetRecordFounded(activities == null ? new List<Activity>() : activities.ToList());

            return result;
        }

        public DataResponse<List<Activity>> FindAll(ActivityFilterRequest request)
        {
            var result = new DataResponse<List<Activity>>();

            Expression<Func<Activity, bool>> exp = x => x.StatusId == 1;

            if (request != null && request.LaterThan != null)
            {
                var successLt = DateTime.TryParse(request.LaterThan, out DateTime timeLt);

                if (successLt)
                    exp = exp.And(x => x.CreatedOn >= timeLt);
            }
            if (request != null && request.EarlierThan != null)
            {
                var successEt = DateTime.TryParse(request.EarlierThan, out DateTime timeEt);

                if (successEt)
                    exp = exp.And(x => x.CreatedOn <= timeEt);
            }
            if (request != null && request.UserId != null)
            {
                var successId = Guid.TryParse(request.UserId, out Guid id);

                if (successId)
                    exp = exp.And(x => x.AppUserId == id);
            }
            if (request != null && request.ActivityType != null)
            {
                var success = int.TryParse(request.ActivityType, out int activityType) && Enum.IsDefined(typeof(ActivityTypes), activityType);

                if (success)
                    exp = exp.And(x => x.ActivityType == activityType);
            }

            var activities = _unitOfWorkRepository.activityRepository.FindAll(exp);

            result.SetRecordFounded(activities == null ? new List<Activity>() : activities.ToList());

            return result;
        }
    }
}
