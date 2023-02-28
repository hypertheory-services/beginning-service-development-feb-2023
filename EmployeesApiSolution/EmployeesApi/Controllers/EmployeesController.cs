

namespace EmployeesApi.Controllers;

public class EmployeesController : ControllerBase
{

    // GET /employees
    [HttpGet("/employees")]
    public async Task<ActionResult> GetAllEmployees()
    {
        return Ok();
    }
}
