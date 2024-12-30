using LavanderTyperWeb.Core.Data;
using LTW.Organization.Infrastructure.Common.Interfaces;

namespace LTW.Organization.Infrastructure.Transaction
{
  public class UnitOfWork : IUnitOfWork
  {
    private readonly IApplicationDbContext _applicationDbContext;

    public UnitOfWork(IApplicationDbContext applicationDbContext) => _applicationDbContext = applicationDbContext;

    public async Task CommitChangesAsync() => await _applicationDbContext.Save();
  }
}
