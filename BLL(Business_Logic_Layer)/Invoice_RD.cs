using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice_Billing_Software.BLL_Business_Logic_Layer_
{
    internal class Invoice_RD
    {
        public int Invoice_Product_Id { get; set; }
        public int Product_Id { get; set; }
        public Decimal Product_Price { get; set; }
        public Decimal Quantity { get; set; }
        public decimal Amount { get; set; }
        public int Customer_Id { get; set; }
        public DateTime Added_Date { get; set; }
        public string Added_By { get; set; }

    }
}
