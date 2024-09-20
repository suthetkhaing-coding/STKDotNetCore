using Microsoft.AspNetCore.Mvc;
using STKDotNetCore.MiddlewareApp.Models;

namespace STKDotNetCore.MiddlewareApp.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(LoginModel requestModel)
        {
            HttpContext.Session.SetString("name", requestModel.UserName);
            return Redirect("/Home");
        }
    }
}
