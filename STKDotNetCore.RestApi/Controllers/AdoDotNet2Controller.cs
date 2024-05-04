using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using STKDotNetCore.RestApi.Models;
using System.Data;
using System.Data.SqlClient;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using STKDotNetCore.Shared;
using System.Reflection.Metadata;

namespace STKDotNetCore.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdoDotNet2Controller : ControllerBase
    {
        private readonly AdoDotNetService _adoDotNetService = new AdoDotNetService(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
        [HttpGet]
        public IActionResult GetBlogs()
        {
            string query = "select * from tbl_blog";
            var lst = _adoDotNetService.Query<BlogModel>(query);

            return Ok(lst);
        }

        [HttpGet("{id}")]
        public IActionResult GetBlog(int id)
        {
            string query = "select * from tbl_blog where BlogId = @BlogId";

            //AdoDotNetParameter[] parameters = new AdoDotNetParameter[1];
            //parameters[0] = new AdoDotNetParameter("@BlogID", id);
            //var item = _adoDotNetService.Query<BlogModel>(query, parameters);

            var item = _adoDotNetService.QueryFirstOrDefault<BlogModel>(query, new AdoDotNetParameter("@BlogID", id));

            if (item is null)
            {
                return NotFound("No data found.");
            }
           
            return Ok(item);
        }

        [HttpPost]
        public IActionResult CreateBlog(BlogModel blog)
        {
            string query = @"INSERT INTO [dbo].[Tbl_Blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent])
     VALUES
           (@BlogTitle 
           ,@BlogAuthor 
           ,@BlogContent)";
            
            int result = _adoDotNetService.Execute(query, 
                new AdoDotNetParameter("@BlogTitle", blog.BlogTitle),
                new AdoDotNetParameter("@BlogAuthor", blog.BlogAuthor),
                new AdoDotNetParameter("@BlogContent", blog.BlogContent)
                );

            string message = result > 0 ? "Saving Successful." : "Saving Failed.";
            return Ok(message);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBlog(int id, BlogModel blog)
        {
            string query = @"UPDATE [dbo].[Tbl_Blog]
   SET [BlogTitle] = @BlogTitle, 
      [BlogAuthor] = @BlogAuthor,
      [BlogContent] = @BlogContent
 WHERE BlogId= @BlogId";
            int result = _adoDotNetService.Execute(query,
                new AdoDotNetParameter("@BlogID", id),
                new AdoDotNetParameter("@BlogTitle", blog.BlogTitle),
                new AdoDotNetParameter("@BlogAuthor", blog.BlogAuthor),
                new AdoDotNetParameter("@BlogContent", blog.BlogContent)
                );

            string message = result > 0 ? "Updating Successful." : "Updating Failed.";

            return Ok(message);
        }

        [HttpPatch("{id}")]
        public IActionResult PatchBlog(int id, BlogModel blog)
        {
            string query = "select * from Tbl_Blog where BlogId = @BlogId";

            var item = _adoDotNetService.QueryFirstOrDefault<BlogModel>(query, new AdoDotNetParameter("@BlogID", id));

            if (item is null)
            {
                return NotFound("No data found.");
            }

            if (!string.IsNullOrEmpty(blog.BlogTitle))
            {
                item.BlogTitle = blog.BlogTitle;
            }

            if (!string.IsNullOrEmpty(blog.BlogAuthor))
            {
                item.BlogAuthor = blog.BlogAuthor;
            }

            if (!string.IsNullOrEmpty(blog.BlogContent))
            {
                item.BlogContent = blog.BlogContent;
            }

            query = @"UPDATE [dbo].[Tbl_Blog]
                           SET [BlogTitle] = @BlogTitle,
                               [BlogAuthor] = @BlogAuthor,
                               [BlogContent] = @BlogContent
                           WHERE BlogId = @BlogId";

            int result = _adoDotNetService.Execute(query,
                                                   new AdoDotNetParameter("@BlogTitle", item.BlogTitle),
                                                   new AdoDotNetParameter("@BlogAuthor", item.BlogAuthor),
                                                   new AdoDotNetParameter("@BlogContent", item.BlogContent),
                                                   new AdoDotNetParameter("@BlogId", id));

            string message = result > 0 ? "Patch Updating Successful." : "Patch Updating Failed.";
            return Ok(message);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBlog(int id)
        {
            string query = @"delete from Tbl_Blog WHERE BlogId= @BlogId";

            int result = _adoDotNetService.Execute(query, new AdoDotNetParameter("@BlogID", id));

            string message = result > 0 ? "Deleting Successful." : "Deleting Failed.";

            return Ok(message);
        }

    }
}

