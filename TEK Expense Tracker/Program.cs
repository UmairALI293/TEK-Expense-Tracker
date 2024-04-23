using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TEK_Expense_Tracker;

class Program
{
    static void Main(string[] args)
    {
        #region
        //Expense_Tracker tracker = new Expense_Tracker();

        Console.WriteLine("\n   Expense Tracker Menu:");
        Console.WriteLine("     1. Add Expense");
        Console.WriteLine("     2. View All Expenses");
        Console.WriteLine("     3. View Total of Expenses");
        Console.WriteLine("     4. Exit");
        ExpenseDAC expenseDAC = new ExpenseDAC();


        

        while (true)
        {
            Console.Write("\n   Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("   Enter Expense ID");
                    int ExpId = int.Parse(Console.ReadLine());
                    Console.WriteLine("   Enter Expense Name");
                    string Expname = Console.ReadLine();
                    Console.WriteLine("   Enter Expense Description");
                    string ExpDesc = Console.ReadLine();
                    Console.WriteLine("   Enter Expense Amount");
                    int ExpAmount = int.Parse(Console.ReadLine());
                    Console.WriteLine("   Enter Expense Time");
                    DateTime ExpTime = DateTime.Now;
                    expenseDAC.AddExpense(ExpId, Expname, ExpDesc, ExpAmount, ExpTime);
                    break;
                case "2":
                    
                    expenseDAC.GetExpense();
                    break;
                case "3":
                    expenseDAC.GetTotalOfExpense();
                    break;
                case "4":
                    Console.WriteLine("   Enter Expense ID");
                    int Id = int.Parse(Console.ReadLine());
                    Console.WriteLine("   Enter Expense Name");
                    string name = Console.ReadLine();
                    Console.WriteLine("   Enter Expense Description");
                    string Desc = Console.ReadLine();
                    Console.WriteLine("   Enter Expense Amount");
                    int Amount = int.Parse(Console.ReadLine());
                    Console.WriteLine("   Enter Expense Time");
                    DateTime Time = DateTime.Now;
                    expenseDAC.UpdateExpense(Id, name, Desc, Amount, Time);
                    Console.WriteLine("Exiting...");
                    return;
                default:
                    Console.WriteLine("  Invalid choice. Please enter a number from 1 to 4.");
                    break;
            }
        }
        #endregion

  
       


        
    }
}