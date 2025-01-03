using LTW.Core.DomainObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using IncidentEntity = LTW.Incident.Domain.Primitives.Entities.Incidents.Incident;

namespace LTW.Incident.Infrastructure.Common.Interfaces
{
  public interface IApplicationDbContext
  {
    public DbSet<IncidentEntity> Incident { get; set; }
    public DatabaseFacade Database { get; }
    public Task<int> Save();
    DbSet<TEntity> Set<TEntity>() where TEntity : Entity;
    void SeedData();
  }
}
