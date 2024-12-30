using LavanderTyperWeb.Domain.Primitives.Entities.Companies;
using System.Linq.Expressions;

namespace LavanderTyperWeb.Domain.Primitives.Common.Interfaces.Repositories
{
    public interface ICompanyRepository
    {
        Task Create(Company model);
        Task<Company> Update(Company model);
        Task<List<Company>> GetAsync(
            Expression<Func<Company, bool>>? filter,
            Func<IQueryable<Company>, IOrderedQueryable<Company>>? orderBy,
            params Expression<Func<Company, object>>[]? includes);
    }
}
