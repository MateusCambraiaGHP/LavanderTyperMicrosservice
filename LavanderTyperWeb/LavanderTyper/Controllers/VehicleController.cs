using LavanderTyperWeb.Application.Dtos.Vehicles;
using LavanderTyperWeb.Application.Features.Commands.Vehicles;
using LavanderTyperWeb.Application.Features.Queries.Vehicles;
using LavanderTyperWeb.Application.Features.Responses.Vehicles;
using LavanderTyperWeb.Core.Communication.Mediator.Interfaces;
using LavanderTyperWeb.Core.Messages.Notifications;
using LavanderTyperWeb.Infrastructure.Loggers.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LavanderTyperWeb.Controllers
{
    [Route("vehicle/")]
    [ApiController]
    public class VehicleController : BaseController
    {
        public VehicleController(
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediator,
            ILoggerService loggerHandler)
             : base(notifications, mediator, loggerHandler) { }

        [HttpGet]
        public async Task<GetVehicleListQueryResponse> GetAll([FromQuery(Name = "correlationalId")] string correlationalId)
        {
            await RequestReception(correlationalId);

            var response = await _mediator.SendQuery(new GetVehicleListQuery());

            await _loggerHandler.LogInfoAsync(
                null,
                "End Request",
                GetCurrentRoute(),
                response);

            return response;
        }

        [HttpGet("{id}")]
        public async Task<GetVehicleByIdQueryResponse> GetById(
            Guid id,
            [FromQuery(Name = "correlationalId")] string correlationalId)
        {
            await RequestReception(correlationalId, id);

            var response = await _mediator.SendQuery(new GetVehicleByIdQuery(id));

            await _loggerHandler.LogInfoAsync(
                null,
                "End Request",
                GetCurrentRoute(),
                response);

            return response;
        }

        [HttpPost]
        public async Task<CreateVehicleCommandResponse> Create(
            CreateVehicleDto model,
            [FromQuery(Name = "correlationalId")] string correlationalId)
        {
            await RequestReception(correlationalId, model);

            var response = await _mediator.SendCommand(new CreateVehicleCommand(model));

            await _loggerHandler.LogInfoAsync(
              null,
              "End Request",
              GetCurrentRoute(),
              response);

            return response;
        }

        [HttpPut]
        public async Task<UpdateVehicleCommandResponse> Update(
            UpdateVehicleDto model,
            [FromQuery(Name = "correlationalId")] string correlationalId)
        {
            await RequestReception(correlationalId, model);

            var response = await _mediator.SendCommand(new UpdateVehicleCommand(model));

            await _loggerHandler.LogInfoAsync(
              null,
              "End Request",
              GetCurrentRoute(),
              response);

            return response;
        }
    }
}
