using Swashbuckle.AspNetCore.Annotations;

namespace DotnetCase.Business.Models.Requests.Activity
{
    public class ActivityCreateRequest
    {
        [SwaggerSchema("The type of activity being recorded. Action types and values : UserLogin = 101,UserLogout = 102,PageView = 103,ExecuteOperation = 104")]
        public int ActivityType { get; set; }

        [SwaggerSchema("A detailed description of the activity.")]
        public string? Description { get; set; }

        [SwaggerSchema("The unique identifier of the user who performed the activity.")]
        public Guid UserId { get; set; }
    }
}
