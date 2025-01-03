using LTW.Core.DomainObjects;
using System.Linq.Expressions;

namespace LTW.Core.Data
{
  public interface IRepository<TEntity> where TEntity : Entity
  {
    Task Create(TEntity entityModel);
    Task<TEntity> Update(TEntity entityModel);
    Task<List<TEntity>> GetAsync(
        Expression<Func<TEntity, bool>> filter,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy,
        params Expression<Func<TEntity, object>>[] includes);
  }
}
