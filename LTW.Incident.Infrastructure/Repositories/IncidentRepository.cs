using LTW.Incident.Domain.Primitives.Common.Interfaces.Repositories;
using LTW.Incident.Infrastructure.Common.Interfaces;
using IncidentEntity = LTW.Incident.Domain.Primitives.Entities.Incidents.Incident;

namespace LTW.Incident.Infrastructure.Repositories
{
  public class IncidentRepository : Repository<IncidentEntity>, IIncidentRepository
  {
    public IncidentRepository(IApplicationDbContext context) : base(context) { }
  }
}
