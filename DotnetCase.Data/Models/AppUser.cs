using DotnetCase.Common.Enums.Common;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetCase.Data.Models
{
    public class AppUser : IdentityUser<Guid>
    {
        public int StatusId { get; set; } = (int)EntityStatus.Active;
        [NotMapped]
        public string? StatusText { get; set; }
        public Guid ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }

        public virtual ICollection<Activity>? Activities { get; set; }
    }
}
