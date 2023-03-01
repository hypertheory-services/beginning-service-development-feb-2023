

using Microsoft.EntityFrameworkCore;

namespace EmployeesApi.Controllers;

public class EmployeesController : ControllerBase
{
    private readonly EmployeesDataContext _context;

    public EmployeesController(EmployeesDataContext context)
    {
        _context = context;
    }

    //[HttpGet("/employees/summary")]
    //public async Task<ActionResult> GetEmployeeSummary()
    //{
    //    return Ok(); // in here give other developers what they need.
    //}

    [HttpGet("/employees/{employeeId:int}")]
    public async Task<ActionResult> GetEmployeeDetails(int employeeId)
    {
        var response = await _context.Employees
                .Where(emp => emp.Id == employeeId)
                .Select(emp => new GetEmployeeDetailsItem
                {
                    Id = emp.Id.ToString(),
                    FirstName = emp.FirstName,
                    LastName = emp.LastName,
                    Email = emp.Email ?? "No Email Provided",
                    Salary = emp.Salary
                }).SingleOrDefaultAsync();
        if(response == null)
        {
            return NotFound(); // 404
        } else
        {
            return Ok(response);
        }
    }


    // GET /employees
    [HttpGet("/employees")]
    public async Task<ActionResult<GetEmployeeSummary>> GetAllEmployees()
    {
        var employees = await _context.Employees.OrderBy(e=> e.LastName)
            .Select(emp => new GetEmployeeSummaryItem
            {
                Id = emp.Id.ToString(),
                FirstName = emp.FirstName,
                LastName = emp.LastName,
                Email = emp.Email ?? "No Email Available"
            })
            .ToListAsync();

        var response = new GetEmployeeSummary {  Employees = employees };
        return Ok(response);
    }
}
