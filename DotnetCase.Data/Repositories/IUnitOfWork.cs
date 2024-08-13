using DotnetCase.Data.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetCase.Data.Repositories
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        public IAppUserRepository appUserRepository { get; }
        public IActivityRepository activityRepository { get; }
        
    }
}
