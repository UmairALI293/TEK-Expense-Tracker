using System.Data.SqlClient;
using System.Data;
using TEK_Expense_Tracker;

public class ExpenseDAC
{
    private object id;

    public void GetExpense()
    {
        using (SqlConnection connection = DBConnection.GetConnection())
        {
            try
            {
                #region without adapter
                //connection.Open();
                //if (connection.State == ConnectionState.Open)
                //{
                //    Console.WriteLine("   Expense List   ");
                //    //string query = "SELECT * FROM expense";
                //    string query = "GetExpRecord";
                //    SqlCommand command = new SqlCommand();
                //    command.CommandText = query;
                //    //command.CommandType = CommandType.Text;
                //    command.CommandType = CommandType.StoredProcedure;
                //    command.Connection = connection;
                //    command.Parameters.Clear();

                //    SqlDataReader reader = command.ExecuteReader();

                //    Console.WriteLine("   ID      Name       Desc       Amount      Time");
                //    while (reader.Read())
                //    {
                //         Console.WriteLine($"   {reader["Expense_ID"],-8}{reader["Expense_Name"],-10} {reader["Expense_Desc"],-10} {reader["Expense_Amount"],-10} {reader["Expense_Time"],-10}");                       
                //    }                   
                //}
                #endregion

                //sqldata adapter
                string query = "GetExpRecord";
                SqlDataAdapter ad = new SqlDataAdapter(query, connection);
                ad.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                ad.Fill(ds);
                Console.WriteLine("   ID      Name       Desc       Amount      Time");
                foreach (DataRow row in ds.Tables[0].Rows)
                {                
                        Console.WriteLine($"   {row["ExpID"],-8}{row["ExpName"],-10} {row["ExpDesc"],-10} {row["ExpAmount"],-10} {row["ExpDate"],-10}");               
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                connection.Close();
            }
        }
    }

    public void AddExpense(string name, string desc, decimal amount)
    {
        
        using (SqlConnection connection = DBConnection.GetConnection())
        {
            try
            {
                #region without adapter
                //connection.Open();
                //if (connection.State == ConnectionState.Open)
                //{

                //    string query = "INSERT INTO expense (ExpName, ExpDesc, ExpAmount) VALUES (@Name, @Desc, @Amount)";
                //    using (SqlCommand command = new SqlCommand(query, connection))
                //    {
                //        command.CommandType = CommandType.StoredProcedure;
                //        command.Parameters.AddWithValue("@ExpName", name);
                //        command.Parameters.AddWithValue("@ExpDesc", desc);
                //        command.Parameters.AddWithValue("@EXPAmount", amount);
                //        int rowsAffected = command.ExecuteNonQuery();
                //        if (rowsAffected > 0)
                //        {
                //            Console.WriteLine("   Expense added successfully.");
                //        }
                //        else
                //        {
                //            Console.WriteLine("   Failed to add expense.");
                //        }
                //    }
                //}
                #endregion
                string query = "AddExp";
                SqlDataAdapter add = new SqlDataAdapter(query, connection);
                add.SelectCommand.CommandType = CommandType.StoredProcedure;
                add.SelectCommand.Parameters.AddWithValue("@ExpName", name);
                add.SelectCommand.Parameters.AddWithValue("@ExpDesc", desc);
                add.SelectCommand.Parameters.AddWithValue("@EXPAmount", amount);
                DataSet ds = new DataSet();
                add.Fill(ds);
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }

    public void UpdateExpense(int id, string name, string desc, decimal amount, DateTime time)
    {
        using (SqlConnection connection = DBConnection.GetConnection())
        {
            try
            {
                connection.Open();
                if (connection.State == ConnectionState.Open)
                {
                    string query = "UPDATE  expense set Expense_Name=@Name, Expense_Desc=@Desc, Expense_Amount=@Amount, Expense_Time=@Time where Expense_ID=@ID ";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ID", id);
                        command.Parameters.AddWithValue("@Name", name);
                        command.Parameters.AddWithValue("@Desc", desc);
                        command.Parameters.AddWithValue("@Amount", amount);
                        command.Parameters.AddWithValue("@Time", time);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("   Expense Updated successfully.");
                        }
                        else
                        {
                            Console.WriteLine("   Failed to Update expense.");
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
    public void GetTotalOfExpense()
    {
        using (SqlConnection connection = DBConnection.GetConnection())
        {
            try
            {
                connection.Open();
                if (connection.State == ConnectionState.Open)
                {
                    Console.WriteLine("   Total Expenses   ");
                    string query = "SELECT SUM(Expense_Amount) FROM expense";

                    SqlCommand command = new SqlCommand();
                    command.CommandText = query;
                    command.CommandType = CommandType.Text;
                    command.Connection = connection;
                    command.Parameters.Clear();

                    int TotalExp = Convert.ToInt32(command.ExecuteScalar());
                    Console.WriteLine(TotalExp);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
   


