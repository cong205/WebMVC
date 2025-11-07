using Microsoft.EntityFrameworkCore;
namespace Luyen_code_first_1.Models
{
    public class LuyencodefirstContext : DbContext
    { public LuyencodefirstContext(DbContextOptions<LuyencodefirstContext> options)
                : base(options) { }
        public DbSet<NdcLoai_San_Pham> ndcLoai_San_Phams { get; set; }
        public DbSet<NdcSan_Pham> ndcSan_Phams { get; set; }

    }
}
