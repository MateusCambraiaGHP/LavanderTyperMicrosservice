using LavanderTyperWeb.Infrastructure.Loggers.Interfaces;
using LavanderTyperWeb.Infrastructure.Loggers.Models;
using Microsoft.Extensions.DependencyInjection;

namespace LavanderTyperWeb.Infrastructure.Common.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<ILoggerService, LoggerService>();
            return services;
        }
    }
}
