

using EmployeesApi.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace EmployeesApi.Controllers;

public class EmployeesController : ControllerBase
{
    private readonly EmployeesDataContext _context;

    public EmployeesController(EmployeesDataContext context)
    {
        _context = context;
    }

    [HttpPost("/employees")]
    public async Task<ActionResult<GetEmployeeDetailsItem>> AddEmployee([FromBody] PostEmployeeCreate request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        else
        {
            var employeeToAdd = new EmployeeEntity
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Salary = request.Salary,
                Email = request.Email
            };
            _context.Employees.Add(employeeToAdd);
            await _context.SaveChangesAsync(); // after this line of course, employeToAdd will have an ID
            var response = new GetEmployeeDetailsItem
            {
                Id = employeeToAdd.Id.ToString(),
                FirstName = employeeToAdd.FirstName,
                LastName = employeeToAdd.LastName,
                Email = employeeToAdd.Email ?? "No Email Provided",
                Salary = employeeToAdd.Salary
            };
            return StatusCode(201, response); // oops! send an domain class to the client.
        }
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
    //[Authorize]
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
