using LTW.Core.Data;
using LTW.Resources.Infrastructure.Common.Interfaces;

namespace LTW.Resources.Infrastructure.Transaction
{
  public class UnitOfWork : IUnitOfWork
  {
    private readonly IApplicationDbContext _applicationDbContext;

    public UnitOfWork(IApplicationDbContext applicationDbContext) => _applicationDbContext = applicationDbContext;

    public async Task CommitChangesAsync() => await _applicationDbContext.Save();
  }
}
