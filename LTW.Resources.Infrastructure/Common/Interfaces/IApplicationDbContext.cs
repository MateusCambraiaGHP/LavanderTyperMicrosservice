using LTW.Core.DomainObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace LTW.Resources.Infrastructure.Common.Interfaces
{
  public interface IApplicationDbContext
  {
    public DatabaseFacade Database { get; }
    public Task<int> Save();
    DbSet<TEntity> Set<TEntity>() where TEntity : Entity;
    void SeedData();
  }
}
