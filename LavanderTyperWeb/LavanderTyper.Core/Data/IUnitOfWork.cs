namespace LavanderTyperWeb.Core.Data
{
    public interface IUnitOfWork
    {
        Task CommitChangesAsync();
    }
}
