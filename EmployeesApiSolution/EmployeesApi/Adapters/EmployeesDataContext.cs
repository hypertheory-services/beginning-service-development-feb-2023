using EmployeesApi.Domain;
using Microsoft.EntityFrameworkCore;

namespace EmployeesApi.Adapters;

public class EmployeesDataContext : DbContext
{
    public EmployeesDataContext(DbContextOptions<EmployeesDataContext> options): base(options)
    {
        
    }
    public DbSet<EmployeeEntity> Employees { get; set; }

}
