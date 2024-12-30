using LavanderTyperWeb.Domain.Primitives.Common.Interfaces.Repositories;
using LavanderTyperWeb.Domain.Primitives.Entities.Vehicles;
using LTW.Resources.Infrastructure.Common.Interfaces;

namespace LTW.Resources.Infrastructure.Repositories
{
  public class VehicleRepository : Repository<Vehicle>, IVehicleRepository
  {
    public VehicleRepository(IApplicationDbContext context) : base(context) { }
  }
}
