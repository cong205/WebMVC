using System.ComponentModel.DataAnnotations;
namespace TH_Employee.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string FullName { get; set; }

        [Required]
        public string Gender { get; set; } // Male / Female

        [Phone]
        public string Phone { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Salary { get; set; }

        public bool Status { get; set; } // true = Active, false = Inactive
    }
}
