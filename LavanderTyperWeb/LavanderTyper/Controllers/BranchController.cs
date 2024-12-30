using LavanderTyperWeb.Application.Dtos.Branchs;
using LavanderTyperWeb.Application.Features.Commands.Branchs;
using LavanderTyperWeb.Application.Features.Queries.Branchs;
using LavanderTyperWeb.Application.Features.Responses.Branchs;
using LavanderTyperWeb.Core.Communication.Mediator.Interfaces;
using LavanderTyperWeb.Core.Messages.Notifications;
using LavanderTyperWeb.Infrastructure.Loggers.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LavanderTyperWeb.Controllers
{
    [Route("branch/")]
    [ApiController]
    public class BranchController : BaseController
    {
        public BranchController(
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediator,
            ILoggerService loggerHandler)
             : base(notifications, mediator, loggerHandler) { }

        [HttpGet]
        public async Task<GetBranchListQueryResponse> GetAll([FromQuery(Name = "correlationalId")] string correlationalId)
        {
            await RequestReception(correlationalId);

            var response = await _mediator.SendQuery(new GetBranchListQuery());

            await _loggerHandler.LogInfoAsync(
                null,
                "End Request",
                GetCurrentRoute(),
                response);

            return response;
        }

        [HttpGet("{id}")]
        public async Task<GetBranchByIdQueryResponse> GetById(
            Guid id,
            [FromQuery(Name = "correlationalId")] string correlationalId)
        {
            await RequestReception(correlationalId, id);

            var response = await _mediator.SendQuery(new GetBranchByIdQuery(id));

            await _loggerHandler.LogInfoAsync(
                null,
                "End Request",
                GetCurrentRoute(),
                response);

            return response;
        }

        [HttpPost]
        public async Task<CreateBranchCommandResponse> Create(
            CreateBranchDto model,
            [FromQuery(Name = "correlationalId")] string correlationalId)
        {
            await RequestReception(correlationalId, model);

            var response = await _mediator.SendCommand(new CreateBranchCommand(model));

            await _loggerHandler.LogInfoAsync(
              null,
              "End Request",
              GetCurrentRoute(),
              response);

            return response;
        }

        [HttpPut]
        public async Task<UpdateBranchCommandResponse> Update(
            UpdateBranchDto model,
            [FromQuery(Name = "correlationalId")] string correlationalId)
        {
            await RequestReception(correlationalId, model);

            var response = await _mediator.SendCommand(new UpdateBranchCommand(model));

            await _loggerHandler.LogInfoAsync(
              null,
              "End Request",
              GetCurrentRoute(),
              response);

            return response;
        }
    }
}
