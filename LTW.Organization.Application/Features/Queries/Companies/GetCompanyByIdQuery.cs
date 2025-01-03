using LTW.Core.Messages.CommonMessages;
using LTW.Organization.Application.Features.Responses.Companies;

namespace LTW.Organization.Application.Features.Queries.Companies
{
  public class GetCompanyByIdQuery : Query<GetCompanyByIdQueryResponse>
  {
    public Guid Id { get; set; }

    public GetCompanyByIdQuery(Guid id) => Id = id;
  }
}
