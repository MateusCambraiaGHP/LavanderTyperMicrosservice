using LTW.Organization.Domain.Primitives.Common.Interfaces.Repositories;
using LTW.Organization.Domain.Primitives.Entities.Companies;
using LTW.Organization.Infrastructure.Common.Interfaces;

namespace LTW.Organization.Infrastructure.Repositories
{
  public class CompanyRepository : Repository<Company>, ICompanyRepository
  {
    public CompanyRepository(IApplicationDbContext context) : base(context) { }
  }
}
