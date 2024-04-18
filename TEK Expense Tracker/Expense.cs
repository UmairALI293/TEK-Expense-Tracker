using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEK_Expense_Tracker
{
    public class Expense
    {
        public string Description { get; set; }
        public int Amount { get; set; }
        public DateTime Date { get; set; }

        public Expense(string description, int amount)
        {
            Description = description;
            Amount = amount;
            Date = DateTime.Now;
        }
    }


}
