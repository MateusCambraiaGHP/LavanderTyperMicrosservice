using LavanderTyperWeb.Core.Communication.Mediator.Interfaces;
using LavanderTyperWeb.Core.Data;
using LavanderTyperWeb.Core.DomainObjects;
using LavanderTyperWeb.Core.Messages.CommonMessages;
using LavanderTyperWeb.Domain.Primitives.Entities.Branchs;
using LavanderTyperWeb.Domain.Primitives.Entities.Companies;
using LavanderTyperWeb.Domain.Primitives.Entities.Employees;
using LavanderTyperWeb.Domain.Primitives.Entities.Equipaments;
using LavanderTyperWeb.Domain.Primitives.Entities.Incidents;
using LavanderTyperWeb.Domain.Primitives.Entities.Vehicles;
using LTW.Resources.Infrastructure.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;

namespace LTW.Resources.Infrastructure.Data
{
  public class ApplicationMySqlDbContext : DbContext, IApplicationDbContext
  {
    private IConfiguration _configuration { get; set; }
    private readonly IMediatorHandler _mediator;
    private readonly IUnitOfWork _unitOfWork;

    public ApplicationMySqlDbContext(IConfiguration configuration)
        => _configuration = configuration;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseMySql(_configuration.GetConnectionString("DefaultConnection"),
                ServerVersion.AutoDetect(_configuration.GetConnectionString("DefaultConnection")));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Ignore<Event>();
      modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationMySqlDbContext).Assembly);
      base.OnModelCreating(modelBuilder);
    }

    public DbSet<Employee> Employee { get; set; }
    public DbSet<Branch> Branch { get; set; }
    public DbSet<Company> Company { get; set; }
    public DbSet<Equipament> Equipament { get; set; }
    public DbSet<Incident> Incident { get; set; }
    public DbSet<Vehicle> Vehicle { get; set; }
    public override DatabaseFacade Database => base.Database;

    public async Task<int> Save()
    {
      var entries = ChangeTracker.Entries()
          .Where(e => e.Entity is EntityBase &&
              (e.State == EntityState.Added ||
               e.State == EntityState.Modified));

      foreach (var entry in entries)
      {
        var entity = (EntityBase)entry.Entity;
        entity.SetLastModification(DateTime.Now);

        switch (entry.State)
        {
          case EntityState.Detached:
          case EntityState.Modified:
            entry.Property(nameof(entity.InsertionDate)).IsModified = false;
            break;
          case EntityState.Added:
            entity.SetInsertionDate(DateTime.Now);
            break;
        }
      }

      var success = await SaveChangesAsync();
      if (success > 0) PublishEvents();

      return success;
    }

    private void PublishEvents()
    {
      var domainEntities = ChangeTracker
          .Entries<Entity>()
          .Where(x => x.Entity.EventNotifications != null && x.Entity.EventNotifications.Any());

      var domainEvents = domainEntities
          .SelectMany(x => x.Entity.EventNotifications)
          .ToList();

      domainEntities.ToList()
          .ForEach(entity => entity.Entity.ClearEvents());

      var tasks = domainEvents
      .Select(async (domainEvent) =>
      {
        await _mediator.PublishEvent(domainEvent);
      });

      Task.WhenAll(tasks).Wait();
    }

    public void SeedData()
    {
      if (!Company.Any())
      {
        Company.Add(new Company("Tidy Team", "Lisbon, PT", "999999999", new()));
        Task.FromResult(Save());
      }
    }

    public new DbSet<TEntity> Set<TEntity>() where TEntity : Entity => base.Set<TEntity>();
  }
}
