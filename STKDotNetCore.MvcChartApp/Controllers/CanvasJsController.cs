using Microsoft.AspNetCore.Mvc;

namespace STKDotNetCore.MvcChartApp.Controllers
{
    public class CanvasJsController : Controller
    {
        public IActionResult LineChart()
        {
            return View();
        }

		public IActionResult AreaChart()
		{
			return View();
		}

        public IActionResult ColumnChart()
        {
            return View();
        }
    }
}
