using AtsAssessment.Application.Interfaces;
using AtsAssessment.Domain.Entities;
using AtsAssessment.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AtsAssessment.Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly AppDbContext _db;

        public EmployeeService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Employee>> GetEmployeesWithDepartment()
        {
            return await _db.Employees
                            .Include(e => e.Department)
                            .ToListAsync();
        }

    }
}
