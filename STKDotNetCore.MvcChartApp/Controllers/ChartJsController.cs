using Microsoft.AspNetCore.Mvc;

namespace STKDotNetCore.MvcChartApp.Controllers
{
    public class ChartJsController : Controller
    {
        public IActionResult ExampleChart()
        {
            return View();
        }

        public IActionResult InterpolationLineChart()
        {
            return View();
        }

        public IActionResult LineChart()
        {
            return View();
        }

        public IActionResult HorizontalBarChart()
        {
            return View();
        }
    }
}
