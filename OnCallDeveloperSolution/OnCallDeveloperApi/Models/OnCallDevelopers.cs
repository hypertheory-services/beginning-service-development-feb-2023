namespace OnCallDeveloperApi.Models;



public record OnCallDeveloperContact(string FirstName, string LastName, string Email, string PhoneNumber);
public record OnCallDeveloperResponse(OnCallDeveloperContact Contact);

public record OnCallServiceResponseContact(string Name, string PhoneNumber, string Email);
public record OnCallServiceResponse(OnCallServiceResponseContact Contact);