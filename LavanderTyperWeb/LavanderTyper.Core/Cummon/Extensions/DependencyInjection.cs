using LavanderTyperWeb.Core.Communication.Mediator;
using LavanderTyperWeb.Core.Communication.Mediator.Interfaces;
using LavanderTyperWeb.Core.Messages.Notifications;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace LavanderTyperWeb.Core.Cummon.Extensions
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
