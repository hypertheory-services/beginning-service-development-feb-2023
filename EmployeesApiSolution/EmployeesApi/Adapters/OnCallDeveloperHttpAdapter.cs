namespace EmployeesApi.Adapters;

public class OnCallDeveloperHttpAdapter
{

    private readonly HttpClient _httpClient;

    public OnCallDeveloperHttpAdapter(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task< GetOnCallDeveloperResponse> GetOnCallDeveloperAsync()
    {
        var response = await  _httpClient.GetAsync("/oncalldeveloper");
        response.EnsureSuccessStatusCode(); // Weird. 

        var content = await response.Content.ReadFromJsonAsync<GetOnCallDeveloperResponse>();

        if(content != null)
        {
            return content;
        } else
        {
            throw new ApplicationException("Invalid response"); // todo: More on this later.
        }
    }
}

