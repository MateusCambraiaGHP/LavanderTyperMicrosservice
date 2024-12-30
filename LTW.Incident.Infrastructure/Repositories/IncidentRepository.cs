using LavanderTyperWeb.Data.Common.Interfaces;
using LavanderTyperWeb.Domain.Primitives.Common.Interfaces.Repositories;
using LavanderTyperWeb.Domain.Primitives.Entities.Incidents;

namespace LavanderTyperWeb.Data.Repositories
{
    public class IncidentRepository : Repository<Incident>, IIncidentRepository
    {
        public IncidentRepository(IApplicationDbContext context) : base(context) { }
    }
}
