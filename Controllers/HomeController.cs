using DemoProject.DomainModels;
using DemoProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using static DemoProject.Models.User;

namespace DemoProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;

        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                string RedirectAdminUrl = "/Dashboard/AdminDashboard";
                string RedirectUserUrl = "/Dashboard/UserDashboard";
                try
                {
                    var loggedInUser = _context.Users.Where(a => a.Email == loginModel.Email && a.Password == loginModel.Password).FirstOrDefault();
                    if (loggedInUser != null)
                    {
                        if (loggedInUser.Role == UserRole.Admin)
                        {
                            HttpContext.Session.SetString("IsLogined", loggedInUser.Id.ToString());
                            HttpContext.Session.SetString("Name", loggedInUser.FirstName); // Assuming FirstName is the property for name
                            HttpContext.Session.SetString("Email", loggedInUser.Email);
                            return LocalRedirect(RedirectAdminUrl);
                        }
                        else
                        {
                            HttpContext.Session.SetString("IsLogined", loggedInUser.Id.ToString());
                            HttpContext.Session.SetString("Name", loggedInUser.FirstName); // Assuming FirstName is the property for name
                            HttpContext.Session.SetString("Email", loggedInUser.Email);
                            return LocalRedirect(RedirectUserUrl);
                        }
                    }
                    else
                    {

                        TempData["ErrorMessage"] = "Email or Password is incorrect";
                        var errorMessage = "Email or Password is incorrect";
                        ModelState.AddModelError(string.Empty, errorMessage);
                        return View(loginModel);
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return View(loginModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
