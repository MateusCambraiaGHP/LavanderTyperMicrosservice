using LTW.Core.Data;
using LTW.Resources.Domain.Primitives.Common.Interfaces.Repositories;
using LTW.Resources.Infrastructure.Common.Interfaces;
using LTW.Resources.Infrastructure.Data;
using LTW.Resources.Infrastructure.Repositories;
using LTW.Resources.Infrastructure.Transaction;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace LTW.Resources.Infrastructure.Common.Extensions
{
  public static class DependencyInjection
  {
    public static IServiceCollection AddData(this IServiceCollection services)
    {
      services.AddScoped<IApplicationDbContext, ApplicationMySqlDbContext>();
      services.AddScoped<IEquipamentRepository, EquipamentRepository>();
      services.AddScoped<IVehicleRepository, VehicleRepository>();
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
