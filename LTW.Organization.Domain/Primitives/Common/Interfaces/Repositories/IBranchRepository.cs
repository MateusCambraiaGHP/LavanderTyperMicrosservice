using LavanderTyperWeb.Domain.Primitives.Entities.Branchs;
using System.Linq.Expressions;

namespace LavanderTyperWeb.Domain.Primitives.Common.Interfaces.Repositories
{
    public interface IBranchRepository
    {
        Task Create(Branch model);
        Task<Branch> Update(Branch model);
        Task<List<Branch>> GetAsync(
            Expression<Func<Branch, bool>>? filter,
            Func<IQueryable<Branch>, IOrderedQueryable<Branch>>? orderBy,
            params Expression<Func<Branch, object>>[]? includes);
    }
}
