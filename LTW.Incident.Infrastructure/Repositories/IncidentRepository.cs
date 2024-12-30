using LavanderTyperWeb.Domain.Primitives.Common.Interfaces.Repositories;
using LavanderTyperWeb.Domain.Primitives.Entities.Incidents;
using LTW.Incident.Infrastructure.Common.Interfaces;

namespace LTW.Incident.Infrastructure.Repositories
{
  public class IncidentRepository : Repository<Incident>, IIncidentRepository
  {
    public IncidentRepository(IApplicationDbContext context) : base(context) { }
  }
}
