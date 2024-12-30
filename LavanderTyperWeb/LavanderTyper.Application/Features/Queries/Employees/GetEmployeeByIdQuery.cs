using LavanderTyperWeb.Application.Features.Responses.Employees;
using LavanderTyperWeb.Core.Messages.CommonMessages;

namespace LavanderTyperWeb.Application.Features.Queries.Employees
{
    public class GetEmployeeByIdQuery : Query<GetEmployeeByIdQueryResponse>
    {
        public Guid Id { get; set; }

        public GetEmployeeByIdQuery(Guid id) => Id = id;
    }
}
