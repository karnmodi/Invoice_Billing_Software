using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice_Billing_Software.BLL_Business_Logic_Layer_
{
    internal class Products
    {
        public int Product_Id { get; set; }
        public string Product_Name { get; set;}
        public string Product_Category { get; set;}
        public SqlMoney Product_Price { get; set; }

    }
}
