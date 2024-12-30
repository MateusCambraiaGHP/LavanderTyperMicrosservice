using LavanderTyperWeb.Application.Dtos.Employee;
using LavanderTyperWeb.Application.Features.Commands.Employee;
using LavanderTyperWeb.Application.Features.Queries.Employees;
using LavanderTyperWeb.Application.Features.Responses.Employees;
using LavanderTyperWeb.Core.Communication.Mediator.Interfaces;
using LavanderTyperWeb.Core.Messages.Notifications;
using LavanderTyperWeb.Infrastructure.Loggers.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LavanderTyperWeb.Controllers
{
    [Route("employee/")]
    [ApiController]
    public class EmployeeController : BaseController
    {
        public EmployeeController(
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediator,
            ILoggerService loggerHandler)
             : base(notifications, mediator, loggerHandler) { }

        [HttpGet]
        public async Task<GetEmployeeListQueryResponse> GetAll([FromQuery(Name = "correlationalId")] string correlationalId)
        {
            await RequestReception(correlationalId);

            var response = await _mediator.SendQuery(new GetEmployeeListQuery());

            await _loggerHandler.LogInfoAsync(
                null,
                "End Request",
                GetCurrentRoute(),
                response);
            return response;
        }

        [HttpGet("{id}")]
        public async Task<GetEmployeeByIdQueryResponse> GetById(
            Guid id,
            [FromQuery(Name = "correlationalId")] string correlationalId)
        {
            await RequestReception(correlationalId, id);

            var response = await _mediator.SendQuery(new GetEmployeeByIdQuery(id));

            await _loggerHandler.LogInfoAsync(
                null,
                "End Request",
                GetCurrentRoute(),
                response);

            return response;
        }

        [HttpPost]
        public async Task<CreateEmployeeCommandResponse> Create(
            CreateEmployeeDto model,
            [FromQuery(Name = "correlationalId")] string correlationalId)
        {
            await RequestReception(correlationalId, model);

            var response = await _mediator.SendCommand(new CreateEmployeeCommand(model));

            await _loggerHandler.LogInfoAsync(
              null,
              "End Request",
              GetCurrentRoute(),
              response);

            return response;
        }

        [HttpPut]
        public async Task<UpdateEmployeeCommandResponse> Update(
            UpdateEmployeeDto model,
            [FromQuery(Name = "correlationalId")] string correlationalId)
        {
            await RequestReception(correlationalId, model);

            var response = await _mediator.SendCommand(new UpdateEmployeeCommand(model));

            await _loggerHandler.LogInfoAsync(
              null,
              "End Request",
              GetCurrentRoute(),
              response);

            return response;
        }
    }
}
