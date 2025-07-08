using System.Data.SqlClient;

namespace CRUDApplication
{
    public static class Database
    {
        private static readonly string connectionString = @"Data Source=.;Initial Catalog=CoDB;Integrated Security=True;TrustServerCertificate=True";

        public static SqlConnection GetConnection()
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            return conn;
        }
    }
}