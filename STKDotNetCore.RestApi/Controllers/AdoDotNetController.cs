using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using STKDotNetCore.RestApiWithNLayer.Models;
using System.Data;
using System.Data.SqlClient;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace STKDotNetCore.RestApiWithNLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdoDotNetController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetBlogs()
        {
            string query = "select * from tbl_blog";
            SqlConnection connection = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);

            connection.Open();
            Console.WriteLine("Connection open.");

            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);

            connection.Close();

            //List<BlogModel> lst = new List<BlogModel>();
            //foreach (DataRow dr in dt.Rows)
            //{
            //    //    BlogModel blog = new BlogModel();
            //    //    blog.BlogId = Convert.ToInt32(dr["BlogId"]);
            //    //    blog.BlogTitle = Convert.ToString(dr["BlogTitle"]);
            //    //    blog.BlogAuthor = Convert.ToString(dr["BlogAuthor"]);
            //    //    blog.BlogContent = Convert.ToString(dr["BlogContent"]);

            //    BlogModel blog = new BlogModel
            //    {
            //        BlogId = Convert.ToInt32(dr["BlogId"]),
            //        BlogTitle = Convert.ToString(dr["BlogTitle"]),
            //        BlogAuthor = Convert.ToString(dr["BlogAuthor"]),
            //        BlogContent = Convert.ToString(dr["BlogContent"])
            //    };
            //    lst.Add(blog);
            //}

            List<BlogModel> lst = dt.AsEnumerable().Select(dr => new BlogModel
            {
                BlogId = Convert.ToInt32(dr["BlogId"]),
                BlogTitle = Convert.ToString(dr["BlogTitle"]),
                BlogAuthor = Convert.ToString(dr["BlogAuthor"]),
                BlogContent = Convert.ToString(dr["BlogContent"])
            }).ToList();

            return Ok(lst);
        }

        [HttpGet("{id}")]
        public IActionResult GetBlog(int id)
        {
            string query = "select * from tbl_blog where BlogId = @BlogId";
            SqlConnection connection = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);

            connection.Open();
            Console.WriteLine("Connection open.");

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogID", id);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);

            connection.Close();

            if (dt.Rows.Count == 0)
            {
                return NotFound("No data found.");
            }

            DataRow dr = dt.Rows[0];
            var item = new BlogModel
            {
                BlogId = Convert.ToInt32(dr["BlogId"]),
                BlogTitle = Convert.ToString(dr["BlogTitle"]),
                BlogAuthor = Convert.ToString(dr["BlogAuthor"]),
                BlogContent = Convert.ToString(dr["BlogContent"])
            };

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
            SqlConnection connection = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);

            connection.Open();

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogTitle", blog.BlogTitle);
            cmd.Parameters.AddWithValue("@BlogAuthor", blog.BlogAuthor);
            cmd.Parameters.AddWithValue("@BlogContent", blog.BlogContent);
            int result = cmd.ExecuteNonQuery();

            connection.Close();

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
            SqlConnection connection = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);

            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogID", id);
            cmd.Parameters.AddWithValue("@BlogTitle", blog.BlogTitle);
            cmd.Parameters.AddWithValue("@BlogAuthor", blog.BlogAuthor);
            cmd.Parameters.AddWithValue("@BlogContent", blog.BlogContent);
            int result = cmd.ExecuteNonQuery();

            connection.Close();

            string message = result > 0 ? "Updating Successful." : "Updating Failed.";

            return Ok(message);
        }

        //[HttpPatch("{id}")]
        //public IActionResult PatchBlog(int id, BlogModel blog)
        //{
        //    string query = "select * from Tbl_Blog where BlogId = @BlogId";

        //    SqlConnection connection = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);

        //    connection.Open();

        //    SqlCommand cmd = new SqlCommand(query, connection);
        //    cmd.Parameters.AddWithValue("@BlogId", id);
        //    var count = cmd.ExecuteScalar();
        //    if (count == null || count == DBNull.Value)
        //    {
        //        return NotFound("No data found.");
        //    }

        //    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
        //    DataTable dt = new DataTable();
        //    dataAdapter.Fill(dt);

        //    List<BlogModel> lst = new List<BlogModel>();
        //    if (dt.Rows.Count == 0)
        //    {
        //        var response = new { IsSuccess = false, Message = "No data found." };
        //        return NotFound(response);
        //    }

        //    DataRow dr = dt.Rows[0];

        //    BlogModel item = new BlogModel
        //    {
        //        BlogId = Convert.ToInt32(dr["BlogId"]),
        //        BlogTitle = Convert.ToString(dr["BlogTitle"]),
        //        BlogAuthor = Convert.ToString(dr["BlogAuthor"]),
        //        BlogContent = Convert.ToString(dr["BlogContent"]),
        //    };
        //    lst.Add(item);

        //    string conditions = "";
        //    List<SqlParameter> parameters = new List<SqlParameter>();

        //    #region Patch Validation Conditions

        //    if (!string.IsNullOrEmpty(blog.BlogTitle))
        //    {
        //        conditions += " [BlogTitle] = @BlogTitle, ";
        //        parameters.Add(new SqlParameter("@BlogTitle", SqlDbType.NVarChar) { Value = blog.BlogTitle });
        //        item.BlogTitle = blog.BlogTitle;
        //    }

        //    if (!string.IsNullOrEmpty(blog.BlogAuthor))
        //    {
        //        conditions += " [BlogAuthor] = @BlogAuthor, ";
        //        parameters.Add(new SqlParameter("@BlogAuthor", SqlDbType.NVarChar) { Value = blog.BlogAuthor });
        //        item.BlogAuthor = blog.BlogAuthor;
        //    }

        //    if (!string.IsNullOrEmpty(blog.BlogContent))
        //    {
        //        conditions += " [BlogContent] = @BlogContent, ";
        //        parameters.Add(new SqlParameter("@BlogContent", SqlDbType.NVarChar) { Value = blog.BlogContent });
        //        item.BlogContent = blog.BlogContent;
        //    }

        //    if (conditions.Length == 0)
        //    {
        //        var response = new { IsSuccess = false, Message = "No data to update." };
        //        return NotFound(response);
        //    }

        //    #endregion

        //    conditions = conditions.TrimEnd(',', ' ');
        //    query = $@"UPDATE [dbo].[Tbl_Blog] SET {conditions} WHERE BlogId = @BlogId";

        //    using SqlCommand cmd2 = new SqlCommand(query, connection);
        //    cmd2.Parameters.AddWithValue("@BlogId", id);
        //    cmd2.Parameters.AddRange(parameters.ToArray());

        //    int result = cmd2.ExecuteNonQuery();
        //    connection.Close();

        //    string message = result > 0 ? "Patch Updating Successful." : "Patch Updating Failed.";
        //    return Ok(message);
        //}

        [HttpPatch("{id}")]
        public IActionResult PatchBlog(int id, BlogModel blog)
        {
            string query = "SELECT * FROM Tbl_Blog WHERE BlogId = @BlogId";
            SqlConnection connection = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);

            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogId", id);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);            

            if (dt.Rows.Count == 0)
            {
                return NotFound("No data found.");
            }

            DataRow dr = dt.Rows[0];
            BlogModel item = new BlogModel
            {
                BlogId = Convert.ToInt32(dr["BlogId"]),
                BlogTitle = Convert.ToString(dr["BlogTitle"]),
                BlogAuthor = Convert.ToString(dr["BlogAuthor"]),
                BlogContent = Convert.ToString(dr["BlogContent"])
            };

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

            query = @"UPDATE Tbl_Blog
                           SET BlogTitle = @BlogTitle,
                               BlogAuthor = @BlogAuthor,
                               BlogContent = @BlogContent
                           WHERE BlogId = @BlogId";

            
            cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogTitle", item.BlogTitle);
            cmd.Parameters.AddWithValue("@BlogAuthor", item.BlogAuthor);
            cmd.Parameters.AddWithValue("@BlogContent", item.BlogContent);
            cmd.Parameters.AddWithValue("@BlogId", item.BlogId);
            int result = cmd.ExecuteNonQuery();
            connection.Close();

            string message = result > 0 ? "Patch Updating Successful." : "Patch Updating Failed.";

            return Ok(message);
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteBlog(int id)
        {
            string query = @"delete from Tbl_Blog WHERE BlogId= @BlogId";
            SqlConnection connection = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogID", id);
            int result = cmd.ExecuteNonQuery();

            connection.Close();

            string message = result > 0 ? "Deleting Successful." : "Deleting Failed.";

            return Ok(message);
        }
    }
}

