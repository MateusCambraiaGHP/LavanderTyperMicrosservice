﻿using LTW.Core.Communication.Mediator.Interfaces;
using LTW.Core.Data;
using LTW.Core.DomainObjects;
using LTW.Core.Messages.CommonMessages;
using LTW.Incident.Domain.Primitives.Entities.Incidents.Enums;
using LTW.Incident.Infrastructure.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using IncidentEntity = LTW.Incident.Domain.Primitives.Entities.Incidents.Incident;

namespace LTW.Incident.Infrastructure.Data
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
    public DbSet<IncidentEntity> Incident { get; set; }
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
      if (!Incident.Any())
      {
        Incident.Add(new IncidentEntity(Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), DateOnly.MinValue, "", IncidentType.CoworkersConflict));
        Task.FromResult(Save());
      }
    }

    public new DbSet<TEntity> Set<TEntity>() where TEntity : Entity => base.Set<TEntity>();
  }
}
