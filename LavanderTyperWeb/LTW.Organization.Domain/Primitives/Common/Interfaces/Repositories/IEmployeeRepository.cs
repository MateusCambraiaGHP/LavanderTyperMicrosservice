using LTW.Organization.Domain.Primitives.Entities.Employees;
using System.Linq.Expressions;

namespace LTW.Organization.Domain.Primitives.Common.Interfaces.Repositories
{
  public interface IEmployeeRepository
  {
    Task Create(Employee model);
    Task<Employee> Update(Employee model);
    Task<List<Employee>> GetAsync(
        Expression<Func<Employee, bool>>? filter,
        Func<IQueryable<Employee>, IOrderedQueryable<Employee>>? orderBy,
        params Expression<Func<Employee, object>>[]? includes);
  }
}
