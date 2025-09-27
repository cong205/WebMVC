using TH_Employee.Models;
using Microsoft.EntityFrameworkCore;
namespace TH_Employee.Data

{
     public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Employee> Employees { get; set; }
}
}
