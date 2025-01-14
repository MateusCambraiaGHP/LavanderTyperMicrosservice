using LTW.Core.Communication.Mediator;
using LTW.Core.Communication.Mediator.Interfaces;
using LTW.Core.Messages.Notifications;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace LTW.Core.Cummon.Extensions
{
  public static class MediatorIoc
  {
    public static IServiceCollection AddMediator(this IServiceCollection services)
    {
      services.AddScoped<IMediatorHandler, MediatorHandler>();
      services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
      return services;
    }
  }
}
