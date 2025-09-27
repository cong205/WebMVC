using System.ComponentModel.DataAnnotations;

namespace EmployeeMVC.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required, Display(Name = "Full Name")]
        public required string FullName { get; set; }

        [Required]
        public required string Gender { get; set; }

        [Phone]
        public required string Phone { get; set; }

        [EmailAddress]
        public required string Email { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Salary { get; set; }

        public bool Status { get; set; }
    }
}
