using DotnetCase.Common.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DotnetCase.Data.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        DbSet<T> Table { get; }

        #region WriteRepository


        Task<RepositoryResult<T>> CreateAsync(T model);
        Task<RepositoryResult<T>> CreateAsync(List<T> datas);

        #endregion

        #region ReadRepository
        IQueryable<T> FindAll(Expression<Func<T, bool>> method, bool onlyActiveMembers = true, bool tracking = true);
        
        #endregion
    }
}
