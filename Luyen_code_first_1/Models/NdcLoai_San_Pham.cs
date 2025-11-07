using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Luyen_code_first_1.Models
{
    [Table("NdcLoai_San_Pham")]
    public class NdcLoai_San_Pham
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ndcId { get; set; }

        [Display(Name = "Mã loại")]
        [StringLength(10)]

        public string ndcMaLoai { get; set; }
        [Display(Name = "Tên loại")]
        [StringLength(100)]
        public string ndcTenLoai { get; set; }

        [Display(Name = "Trạng thái")]
        public bool ndcTrangThai { get; set; }

        public ICollection<NdcSan_Pham>? ndcSan_Phams { get; set; }


    }
}
