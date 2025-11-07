using Microsoft.EntityFrameworkCore;
namespace ndc_231230723_de01.Models
{
    public class NdcComputerContext : DbContext
    {
        public NdcComputerContext(DbContextOptions<NdcComputerContext> options)
                : base(options) { }
        public DbSet<NdcComputer> NdcComputers { get; set; }
    }
}
