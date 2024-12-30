using LavanderTyperWeb.Core.Messages.CommonMessages;
using LavanderTyperWeb.Core.Messages.Notifications;

namespace LavanderTyperWeb.Core.Communication.Mediator.Interfaces
{
    public interface IMediatorHandler
    {
        Task<BaseHandlerResponse> SendCommand<TCommand>(TCommand command) where TCommand : Command;
        Task<TResponse> SendCommand<TResponse>(BaseMessage<TResponse> command)
            where TResponse : BaseHandlerResponse;

        Task<TResponse> SendQuery<TResponse>(BaseMessage<TResponse> query)
            where TResponse : BaseHandlerResponse;

        Task PublishNotification<T>(T notificacao) where T : DomainNotification;

        Task PublishEvent<TEvent>(TEvent @event);
    }
}
