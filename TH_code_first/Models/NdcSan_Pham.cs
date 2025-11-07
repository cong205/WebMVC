using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TH_code_first.Models
{
    public class NdcSan_Pham
    {
        [Key]
        public int ndcID { get; set; }

        [Required]
        [StringLength(20)]
        public string ndcMaSanPham { get; set; }

        [Required]
        [StringLength(100)]
        public string ndcTenSanPham { get; set; }

        [StringLength(255)]
        public string ndcHinhAnh { get; set; }

        public int ndcSoLuong { get; set; }

        public decimal ndcDonGia { get; set; }

        public bool ndcTrangThai { get; set; }

        [Display(Name = "Loại sản phẩm")]
        [ForeignKey("ndcLoai_San_Pham")]
        public int ndcMaLoai { get; set; }

        public virtual NdcLoai_San_Pham? ndcLoai_San_Pham { get; set; }
    }
}
