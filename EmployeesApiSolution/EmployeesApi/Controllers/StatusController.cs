
namespace EmployeesApi.Controllers;


public class StatusController : ControllerBase
{

    private readonly OnCallDeveloperHttpAdapter _onCallDeveloperAdapter;

    public StatusController(OnCallDeveloperHttpAdapter callDeveloperHttpAdapter)
    {
        _onCallDeveloperAdapter = callDeveloperHttpAdapter;
    }

    [HttpGet("/status")]
    public async Task<ActionResult> GetStatus()
    {
        var onCallDeveloperResponse = await _onCallDeveloperAdapter.GetOnCallDeveloperAsync();
        var contact = new GetStatusContactInfo(onCallDeveloperResponse.Contact.Name, onCallDeveloperResponse.Contact.PhoneNumber, onCallDeveloperResponse.Contact.Email);
        var response = new GetStatusResponse
        {
            Message = "Looks good",
            StatusLevel = StatusLevel.OnFire,
            HelpContact = contact
        };
        return Ok(response);
    }
}
