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
        Console.WriteLine("     1. Add Expense"+"     2. View All Expenses"+ "     3. View Total of Expenses"+ "     4. Update an Expense");
       
        ExpenseDAC expenseDAC = new ExpenseDAC();


        

        while (true)
        {
            Console.Write("\n   Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                   
                    Console.WriteLine("   Enter  Name");
                    string Expname = Console.ReadLine();
                    Console.WriteLine("   Enter  Description");
                    string ExpDesc = Console.ReadLine();
                    Console.WriteLine("   Enter  Amount");
                    int ExpAmount = int.Parse(Console.ReadLine());                     
                    expenseDAC.AddExpense(Expname, ExpDesc, ExpAmount);
                    break;
                case "2":
                    
                    expenseDAC.GetExpense();
                    break;
                case "3":
                    expenseDAC.GetTotalOfExpense();
                    break;
                case "4":
                    Console.WriteLine("   Enter  ID");
                    int Id = int.Parse(Console.ReadLine());
                    Console.WriteLine("   Enter  Name");
                    string name = Console.ReadLine();
                    Console.WriteLine("   Enter  Description");
                    string Desc = Console.ReadLine();
                    Console.WriteLine("   Enter  Amount");
                    int Amount = int.Parse(Console.ReadLine());
                    Console.WriteLine("   Enter  Time");
                    DateTime Time = DateTime.Now;
                    expenseDAC.UpdateExpense(Id, name, Desc, Amount, Time);
                    
                    return;
                default:
                    Console.WriteLine("  Invalid choice. Please enter a number from 1 to 4.");
                    break;
            }
        }
        #endregion

  
       


        
    }
}