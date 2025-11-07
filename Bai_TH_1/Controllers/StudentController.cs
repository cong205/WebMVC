using Bai_TH_1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.Collections.Generic;

namespace Bai_TH_1.Controllers
{
    public class StudentController : Controller
    {
        private List<Student> listStudents = new List<Student>();

        public StudentController()
        {
            listStudents = new List<Student>()
            {
                new Student() { Id = 101, Name = "Công", Branch = Branch.IT,
                Gender = Gender.Male, IsRegular = true, Address = "A1-2018",
                Email = "cong@g.com" },

                new Student() { Id = 102, Name = "Linh", Branch = Branch.CE,
                Gender = Gender.Female, IsRegular = false, Address = "B2-305",
                Email = "linh@g.com" },

                new Student() { Id = 103, Name = "Huy", Branch = Branch.IT,
                Gender = Gender.Male, IsRegular = true, Address = "C3-210",
                Email = "huy@g.com" },

                new Student() { Id = 104, Name = "Trang", Branch = Branch.EE,
                Gender = Gender.Female, IsRegular = true, Address = "D4-118",
                Email = "trang@g.com" },

                new Student() { Id = 105, Name = "Minh", Branch = Branch.BE,
                Gender = Gender.Male, IsRegular = false, Address = "E5-407",
                Email = "minh@g.com" }
            };
        }

        public IActionResult Index()
        {
            return View(listStudents);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.AllGenders = Enum.GetValues(typeof(Gender)).Cast<Gender>().ToList();

            ViewBag.AllBranches = new List<SelectListItem>()
            {
                new SelectListItem { Text = "IT", Value = Branch.IT.ToString() },
                new SelectListItem { Text = "BE", Value = Branch.BE.ToString() },
                new SelectListItem { Text = "CE", Value = Branch.CE.ToString() },
                new SelectListItem { Text = "EE", Value = Branch.EE.ToString() }
            };

            return View();
        }

        [HttpPost]
        public IActionResult Create(Student s)
        {
            s.Id = listStudents.Last().Id + 1;
            listStudents.Add(s);
            return View("Index", listStudents);
        }
    }
}
