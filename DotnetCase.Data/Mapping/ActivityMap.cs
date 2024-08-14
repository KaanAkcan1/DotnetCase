using DotnetCase.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotnetCase.Data.Mapping
{
    public class ActivityMap : IEntityTypeConfiguration<Activity>
    {
        public void Configure(EntityTypeBuilder<Activity> builder)
        {
            //Tablolar arasında bağlantılar gerekli olduğu durumlar için ekledim. Db'de tablolar arasındaki bağımlılıklar pek önerilmiyor araştırmalarımda, yapmak da istemezdim. Ancak taskte istenilen bu bilgiyse diye ekledim.
            builder.HasOne<AppUser>(x => x.AppUser).WithMany(b => b.Activities).HasForeignKey(a => a.AppUserId).OnDelete(DeleteBehavior.NoAction);

            builder.HasIndex(x => x.AppUserId);
            builder.HasIndex(x => x.CreatedOn);
            builder.HasIndex(x => x.ActivityType);

            builder.ToTable("Activities");
        }

    }
}
