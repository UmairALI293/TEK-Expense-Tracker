using System;
using System.Collections.Generic;
//using TEK_Expense_Tracker;
using System.Data;
using System.Data.SqlClient;


class Program
{
    static void Main(string[] args)
    {
        #region
        //    Expense_Tracker tracker = new Expense_Tracker();

        //    Console.WriteLine("\n   Expense Tracker Menu:");
        //    Console.WriteLine("     1. Add Expense");
        //    Console.WriteLine("     2. View Total Expenses");
        //    Console.WriteLine("     3. View All Expenses");
        //    Console.WriteLine("     4. Exit");

        //    while (true)
        //    {
        //        Console.Write("\n   Enter your choice: ");
        //        string choice = Console.ReadLine();

        //        switch (choice)
        //        {                case "1":
        //                Console.Write("   Enter expense description: ");
        //                string description = Console.ReadLine();
        //                Console.Write("   Enter expense amount: ");
        //                int amount = int.Parse(Console.ReadLine());

        //                tracker.AddExpense(description, amount);
        //                break;
        //            case "2":
        //                tracker.ViewTotalExpense();
        //                break;
        //            case "3":
        //                tracker.ViewAllExpense();
        //                break;
        //            case "4":
        //                Console.WriteLine("Exiting...");
        //                return;
        //            default:
        //                Console.WriteLine("  Invalid choice. Please enter a number from 1 to 4.");
        //                break;
        //        }
        //    }
        #endregion

        Program.Connection();
    }
    static void Connection()
    {
        string cs = "Data Source=UmairA-Lap\\SQLEXPRESS;Initial Catalog=tracker;Integrated Security=true;";
        SqlConnection mycon = null;
        try
        {
            using (mycon = new SqlConnection(cs))
            {
               
                mycon.Open();
                if (mycon.State == ConnectionState.Open)
                {
                    Console.WriteLine("Connection has been created successfully");
                    string query = "select * from expense";
                    SqlCommand cm = new SqlCommand(query, mycon);
                    SqlDataReader dr =  cm.ExecuteReader();
                    Console.WriteLine("Expense_ID  Expense_Name  Expense_Desc  Expense_Amount  Expense_Time");
                    while (dr.Read())
                    {
                        Console.WriteLine(dr["Expense_ID"]+"  "+dr["Expense_Name"] +"  "+dr["Expense_Desc"]+"  "+dr["Expense_Amount"]+"  "+dr["Expense_Time"]);

                    }
                }
               
            }
        }
       catch(SqlException e)
        {
            Console.WriteLine(e.Message);
        }
   
        
    }
}