using DotnetCase.Common.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetCase.Business.Models.Requests.AppUser
{
    public class UserCreateRequest
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public int? StatusId { get; set; } = RepositoryDefaults.DefaultEntityStatus;
        public string? PhoneNumber { get; set; }
    }
}
