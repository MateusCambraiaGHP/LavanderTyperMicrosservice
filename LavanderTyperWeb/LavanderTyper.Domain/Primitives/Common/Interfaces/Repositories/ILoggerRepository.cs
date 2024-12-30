using LavanderTyperWeb.Domain.Primitives.Entities.Loggers;
using System.Linq.Expressions;

namespace LavanderTyperWeb.Domain.Primitives.Common.Interfaces.Repositories
{
    public interface ILoggerRepository
    {
        Task Create(Logger model);
        Task<Logger> Update(Logger model);
        Task<List<Logger>> GetAsync(
            Expression<Func<Logger, bool>> filter,
            Func<IQueryable<Logger>, IOrderedQueryable<Logger>> orderBy,
            params Expression<Func<Logger, object>>[] includes);
    }
}
