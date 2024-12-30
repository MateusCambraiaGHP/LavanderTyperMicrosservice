using LavanderTyperWeb.Application.Features.Responses.Companies;
using LavanderTyperWeb.Core.Messages.CommonMessages;

namespace LavanderTyperWeb.Application.Features.Queries.Companies
{
    public class GetCompanyByIdQuery : Query<GetCompanyByIdQueryResponse>
    {
        public Guid Id { get; set; }

        public GetCompanyByIdQuery(Guid id) => Id = id;
    }
}
