using LavanderTyperWeb.Domain.Primitives.Entities.Incidents;
using System.Linq.Expressions;

namespace LavanderTyperWeb.Domain.Primitives.Common.Interfaces.Repositories
{
    public interface IIncidentRepository
    {
        Task Create(Incident model);
        Task<Incident> Update(Incident model);
        Task<List<Incident>> GetAsync(
            Expression<Func<Incident, bool>>? filter,
            Func<IQueryable<Incident>, IOrderedQueryable<Incident>>? orderBy,
            params Expression<Func<Incident, object>>[]? includes);
    }
}
