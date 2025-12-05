using AtsAssessment.Domain.Entities;

namespace AtsAssessment.Application.Interfaces
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetEmployeesWithDepartment();

    }
}
