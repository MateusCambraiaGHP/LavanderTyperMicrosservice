﻿using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace LTW.Incident.Application.Cummon.Extensions
{
  public static class DependencyInjection
  {
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
      services.AddAutoMapper(Assembly.GetExecutingAssembly());
      services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

      return services;
    }
  }
}