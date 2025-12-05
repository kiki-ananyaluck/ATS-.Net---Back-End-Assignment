using AtsAssessment.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AtsAssessment.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _service;

        public EmployeeController(IEmployeeService service)
        {
            _service = service;
        }

        [HttpGet("with-department")]
        public async Task<IActionResult> GetEmployeesWithDepartment()
        {
            var data = await _service.GetEmployeesWithDepartment();

            var response = data.Select(e => new
            {
                e.Id,
                e.Emp_Code,
                e.Full_Name,
                e.Age,
                e.Position,
                e.Salary,
                Department = e.Department?.Department_Name
            });

            return Ok(response);
        }

    }
}
