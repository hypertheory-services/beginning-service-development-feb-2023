namespace EmployeesApi.Models;


public class GetOnCallDeveloperResponse
{
    public Contact Contact { get; set; } = new();
}

public class Contact
{
    public string Name { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}
