using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice_Billing_Software.BLL_Business_Logic_Layer_
{
    internal class Customers
    {
        public int Customer_Id { get; set; }
        public string Customer_First_Name { get; set;}
        public string Customer_Last_Name { get; set;}
        public string Customer_Mobile_Number { get; set;}
        public string Customer_Email_Address { get; set;}
        public string Customer_Address { get; set;}
    }
}
