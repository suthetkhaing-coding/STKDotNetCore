using System.Data.SqlClient;


namespace STKDotNetCore.NLayer.DataAccess
{
    internal static class ConnectionStrings
    {
        public static SqlConnectionStringBuilder SqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = "HO-1-091\\MSSQLSERVERS",
            InitialCatalog = "STKDotNetCoreDb",
            UserID = "sa",
            Password = "Ami123!@#",
            TrustServerCertificate = true
        };
    }
}
