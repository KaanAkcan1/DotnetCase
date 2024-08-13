using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetCase.Business.Models.Requests.Activity
{
    public class ActivityCreateRequest
    {
        public int ActivityType { get; set; }
        public string? Description { get; set; }
        public Guid UserId { get; set; }
    }
}
