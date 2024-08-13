using DotnetCase.Common.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DotnetCase.Data.Models
{
    public class Activity : BaseEntity
    {
        public int ActivityType { get; set; }
        public string? Description { get; set; }

        [ForeignKey("AppUser")]
        public Guid AppUserId { get; set; }
        [JsonIgnore]
        public virtual AppUser? AppUser { get; set; }
    }
}
