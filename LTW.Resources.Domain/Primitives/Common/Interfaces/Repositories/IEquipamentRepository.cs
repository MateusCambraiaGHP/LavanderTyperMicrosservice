using LTW.Resources.Domain.Primitives.Entities.Equipaments;
using System.Linq.Expressions;

namespace LTW.Resources.Domain.Primitives.Common.Interfaces.Repositories
{
  public interface IEquipamentRepository
  {
    Task Create(Equipament model);
    Task<Equipament> Update(Equipament model);
    Task<List<Equipament>> GetAsync(
        Expression<Func<Equipament, bool>>? filter,
        Func<IQueryable<Equipament>, IOrderedQueryable<Equipament>>? orderBy,
        params Expression<Func<Equipament, object>>[]? includes);
  }
}
