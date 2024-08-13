using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetCase.Common.Entities.Common
{
    public class BaseEntity
    {
        [Column(Order = 201)]
        public Guid Id { get; set; }
        [Column(Order = 202)]
        public int StatusId { get; set; }
        [Column(Order = 203)]
        public DateTime CreatedOn { get; set; }
        [Column(Order = 205)]
        public DateTime ModifiedOn { get; set; }
        [Column(Order = 204)]
        public Guid CreatedBy { get; set; }
        [Column(Order = 206)]
        public Guid ModifiedBy { get; set; }
    }
}
