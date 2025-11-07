using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace ndc_231230723_de01.Models
{
    [Table("NdcComputer")]
    public class NdcComputer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ndcComId { get; set; }
        [Display(Name = "Tên")]
        [StringLength(30)]
        public string ndcComName { get; set; }
        [Display(Name = "Giá")]
        public long ndcComPrice { get; set; }
        [Display(Name = "Ảnh")]
        [StringLength(30)]

        public string ndcComImage { get; set; }
        [Display(Name = "Trạng thái")]
        public bool ndcComStatus { get; set; }
    }
}
