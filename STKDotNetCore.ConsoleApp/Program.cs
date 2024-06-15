using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using STKDotNetCore.ConsoleApp.AdoDotNetExamples;
using STKDotNetCore.ConsoleApp.DapperExamples;
using STKDotNetCore.ConsoleApp.EFCoreExamples;
using STKDotNetCore.ConsoleApp.Services;
using System.Data;
using System.Data.SqlClient;

Console.WriteLine("Hello, World!");

//SqlConnectionStringBuilder stringBuilder = new SqlConnectionStringBuilder();
//stringBuilder.DataSource = "HO-1-091\\MSSQLSERVERS";
//stringBuilder.InitialCatalog = "STKDotNetCore";
//stringBuilder.UserID = "sa";
//stringBuilder.Password = "Ami123!@#";
//SqlConnection connection = new SqlConnection(stringBuilder.ConnectionString);
////SqlConnection connection = new SqlConnection("Data Source=HO-1-091\\MSSQLSERVERS;Initial Catalog=STKDotNetCore;User Id=sa;Password=Ami123!@#;");

//connection.Open();
//Console.WriteLine("Connection open.");

//string query = "select * from tbl_blog";
//SqlCommand cmd = new SqlCommand(query, connection); 
//SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
//DataTable dt = new DataTable();
//sqlDataAdapter.Fill(dt);

//connection.Close();
//Console.WriteLine("Connection close.");

//foreach (DataRow dr in dt.Rows)
//{
//    Console.WriteLine("Blog Id => " + dr["BlogId"]);
//    Console.WriteLine("Blog Title => " + dr["BlogTitle"]);
//    Console.WriteLine("Blog Author => " + dr["BlogAuthor"]);
//    Console.WriteLine("Blog Content => " + dr["BlogContent"]);
//    Console.WriteLine("--------------------------------------");
//}

//AdoDotNetExample adoDotNetExample = new AdoDotNetExample();
//adoDotNetExample.Read();
//adoDotNetExample.Create("title", "author", "content");
//adoDotNetExample.Update(11, "test title", "test author", "test content");
//adoDotNetExample.Delete(11);
//adoDotNetExample.Edit(11);
//adoDotNetExample.Edit(1);

//DapperExample dapper = new DapperExample();
//dapper.Run();

//EFCoreExample coreExample = new EFCoreExample();
//coreExample.Run();

var connectionString = ConnectionStrings.SqlConnectionStringBuilder.ConnectionString;
var sqlConnectionStringBuilder = new SqlConnectionStringBuilder(connectionString);
var serviceProvider = new ServiceCollection()
    .AddScoped(n => new AdoDotNetExample(sqlConnectionStringBuilder))
    .AddScoped(n => new DapperExample(sqlConnectionStringBuilder))
    .AddDbContext<AppDbContext>(opt =>
    {
        opt.UseSqlServer(connectionString);
    })
    .AddScoped<EFCoreExample>()
    .BuildServiceProvider();

//AppDbContext db = serviceProvider.GetRequiredService<AppDbContext>();

//var adoDotNetExample = serviceProvider.GetRequiredService<AdoDotNetExample>();
//adoDotNetExample.Read();

//var dapperExample = serviceProvider.GetRequiredService<DapperExample>();
//dapperExample.Run();

var efCoreExample = serviceProvider.GetRequiredService<EFCoreExample>();
efCoreExample.Run();

Console.ReadLine();


