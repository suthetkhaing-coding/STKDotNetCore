using STKDotNetCore.ConsoleAppEFCore.Databases.Models;

AppDbContext db = new AppDbContext();
db.TblPieCharts.ToList();