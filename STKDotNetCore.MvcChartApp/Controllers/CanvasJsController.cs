using Microsoft.AspNetCore.Mvc;

namespace STKDotNetCore.MvcChartApp.Controllers
{    
    public class CanvasJsController : Controller
    {
        private readonly ILogger<CanvasJsController> _logger;

        public CanvasJsController(ILogger<CanvasJsController> logger)
        {
            _logger = logger;
        }

        public IActionResult LineChart()
        {
            _logger.LogInformation("Line Chart...");
            return View();
        }

		public IActionResult AreaChart()
		{
            _logger.LogInformation("Area Chart...");
            return View();
		}

        public IActionResult ColumnChart()
        {
            _logger.LogInformation("Column Chart...");
            return View();
        }
    }
}
