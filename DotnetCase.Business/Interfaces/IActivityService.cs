using DotnetCase.Business.Models.Requests.Activity;
using DotnetCase.Common.Entities.Common;
using DotnetCase.Data.Models;

namespace DotnetCase.Business.Interfaces
{
    public interface IActivityService
    {
        Task<DataResponse<Activity>> CreateAsync(ActivityCreateRequest request);

        DataResponse<List<Activity>> GetActivitiesFromUserId(Guid request);

        DataResponse<List<Activity>> FindAll(ActivityFilterRequest request);
    }
}
