using Microsoft.AspNetCore.Mvc;

namespace STKDotNetCore.MiddlewareApp.Controllers
{
    public class LogoutController : Controller
    {
        public IActionResult Index()
        {
            HttpContext.Session.Clear();
            return Redirect("/");
        }
    }
}
