using LTW.Core.Data;
using LTW.Organization.Domain.Primitives.Common.Interfaces.Repositories;
using LTW.Organization.Infrastructure.Common.Interfaces;
using LTW.Organization.Infrastructure.Data;
using LTW.Organization.Infrastructure.Repositories;
using LTW.Organization.Infrastructure.Transaction;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace LTW.Organization.Infrastructure.Common.Extensions
{
  public static class DependencyInjection
  {
    public static IServiceCollection AddData(this IServiceCollection services)
    {
      services.AddScoped<IApplicationDbContext, ApplicationMySqlDbContext>();
      services.AddScoped<IEmployeeRepository, EmployeeRepository>();
      services.AddScoped<ICompanyRepository, CompanyRepository>();
      services.AddScoped<IBranchRepository, BranchRepository>();
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
