using Microsoft.EntityFrameworkCore;
using STKDotNetCore.BlazorServer.Models;

namespace STKDotNetCore.BlazorServer.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<BlogModel> Blogs { get; set; }
    }
}