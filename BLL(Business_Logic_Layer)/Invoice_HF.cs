using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice_Billing_Software.BLL_Business_Logic_Layer_
{
    internal class Invoice_HF
    {
        public int Invoice_Id { get; set; }
        public int Customer_Id { get; set; }
        public Decimal Grand_Total { get; set; }
        public DateTime Invoice_Date { get; set; }
        public Decimal Tax { get; set; }
        public Decimal Discount { get; set; }
        public string Added_By { get; set; }

        public DataTable Invoice_Details { get; set; }
    }
}
