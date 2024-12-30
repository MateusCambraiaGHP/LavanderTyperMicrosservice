using LavanderTyperWeb.Core.Data;
using LavanderTyperWeb.Domain.Primitives.Common.Interfaces.Repositories;
using LTW.Incident.Infrastructure.Common.Interfaces;
using LTW.Incident.Infrastructure.Data;
using LTW.Incident.Infrastructure.Repositories;
using LTW.Incident.Infrastructure.Transaction;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace LTW.Incident.Infrastructure.Common.Extensions
{
  public static class DependencyInjection
  {
    public static IServiceCollection AddData(this IServiceCollection services)
    {
      services.AddScoped<IApplicationDbContext, ApplicationMySqlDbContext>();
      services.AddScoped<IEmployeeRepository, EmployeeRepository>();
      services.AddScoped<ICompanyRepository, CompanyRepository>();
      services.AddScoped<IEquipamentRepository, EquipamentRepository>();
      services.AddScoped<IBranchRepository, BranchRepository>();
      services.AddScoped<IIncidentRepository, IncidentRepository>();
      services.AddScoped<IVehicleRepository, VehicleRepository>();
      services.AddScoped<ILoggerRepository, LoggerRepository>();
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
      if (context.Database.GetPendingMigrations().Any())
        context.Database.Migrate();
      context.SeedData();
    }
  }
}
