using LavanderTyperWeb.Data.Common.Interfaces;
using LavanderTyperWeb.Domain.Primitives.Common.Interfaces.Repositories;
using LavanderTyperWeb.Domain.Primitives.Entities.Companies;

namespace LavanderTyperWeb.Data.Repositories
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        public CompanyRepository(IApplicationDbContext context) : base(context) { }
    }
}
