using DemoProject.DomainModels;
using DemoProject.DTO;
using DemoProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using static DemoProject.Models.User;

namespace DemoProject.Controllers
{
    public class DashboardController : Controller
    {
        private readonly AppDbContext _context;

        public IActionResult AdminDashboard()
        {
            var user = new User
            {
                Id = Convert.ToInt32(HttpContext.Session.GetString("IsLogined")),
                FirstName = HttpContext.Session.GetString("Name"),
                Email = HttpContext.Session.GetString("Email")
            };

            return View(user);

        }


        public IActionResult UserDashboard()
        {
            var user = new User
            {
                Id = Convert.ToInt32(HttpContext.Session.GetString("IsLogined")),
                FirstName = HttpContext.Session.GetString("Name"),
                Email = HttpContext.Session.GetString("Email")
            };

            return View(user);
        }


    }
}
