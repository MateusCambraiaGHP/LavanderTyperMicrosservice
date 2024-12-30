using LavanderTyperWeb.Data.Common.Interfaces;
using LavanderTyperWeb.Domain.Primitives.Common.Interfaces.Repositories;
using LavanderTyperWeb.Domain.Primitives.Entities.Loggers;

namespace LavanderTyperWeb.Data.Repositories
{
    public class LoggerRepository : Repository<Logger>, ILoggerRepository
    {
        public LoggerRepository(IApplicationDbContext context) : base(context) { }
    }
}
