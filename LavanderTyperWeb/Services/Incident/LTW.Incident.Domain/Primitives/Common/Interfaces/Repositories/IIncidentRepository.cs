
using System.Linq.Expressions;
using IncidentEntity = LTW.Incident.Domain.Primitives.Entities.Incidents.Incident;


namespace LTW.Incident.Domain.Primitives.Common.Interfaces.Repositories
{
  public interface IIncidentRepository
  {
    Task Create(IncidentEntity model);
    Task<IncidentEntity> Update(IncidentEntity model);
    Task<List<IncidentEntity>> GetAsync(
        Expression<Func<IncidentEntity, bool>>? filter,
        Func<IQueryable<IncidentEntity>, IOrderedQueryable<IncidentEntity>>? orderBy,
        params Expression<Func<IncidentEntity, object>>[]? includes);
  }
}
