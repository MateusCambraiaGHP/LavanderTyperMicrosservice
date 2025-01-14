using LTW.Organization.Domain.Primitives.Common.Interfaces.Repositories;
using LTW.Organization.Domain.Primitives.Entities.Branchs;
using LTW.Organization.Infrastructure.Common.Interfaces;

namespace LTW.Organization.Infrastructure.Repositories
{
  public class BranchRepository : Repository<Branch>, IBranchRepository
  {
    public BranchRepository(IApplicationDbContext context) : base(context) { }
  }
}
