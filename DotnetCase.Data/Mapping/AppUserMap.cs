using DotnetCase.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotnetCase.Data.Mapping
{
    public class AppUserMap : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            //builder.HasMany<Activity>(u => u.Activities).WithOne(a => a.AppUser).HasForeignKey(a => a.AppUserId).OnDelete(DeleteBehavior.NoAction);

            builder.HasIndex(a => a.Id);
            
            builder.ToTable("AppUsers");
        }
    }
}
