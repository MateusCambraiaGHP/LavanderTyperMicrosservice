using LavanderTyperWeb.Application.Dtos.Equipaments;
using LavanderTyperWeb.Application.Features.Commands.Equipaments;
using LavanderTyperWeb.Application.Features.Queries.Equipaments;
using LavanderTyperWeb.Application.Features.Responses.Equipaments;
using LavanderTyperWeb.Core.Communication.Mediator.Interfaces;
using LavanderTyperWeb.Core.Messages.Notifications;
using LavanderTyperWeb.Infrastructure.Loggers.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LavanderTyperWeb.Controllers
{
    [Route("equipament/")]
    [ApiController]
    public class EquipamentController : BaseController
    {
        public EquipamentController(
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediator,
            ILoggerService loggerHandler)
             : base(notifications, mediator, loggerHandler) { }

        [HttpGet]
        public async Task<GetEquipamentListQueryResponse> GetAll([FromQuery(Name = "correlationalId")] string correlationalId)
        {
            await RequestReception(correlationalId);

            var response = await _mediator.SendQuery(new GetEquipamentListQuery());

            await _loggerHandler.LogInfoAsync(
                null,
                "End Request",
                GetCurrentRoute(),
                response);

            return response;
        }

        [HttpGet("{id}")]
        public async Task<GetEquipamentByIdQueryResponse> GetById(
            Guid id,
            [FromQuery(Name = "correlationalId")] string correlationalId)
        {
            await RequestReception(correlationalId, id);

            var response = await _mediator.SendQuery(new GetEquipamentByIdQuery(id));

            await _loggerHandler.LogInfoAsync(
                null,
                "End Request",
                GetCurrentRoute(),
                response);

            return response;
        }

        [HttpPost]
        public async Task<CreateEquipamentCommandResponse> Create(
            CreateEquipamentDto model,
            [FromQuery(Name = "correlationalId")] string correlationalId)
        {
            await RequestReception(correlationalId, model);

            var response = await _mediator.SendCommand(new CreateEquipamentCommand(model));

            await _loggerHandler.LogInfoAsync(
              null,
              "End Request",
              GetCurrentRoute(),
              response);

            return response;
        }

        [HttpPut]
        public async Task<UpdateEquipamentCommandResponse> Update(
            UpdateEquipamentDto model,
            [FromQuery(Name = "correlationalId")] string correlationalId)
        {
            await RequestReception(correlationalId, model);

            var response = await _mediator.SendCommand(new UpdateEquipamentCommand(model));

            await _loggerHandler.LogInfoAsync(
              null,
              "End Request",
              GetCurrentRoute(),
              response);

            return response;
        }
    }
}
