using DotnetCase.Data.Contexts;
using DotnetCase.Data.Repositories.Abstract;
using DotnetCase.Data.Repositories.Concrate;

namespace DotnetCase.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _context;
        private IAppUserRepository _appUserRepository;
        private IActivityRepository _activityRepository;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }
        public IAppUserRepository appUserRepository => _appUserRepository ?? new AppUserRepository();
        public IActivityRepository activityRepository => _activityRepository ?? new ActivityRepository(_context);


        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
