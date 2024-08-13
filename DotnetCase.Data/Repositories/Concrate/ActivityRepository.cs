using DotnetCase.Data.Contexts;
using DotnetCase.Data.Models;
using DotnetCase.Data.Repositories.Abstract;

namespace DotnetCase.Data.Repositories.Concrate
{

    public class ActivityRepository : Repository<Activity>, IActivityRepository
    {
        public ActivityRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
