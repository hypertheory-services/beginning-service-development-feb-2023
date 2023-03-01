using System.ComponentModel.DataAnnotations;

namespace EmployeesApi.Models;


public record GetEmployeeSummaryItem
{
    [Required]
    public string Id { get; set; } = string.Empty;
    [Required]
    public string FirstName { get; set; } = string.Empty;
    [Required]
    public string LastName { get; set; } = string.Empty;
    [Required, MaxLength(300)]
    public string Email { get; set; } = string.Empty;
}

public record GetEmployeeSummary
{
    public List<GetEmployeeSummaryItem> Employees { get; set; } = new();
}

public record GetEmployeeDetailsItem
{
    [Required]
    public string Id { get; set; } = string.Empty;
    [Required]
    public string FirstName { get; set; } = string.Empty;
    [Required]
    public string LastName { get; set; } = string.Empty;
    [Required, MaxLength(300)]
    public string Email { get; set; } = string.Empty;

    [Required]
    public decimal Salary { get; set; }
}


public class PostEmployeeCreate
{
    [Required, MaxLength(100)]
    public string FirstName { get; set; } = string.Empty;
    [Required]
    public string LastName { get; set; } = string.Empty;
    [Required,EmailAddress]
    public string Email { get; set; } = string.Empty;
    [Required, Range(10000, 250000)]
    public int Salary { get; set; }
}
