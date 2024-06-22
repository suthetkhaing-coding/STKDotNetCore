using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using STKDotNetCore.MvcApp.Db;
using STKDotNetCore.MvcApp.Models;

namespace STKDotNetCore.MvcApp.Controllers
{
    public class BlogController : Controller
    {
        private readonly AppDbContext _db;

        public BlogController(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            var lst = await _db.Blogs.ToListAsync();
            return View(lst);
        }

        [ActionName("Create")]
        public IActionResult BlogCreate()
        {
            return View("BlogCreate");
        }

        [HttpPost]
        [ActionName("Save")]
        public async Task<IActionResult> BlogCreate(BlogModel blog)
        {
            _db.Blogs.Add(blog);
            var result = await _db.SaveChangesAsync();
            //return View("BlogCreate");
            return Redirect("/Blog");
        }
    }
}
