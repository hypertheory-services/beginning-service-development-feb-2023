
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
        GetStatusContactInfo? contact;
        try
        {
            var onCallDeveloperResponse = await _onCallDeveloperAdapter.GetOnCallDeveloperAsync();
            contact = new GetStatusContactInfo(onCallDeveloperResponse.Contact.Name, onCallDeveloperResponse.Contact.PhoneNumber, onCallDeveloperResponse.Contact.Email);
        }
        catch (Exception)
        {

            contact = null;
        }
        var response = new GetStatusResponse
        {
            Message = "Looks good",
            StatusLevel = StatusLevel.OnFire,
            HelpContact = contact
        };
        return Ok(response);
    }
}
