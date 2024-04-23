using System.Data.SqlClient;
using System.Data;
using TEK_Expense_Tracker;

public class ExpenseDAC
{
    public void GetExpense()
    {
        using (SqlConnection connection = DBConnection.GetConnection())
        {
            try
            {
                connection.Open();
                if (connection.State == ConnectionState.Open)
                {
                    Console.WriteLine("   Expense List   ");
                    string query = "SELECT * FROM expense";

                    SqlCommand command = new SqlCommand();
                    command.CommandText = query;
                    command.CommandType = CommandType.Text;
                    command.Connection = connection;
                    command.Parameters.Clear();

                    SqlDataReader reader = command.ExecuteReader();

                    Console.WriteLine("  ID   Name   Desc   Amount   Time");
                    while (reader.Read())
                    {
                        Console.WriteLine("   " +$"{reader["Expense_ID"]}  {reader["Expense_Name"]}  {reader["Expense_Desc"]}  {reader["Expense_Amount"]}  {reader["Expense_Time"]}");
                    }
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

    public void AddExpense(int id, string name, string desc, decimal amount, DateTime time)
    {
        using (SqlConnection connection = DBConnection.GetConnection())
        {
            try
            {
                connection.Open();
                if (connection.State == ConnectionState.Open)
                {
                    string query = "INSERT INTO expense (Expense_ID, Expense_Name, Expense_Desc, Expense_Amount, Expense_Time) VALUES (@ID, @Name, @Desc, @Amount, @Time)";

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
                            Console.WriteLine("   Expense added successfully.");
                        }
                        else
                        {
                            Console.WriteLine("   Failed to add expense.");
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

    public void UpdateExpense(int id, string name, string desc, decimal amount, DateTime time)
    {
        using (SqlConnection connection = DBConnection.GetConnection())
        {
            try
            {
                connection.Open();
                if (connection.State == ConnectionState.Open)
                {
                    string query = "UPDATE  expense set Expense_ID=@ID, Expense_Name=@Name, Expense_Desc=@Desc, Expense_Amount=@Amount, Expense_Time=@Time where Expense_ID=@ID ";

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
   


