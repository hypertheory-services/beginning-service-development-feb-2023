

using Microsoft.EntityFrameworkCore;

namespace EmployeesApi.Controllers;

public class EmployeesController : ControllerBase
{
    private readonly EmployeesDataContext _context;

    public EmployeesController(EmployeesDataContext context)
    {
        _context = context;
    }

    [HttpGet("/employees/summary")]
    public async Task<ActionResult> GetEmployeeSummary()
    {
        return Ok(); // in here give other developers what they need.
    }

    // GET /employees
    [HttpGet("/employees")]
    public async Task<ActionResult> GetAllEmployees()
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
