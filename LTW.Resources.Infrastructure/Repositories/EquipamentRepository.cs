using LavanderTyperWeb.Domain.Primitives.Common.Interfaces.Repositories;
using LavanderTyperWeb.Domain.Primitives.Entities.Equipaments;
using LTW.Resources.Infrastructure.Common.Interfaces;

namespace LTW.Resources.Infrastructure.Repositories
{
  public class EquipamentRepository : Repository<Equipament>, IEquipamentRepository
  {
    public EquipamentRepository(IApplicationDbContext context) : base(context) { }
  }
}
