using AspNetCoreGeneratedDocument;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class UserController : Controller
    {
        public IActionResult SaveUser()
        {
            return View(new User());
        }

        [HttpPost]
        public IActionResult SaveUser(User model)
        {
            ViewData["user"] = model;
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            //Do something, e.g. take payment, save to database etc.

            return RedirectToAction("Success");
        }

        public IActionResult Success()
        {
            return View();
        }
    }
}
