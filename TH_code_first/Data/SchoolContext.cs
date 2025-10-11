using Microsoft.EntityFrameworkCore;
using TH_code_first.Models;
namespace TH_code_first.Data
{
    public class SchoolContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=DESKTOP-SBAL8UV\SQLEXPRESS;Database=SchoolDB;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }
    }
}
