using LTW.Resources.Domain.Primitives.Entities.Vehicles;
using System.Linq.Expressions;

namespace LTW.Resources.Domain.Primitives.Common.Interfaces.Repositories
{
  public interface IVehicleRepository
  {
    Task Create(Vehicle model);
    Task<Vehicle> Update(Vehicle model);
    Task<List<Vehicle>> GetAsync(
        Expression<Func<Vehicle, bool>>? filter,
        Func<IQueryable<Vehicle>, IOrderedQueryable<Vehicle>>? orderBy,
        params Expression<Func<Vehicle, object>>[]? includes);
  }
}
