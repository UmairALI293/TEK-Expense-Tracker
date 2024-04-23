//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace TEK_Expense_Tracker
//{
//    public class Expense_Tracker
//    {
//        private List<Expense> ExpenseList;

//        public Expense_Tracker()
//        {
//            ExpenseList = new List<Expense>();
//        }

//        public void AddExpense(string description, int amount)
//        {
//            ExpenseList.Add(new Expense(description, amount));
//            Console.WriteLine("   Expense added successfully.");
//        }
        
//        public void ViewTotalExpense()
//        {
//            Decimal totalExpense = 0;

//            if (ExpenseList.Count > 0)
//            {
                
//                foreach (var expense in ExpenseList)
//                {
//                    totalExpense = totalExpense + expense.Amount;
//                }
//                Console.WriteLine($"   Total expense: {totalExpense}");
                
//            }

//            else
//            {
//                Console.WriteLine("    No Expense  Exists ");
//            }

            

//        }
//        public void ViewAllExpense()
//        {
//            if (ExpenseList.Count > 0)
//            {
//                foreach (var expense in ExpenseList)
//                {
//                    Console.WriteLine($"    Description: {expense.Description}, Amount:{expense.Amount}, Date:{expense.Date}");
//                }
//            }

//            else
//            {
//                Console.WriteLine("     Expenses Records not Exists ");
//            }

//        }
//    }
//}
