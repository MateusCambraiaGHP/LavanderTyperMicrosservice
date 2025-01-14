using LTW.Organization.Domain.Primitives.Common.Interfaces.Repositories;
using LTW.Organization.Domain.Primitives.Entities.Employees;
using LTW.Organization.Infrastructure.Common.Interfaces;

namespace LTW.Organization.Infrastructure.Repositories
{
  public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
  {
    public EmployeeRepository(IApplicationDbContext context) : base(context) { }
  }
}
