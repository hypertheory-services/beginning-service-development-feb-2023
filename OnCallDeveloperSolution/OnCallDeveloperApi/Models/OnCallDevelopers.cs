namespace OnCallDeveloperApi.Models;



public record OnCallDeveloperContact(string FirstName, string LastName, string Email, string PhoneNumber);
public record OnCallDeveloperResponse(OnCallDeveloperContact Contact);
