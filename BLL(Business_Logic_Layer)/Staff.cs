using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice_Billing_Software.BLL_Business_Logic_Layer_
{
    internal class Staff
    {
        public int Staff_Id { get; set; }
        public string Staff_Name { get;set; }
        public string Staff_Contact_Number { get; set; }
        public DataTable Staff_Joining_Date { get; set; }
        public SqlMoney Staff_Salary { get; set; }
        public int Login_Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string User_Type { get; set; }

    }
}
