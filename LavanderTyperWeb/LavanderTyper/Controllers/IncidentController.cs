using LavanderTyperWeb.Application.Dtos.Incidents;
using LavanderTyperWeb.Application.Features.Commands.Incidents;
using LavanderTyperWeb.Application.Features.Queries.Incidents;
using LavanderTyperWeb.Application.Features.Responses.Incidents;
using LavanderTyperWeb.Core.Communication.Mediator.Interfaces;
using LavanderTyperWeb.Core.Messages.Notifications;
using LavanderTyperWeb.Infrastructure.Loggers.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LavanderTyperWeb.Controllers
{
    [Route("incident/")]
    [ApiController]
    public class IncidentController : BaseController
    {
        public IncidentController(
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediator,
            ILoggerService loggerHandler)
             : base(notifications, mediator, loggerHandler) { }

        [HttpGet]
        public async Task<GetIncidentListQueryResponse> GetAll([FromQuery(Name = "correlationalId")] string correlationalId)
        {
            await RequestReception(correlationalId);

            var response = await _mediator.SendQuery(new GetIncidentListQuery());

            await _loggerHandler.LogInfoAsync(
                null,
                "End Request",
                GetCurrentRoute(),
                response);

            return response;
        }

        [HttpGet("{id}")]
        public async Task<GetIncidentByIdQueryResponse> GetById(
            Guid id,
            [FromQuery(Name = "correlationalId")] string correlationalId)
        {
            await RequestReception(correlationalId, id);

            var response = await _mediator.SendQuery(new GetIncidentByIdQuery(id));

            await _loggerHandler.LogInfoAsync(
                null,
                "End Request",
                GetCurrentRoute(),
                response);

            return response;
        }

        [HttpPost]
        public async Task<CreateIncidentCommandResponse> Create(
            CreateIncidentDto model,
            [FromQuery(Name = "correlationalId")] string correlationalId)
        {
            await RequestReception(correlationalId, model);

            var response = await _mediator.SendCommand(new CreateIncidentCommand(model));

            await _loggerHandler.LogInfoAsync(
              null,
              "End Request",
              GetCurrentRoute(),
              response);

            return response;
        }

        [HttpPut]
        public async Task<UpdateIncidentCommandResponse> Update(
            UpdateIncidentDto model,
            [FromQuery(Name = "correlationalId")] string correlationalId)
        {
            await RequestReception(correlationalId, model);

            var response = await _mediator.SendCommand(new UpdateIncidentCommand(model));

            await _loggerHandler.LogInfoAsync(
              null,
              "End Request",
              GetCurrentRoute(),
              response);

            return response;
        }
    }
}
