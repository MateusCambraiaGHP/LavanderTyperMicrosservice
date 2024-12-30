using LavanderTyperWeb.Data.Common.Interfaces;
using LavanderTyperWeb.Domain.Primitives.Common.Interfaces.Repositories;
using LavanderTyperWeb.Domain.Primitives.Entities.Vehicles;

namespace LavanderTyperWeb.Data.Repositories
{
    public class VehicleRepository : Repository<Vehicle>, IVehicleRepository
    {
        public VehicleRepository(IApplicationDbContext context) : base(context) { }
    }
}
