using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STKDotNetCore.RestApi
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
