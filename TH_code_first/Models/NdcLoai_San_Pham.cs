using System.ComponentModel.DataAnnotations;

namespace TH_code_first.Models
{
    public class NdcLoai_San_Pham
    {
        [Key]
        public int ndcID { get; set; }

        [Required]
        [StringLength(20)]
        public string ndcMaLoai { get; set; }

        [Required]
        [StringLength(100)]
        public string ndcTenLoai { get; set; }

        public bool ndcTrangThai { get; set; }

        // Quan hệ 1 - nhiều: 1 Loại có nhiều Sản phẩm
        public virtual ICollection<NdcSan_Pham>? ndcSanPhams { get; set; }
    }
}
