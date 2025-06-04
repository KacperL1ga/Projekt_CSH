using MySql.Data.MySqlClient;
using System.Configuration;


namespace BankApp
{
    public static class DatabaseContex
    {
        private static readonly string ConnectionString = ConfigurationManager.ConnectionStrings["BankAppConnection"].ConnectionString;
        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }
    }
}
