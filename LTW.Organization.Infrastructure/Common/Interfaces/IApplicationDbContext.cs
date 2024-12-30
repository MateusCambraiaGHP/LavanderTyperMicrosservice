using LavanderTyperWeb.Core.DomainObjects;
using LavanderTyperWeb.Data.Data;
using LavanderTyperWeb.Domain.Primitives.Entities.Employees;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace LTW.Organization.Infrastructure.Common.Interfaces
{
  public interface IApplicationDbContext
  {
    public DbSet<Employee> Employee { get; set; }
    public DatabaseFacade Database { get; }
    public Task<int> Save();
    DbSet<TEntity> Set<TEntity>() where TEntity : Entity;
    void SeedData();
  }
}
