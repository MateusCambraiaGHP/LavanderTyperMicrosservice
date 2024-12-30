using LavanderTyperWeb.Core.Data;
using LTW.Incident.Infrastructure.Common.Interfaces;

namespace LTW.Incident.Infrastructure.Transaction
{
  public class UnitOfWork : IUnitOfWork
  {
    private readonly IApplicationDbContext _applicationDbContext;

    public UnitOfWork(IApplicationDbContext applicationDbContext) => _applicationDbContext = applicationDbContext;

    public async Task CommitChangesAsync() => await _applicationDbContext.Save();
  }
}
