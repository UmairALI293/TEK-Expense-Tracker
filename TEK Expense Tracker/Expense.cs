//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace TEK_Expense_Tracker
//{
//    public class Expense
//    {
//        public int ID { get; set; }

//        public string Name { get; set; }

//        public string Description { get; set; }
//        public int Amount { get; set; }

//        //public DateTime Time { get; set; }

//        //public Expense(string description, int amount)
//        //{
//        //    Description = description;
//        //    Amount = amount;
//        //    Date = DateTime.Now;
//        //}


//        public Expense InsertValues()
//        {
//            Expense expense = new Expense();
//            Console.WriteLine("   Enter Expense ID");
//            ID = int.Parse(Console.ReadLine());
//            Console.WriteLine("   Enter Expense Name");
//            Name = Console.ReadLine();
//            Console.WriteLine("   Enter Expense Description");
//            Description = Console.ReadLine();
//            Console.WriteLine("   Enter Expense Amount");
//            Amount = int.Parse(Console.ReadLine());
//            //Time = DateTime.Now;

//            return expense;
//        }
//    }


//}
