using System.ComponentModel.DataAnnotations;

namespace EmployeesApi.Domain;

public class EmployeeEntity
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string? Email { get; set; }
    public decimal Salary { get; set; }

    
}
