using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice_Billing_Software.BLL_Business_Logic_Layer_
{
    internal class Expenses
    {
        public int Expense_Id { get; set; }
        public string Expense_Description { get; set; }
        public string Expense_Category { get; set; }
        public SqlMoney Expense_Amount { get; set; }
        public string Authorised_By { get; set; }

    }
}
