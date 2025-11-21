
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Bai_TH_1.Models
{
    public class Student
    {
        public  int Id { get; set; } // Mã sinh viên
        [Required(ErrorMessage = "Name là bắt buộc")]
        public string? Name { get; set; } // họ tên
        [Required(ErrorMessage = "Email là bắt buộc")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[A-Za-z]{2,4}")]
        public string? Email { get; set; } // email
        [StringLength(20, MinimumLength =3)]
        [Required]
        public string? Password { get; set; } // Mật khẩu
        public Branch Branch { get; set; }// Ngành học
        [Required]
        public Gender Gender { get; set; }// Giới tính
        public bool IsRegular { get; set; }//Hệ: true-chính qui , false-phi cq 
        [DataType(DataType.MultilineText)]
        [Required]
        public string? Address { get; set; }//Địa chỉ
        [Range(typeof(DateTime), "1/1/1990", "1/1/2006")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime DateOfBorth { get; set; }// Ngày sinh
        [Display(Name = "Điểm")]
        [Required(ErrorMessage = "Điểm là bắt buộc")]
        [Range(0.0, 10.0, ErrorMessage = "Điểm phải nằm trong khoảng từ 0.0 đến 10.0")]
        public double Score { get; set; }
    }
}
