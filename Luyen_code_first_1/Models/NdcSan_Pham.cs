using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Luyen_code_first_1.Models
{
    [Table("NdcSan_Pham")]
    public class NdcSan_Pham
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ndcId { get; set; }
        [Display(Name = "Mã Sản phẩm")]
        [StringLength(10)]
        public string ndcMaSanPham { get; set; }
        [Display(Name = "Tên sản phẩm")]
        [StringLength(100)]
        public string ndcTenSanPham { get; set; }
        [Display(Name = "Hình ảnh")]
        [StringLength(100)]
        public string ndcHinhAnh { get; set; }
        [Display(Name = "Số lượng")]
        public int ndcSoLuong { get; set; }
        [Display(Name = "Đơn giá")]
        public decimal ndcDonGia { get; set; }
        [Display(Name = "Mã loại")]
        [ForeignKey(nameof(ndcLoai_San_Pham))]
        public long ndcMaLoai { get; set; }
        [Display(Name = "Trạng thái")]

        public bool ndcTrangThai { get; set; }
        [ValidateNever]
        [Display(Name = "Tên loại ")]
        public NdcLoai_San_Pham ndcLoai_San_Pham { get; set; }
    }
}
