using LavanderTyperWeb.Core.Communication.Mediator.Interfaces;
using LavanderTyperWeb.Core.Messages.Notifications;
using LavanderTyperWeb.Infrastructure.Loggers.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LavanderTyperWeb.Controllers
{
    //[Authorize]
    [Route("api/v1.0/")]
    public abstract class BaseController : ControllerBase
    {
        private readonly DomainNotificationHandler _notifications;
        internal readonly IMediatorHandler _mediator;
        internal readonly ILoggerService _loggerHandler;

        protected BaseController(
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediator,
            ILoggerService loggerHandler)
        {
            _notifications = (DomainNotificationHandler)notifications;
            _mediator = mediator;
            _loggerHandler = loggerHandler;
        }

        protected bool isValid() => !_notifications.HasNotifications();

        protected IEnumerable<string> GetMessagesError() => _notifications.GetNotifications().Select(c => c.Value).ToList();

        protected void NotifyError(string code, string message) => _mediator.PublishNotification(new DomainNotification(code, message));

        internal void ValidateCorrelationalId(string correlationalId)
        {
            if (string.IsNullOrWhiteSpace(correlationalId))
                throw new ArgumentNullException(nameof(correlationalId));
        }

        internal async Task RequestReception(string correlationalId) => await RequestReception(correlationalId, null);

        internal async Task RequestReception(string correlationalId, object? payload)
        {
            ValidateCorrelationalId(correlationalId);
            _loggerHandler.SetCorrelationalId(correlationalId);

            payload = payload is null ?
                new { CorrelationalId = correlationalId } :
                payload;

            await _loggerHandler.LogInfoAsync(
                payload,
                "Begin Request",
                GetCurrentRoute());
        }

        internal string GetCurrentRoute() => $"{Request.Host}/{Request.Path}/{Request.RouteValues.FirstOrDefault().Value}/{Request.QueryString}";
    }
}
