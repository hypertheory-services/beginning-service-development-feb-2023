
namespace EmployeesApi.Controllers;


public class StatusController : ControllerBase
{
    [HttpGet("/status")]
    public async Task<ActionResult> GetStatus()
    {
        var response = new GetStatusResponse
        {
            Message = "Looks good",
            StatusLevel = StatusLevel.OnFire,
            HelpContact = new GetStatusContactInfo("David Sands", "555-1555", "dave@aol.com")
        };
        return Ok(response);
    }
}
