namespace DotnetCase.Business.Models.Requests.Activity
{
    public class ActivityFilterRequest
    {
        public string? EarlierThan { get; set; }
        public string? LaterThan { get; set; }
        public string? UserId { get; set; }
        public string? ActivityType { get; set; }
    }

}
