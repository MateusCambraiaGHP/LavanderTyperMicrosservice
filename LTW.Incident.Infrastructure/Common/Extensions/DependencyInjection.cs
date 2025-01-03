using LTW.Core.Data;
using LTW.Incident.Domain.Primitives.Common.Interfaces.Repositories;
using LTW.Incident.Infrastructure.Common.Interfaces;
using LTW.Incident.Infrastructure.Data;
using LTW.Incident.Infrastructure.Repositories;
using LTW.Incident.Infrastructure.Transaction;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace LTW.Incident.Infrastructure.Common.Extensions
{
  public static class DependencyInjection
  {
    public static IServiceCollection AddData(this IServiceCollection services)
    {
      services.AddScoped<IApplicationDbContext, ApplicationMySqlDbContext>();
      services.AddScoped<IIncidentRepository, IncidentRepository>();
      services.AddScoped<IUnitOfWork, UnitOfWork>();
      Assembly assembly = Assembly.GetExecutingAssembly();
      var mappingProfiles = assembly.GetTypes().Where(a => a.Name.Contains("MappingProfile"));
      foreach (var mappingProfile in mappingProfiles)
      {
        services.AddAutoMapper(mappingProfile);
      }
      return services;
    }

    public static void MigrateDatabase(this IServiceProvider provider)
    {
      using var scope = provider.CreateScope();
      var services = scope.ServiceProvider;
      var context = services.GetRequiredService<IApplicationDbContext>();
      if (Microsoft.EntityFrameworkCore.RelationalDatabaseFacadeExtensions
           .GetPendingMigrations(context.Database).Any())
      {
        Microsoft.EntityFrameworkCore.RelationalDatabaseFacadeExtensions
            .Migrate(context.Database);
      }
      context.SeedData();
    }
  }
}
