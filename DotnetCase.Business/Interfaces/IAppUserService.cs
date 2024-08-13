using DotnetCase.Business.Models.Requests.AppUser;
using DotnetCase.Common.Entities.Common;
using DotnetCase.Data.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetCase.Business.Interfaces
{
    public interface IAppUserService
    {
        Task<IdentityResult> CreateAsync(UserCreateRequest request);

        Task<DataResponse<List<Activity>>> GetUserActivitiesAsync(string request);
    }
}
