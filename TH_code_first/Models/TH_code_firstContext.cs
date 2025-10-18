using Microsoft.EntityFrameworkCore;

namespace TH_code_first.Models
{
    public class TH_code_firstContext : DbContext
    {
        public TH_code_firstContext(DbContextOptions<TH_code_firstContext> options)
                : base(options) { }

        public DbSet<NdcLoai_San_Pham> ndcLoai_San_Phams { get; set; }
        public DbSet<NdcSan_Pham> ndcSan_Phams { get; set; }
    }
}
