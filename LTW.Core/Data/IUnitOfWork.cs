namespace LTW.Core.Data
{
  public interface IUnitOfWork
  {
    Task CommitChangesAsync();
  }
}
