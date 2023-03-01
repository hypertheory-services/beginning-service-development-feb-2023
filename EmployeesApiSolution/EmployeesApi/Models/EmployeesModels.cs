namespace EmployeesApi.Models;


public record GetEmployeeSummaryItem
{
    public string Id { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;   
} 

public record GetEmployeeSummary
{
    public List<GetEmployeeSummaryItem> Employees { get; set; } = new();
}