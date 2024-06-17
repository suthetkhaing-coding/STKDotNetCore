using Microsoft.EntityFrameworkCore;
using STKDotNetCore.MinimalApi.Db;
using STKDotNetCore.MinimalApi.Models;

namespace STKDotNetCore.MinimalApi.Features.Blog
{
    public static class BlogService
    {
        public static IEndpointRouteBuilder MapBlogs(this IEndpointRouteBuilder app)
        {
            app.MapGet("api/Blog", async (AppDbContext db) =>
            {
                var lst = await db.Blogs.AsNoTracking().ToListAsync();
                return Results.Ok(lst);
            });

            app.MapPost("api/Blog", async (AppDbContext db, BlogModel blog) =>
            {
                db.Blogs.Add(blog);
                int result = await db.SaveChangesAsync();

                string message = result > 0 ? "Saving Successful." : "Saving Failed.";
                return Results.Ok(message);
            });

            app.MapPut("api/Blog/{id}", async (AppDbContext db, int id, BlogModel blog) =>
            {
                var item = db.Blogs.FirstOrDefault(x => x.BlogId == id);
                if (item is null)
                {
                    return Results.Ok("No data found.");
                }

                item.BlogTitle = blog.BlogTitle;
                item.BlogAuthor = blog.BlogAuthor;
                item.BlogContent = blog.BlogContent;
                int result = await db.SaveChangesAsync();

                string message = result > 0 ? "Updating Successful." : "Updating Failed.";
                return Results.Ok(message);
            });

            app.MapDelete("api/Blog/{id}", async (AppDbContext db, int id) =>
            {
                var item = db.Blogs.FirstOrDefault(x => x.BlogId == id);
                if (item is null)
                {
                    return Results.Ok("No data found.");
                }

                db.Blogs.Remove(item);
                int result = await db.SaveChangesAsync();

                string message = result > 0 ? "Deleting Successful." : "Deleting Failed.";
                return Results.Ok(message);
            });

            return app;
        }
    }
}
