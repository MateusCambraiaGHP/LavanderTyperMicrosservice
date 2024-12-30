using LavanderTyperWeb.Core.Messages.CommonMessages;
using LTW.Organization.Application.Features.Responses.Employees;

namespace LTW.Organization.Application.Features.Queries.Employees
{
  public class GetEmployeeByIdQuery : Query<GetEmployeeByIdQueryResponse>
  {
    public Guid Id { get; set; }

    public GetEmployeeByIdQuery(Guid id) => Id = id;
  }
}
