using System.Data;
using System.Data.SqlClient;

namespace TEK_Expense_Tracker
{
        public class DBConnection
        {
            private static string connectionString = "Data Source=UmairA-Lap\\SQLEXPRESS;Initial Catalog=tracker;Integrated Security=true;";
            public static SqlConnection GetConnection()
            {
                SqlConnection connection = new SqlConnection(connectionString);
                return connection;
            }
        }
    

}
