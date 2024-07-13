using Microsoft.AspNetCore.Mvc;

namespace STKDotNetCore.MvcChartApp.Controllers
{
    public class HighChartsController : Controller
    {
        public IActionResult PieChart()
        {
            return View();
        }

        public IActionResult OrganizationChart()
        {
            return View();
        }

        public IActionResult SplineChart()
        {
            return View();
        }
    }
}
