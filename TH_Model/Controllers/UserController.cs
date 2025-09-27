using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TH_Model.Models;

namespace TH_Model.Controllers
{
    public class UserController : Controller
    {
        private static List<User> users = new List<User>
        {
            new User { Id = 1, Name = "Nguyen Van A", Address = "Hanoi", Email = "a@example.com" },
            new User { Id = 2, Name = "Tran Thi B", Address = "HCM", Email = "b@example.com" },
            new User { Id = 3, Name = "Le Van C", Address = "Da Nang", Email = "c@example.com" }
        };
        public IActionResult Index()
        {
            ViewBag.Users = users;  
            ViewBag.Title = "Danh sách người dùng";
            return View();
        }

        public IActionResult Details(int id)
        {
            var user = users.Find(u => u.Id == id);
            if (user == null) return NotFound();
            ViewBag.User = user;
            return View();
        }
    }
}
