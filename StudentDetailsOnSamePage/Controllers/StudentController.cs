using Microsoft.AspNetCore.Mvc;
using StudentDetailsOnSamePage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentDetailsOnSamePage.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _db;

        public StudentController(ApplicationDbContext db)
        {
            _db = db;
        }



        public IActionResult Index()
        {
            
            return View(_db.students.ToList());
        }

        [HttpGet]
        public IActionResult Register()
        {
            ViewBag.Course = new List<string>() { "Please Select Course", "BCA", "BCOM", "BSCIT", "BTECH"};
            
          
            return View();
        }

        [HttpPost]
        public IActionResult Register(Student std)
        {
            if (ModelState.IsValid)
            {
               /* _db.students.Add(std);
                _db.SaveChanges();*/

                TempData["first"] = std.FirstName;
                TempData["last"] = std.LastName;
                TempData["gender"] = std.Gender;
                TempData["mobile"] = std.Mobile;
                TempData["email"] = std.EmailId;
                TempData["fees"] = std.Fees;
                TempData["course"] = std.Course;
                TempData["city"] = std.City;
                TempData["address"] = std.Address;

                var cal = (std.Fees * 10);
                TempData["totalfees"] = cal;
                return RedirectToAction("Register");
            }

            else
            {

                return View();
            }
        }


        public IActionResult ShowStudent()
        {
          
            return View(_db.students.ToList());
        }

    }
}
