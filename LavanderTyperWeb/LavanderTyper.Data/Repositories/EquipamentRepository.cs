using LavanderTyperWeb.Data.Common.Interfaces;
using LavanderTyperWeb.Domain.Primitives.Common.Interfaces.Repositories;
using LavanderTyperWeb.Domain.Primitives.Entities.Equipaments;

namespace LavanderTyperWeb.Data.Repositories
{
    public class EquipamentRepository : Repository<Equipament>, IEquipamentRepository
    {
        public EquipamentRepository(IApplicationDbContext context) : base(context) { }
    }
}
