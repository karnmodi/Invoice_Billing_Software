using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Bunifu.Framework.License;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using Invoice_Billing_Software.BLL_Business_Logic_Layer_;
using Invoice_Billing_Software.DAL_Data_Access_Layer_;
using System.Web;
using System.Transactions;
//using DGVPrinterHelper;

namespace Invoice_Billing_Software
{
    public partial class Invoice_Page : Form
    {
  
        public Invoice_Page()
        {
            InitializeComponent();

            string hexColor = "#375AAB";
            Color TextColour = System.Drawing.ColorTranslator.FromHtml(hexColor);


            Btn_Dashboard.FlatStyle = FlatStyle.Flat;
            Btn_Dashboard.FlatAppearance.BorderSize = 0;
            Btn_Dashboard.ForeColor = TextColour;

            Btn_Invoice.FlatStyle = FlatStyle.Flat;
            Btn_Invoice.FlatAppearance.BorderSize = 0;
            Btn_Invoice.ForeColor = TextColour;

            Btn_Products.FlatStyle = FlatStyle.Flat;
            Btn_Products.FlatAppearance.BorderSize = 0;
            Btn_Products.ForeColor = TextColour;

            Btn_Expenses.FlatStyle = FlatStyle.Flat;
            Btn_Expenses.FlatAppearance.BorderSize = 0;
            Btn_Expenses.ForeColor = TextColour;

            Btn_Customers.FlatStyle = FlatStyle.Flat;
            Btn_Customers.FlatAppearance.BorderSize = 0;
            Btn_Customers.ForeColor = TextColour;


            Btn_Staff.FlatStyle = FlatStyle.Flat;
            Btn_Staff.FlatAppearance.BorderSize = 0;
            Btn_Staff.ForeColor = TextColour;

            Btn_Business_Details.FlatStyle = FlatStyle.Flat;
            Btn_Business_Details.FlatAppearance.BorderSize = 0;
            Btn_Business_Details.ForeColor = TextColour;

            Btn_Logout.FlatStyle = FlatStyle.Flat;
            Btn_Logout.FlatAppearance.BorderSize = 0;

            Lbl_Invoice.ForeColor = TextColour;


            Btn_Save_Print.BackColor = TextColour;
            Btn_Save.BackColor = TextColour;
            Btn_Clear.BackColor = TextColour;
            Btn_Clear.ForeColor = Color.White;
            Btn_Save.ForeColor = Color.White;
            Btn_Save_Print.ForeColor = Color.White;
            
            Lbl_Username.ForeColor = TextColour;
            txt_Return_Amount.ForeColor = TextColour;


            //Decimal Product_Price = Convert.ToDecimal(txt_Price.Text);
            //Decimal Quantity = Convert.ToDecimal(txt_Quantity.Text);
            //Decimal Amount = 0;

            //Amount = Product_Price * Quantity;

            //txt_Amount.Text = Amount.ToString();

        }

        static string MyConn = ConfigurationManager.ConnectionStrings["Software_Database"].ConnectionString;

        public static string User_Type;

        Customers_DAL CDAL = new Customers_DAL();

        Products_DAL PDAL = new Products_DAL();

        DataTable Invoice_DT = new DataTable();

        Invoice_HF_DAL IHFDAL = new Invoice_HF_DAL();

        Invoice_RD_DLL IRDDAL = new Invoice_RD_DLL();
        private void Invoice_Page_Load(object sender, EventArgs e)
        {
            Lbl_Username.Text = User_Type;

            Invoice_DT.Columns.Add("Product_Name");
            Invoice_DT.Columns.Add("Product_Price");
            Invoice_DT.Columns.Add("Quantity");
            Invoice_DT.Columns.Add("Amount");
            Txt_Search.Focus();
            
            
        }
   

        private void Btn_Logout_Click(object sender, EventArgs e)
        {
            Login_Page LP = new Login_Page();
            LP.Show();
            Visible = false;
        }

        private void Btn_Reports_Click(object sender, EventArgs e)
        {
            Business_Page RP = new Business_Page(); 
            RP.Show();
            this.Hide();
        }

        private void Btn_Staff_Click(object sender, EventArgs e)
        {
            Staff_Page SP = new Staff_Page();
            SP.Show();
            this.Hide();
        }
        private void Btn_Customers_Click(object sender, EventArgs e)
        {
            Customers_Page CP = new Customers_Page();
            CP.Show();
            this.Hide();
        }
        private void Btn_Expenses_Click(object sender, EventArgs e)
        {
            Expenses_Page EP = new Expenses_Page();
            EP.Show();
            Visible=false;
        }
        private void Btn_Products_Click(object sender, EventArgs e)
        {
            Products_Page PP = new Products_Page(); 
            PP.Show();
            Visible =false;
        }

        private void Btn_Invoice_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Invoice Page is Already Opened!!");
        }

        private void Btn_Dashboard_Click(object sender, EventArgs e)
        {
            Home_Page HM = new Home_Page();
            HM.Show();
            Visible = false;
        }
        private void Clear_Customer_Details()
        {
            Txt_Customer_Name.Text = "";
            Txt_Customer_No.Text = "";
        }

        private void Txt_Search_TextChanged(object sender, EventArgs e)
        {
            string keywords = Txt_Search.Text;
            if (Txt_Search.Text == null)
            {
                Clear_Customer_Details();
            }

            Customers CBLL = CDAL.Search_Customers_details_For_Invoice(keywords);

            Txt_Customer_Name.Text = CBLL.Customer_First_Name + " " + CBLL.Customer_Last_Name ;
            Txt_Customer_No.Text = CBLL.Customer_Mobile_Number;
        }

        private void Clear_Product_Details()
        {
            txt_Product_Name.Text = "";
            txt_Price.Text = "0.0";
            txt_Quantity.Text = "0.0";
            txt_Amount.Text = "";
        }


        private void Txt_Seach_Products_TextChanged(object sender, EventArgs e)
        {
            string keywords = Txt_Seach_Products.Text;
            if (Txt_Seach_Products.Text == "")
            {
                Clear_Product_Details();
            }

            Products PBLL= PDAL.Search_Products_for_Invoice (keywords);

            txt_Product_Name.Text = PBLL.Product_Name;
            txt_Price.Text = PBLL.Product_Price.ToString();

            //Txt_Search.Text = "";

        }


        private void Btn_Add_Product_Click(object sender, EventArgs e)
        {
            string Product_Name = txt_Product_Name.Text;
            decimal Product_Price = Math.Round(Convert.ToDecimal(txt_Price.Text), 2);
            decimal Quantity = Math.Round(Convert.ToDecimal(txt_Quantity.Text), 2);
            decimal Amount = 0;
            Amount = Product_Price * Quantity;
            decimal Sub_Total = Math.Round(Convert.ToDecimal(txt_Sub_Total.Text), 2); ;

            Sub_Total = Sub_Total + Amount; 

            if (txt_Product_Name.Text == "")
            {
                MessageBox.Show("Select Product First and Enter Appropriate Quantity!!");
            }
            else
            {
                Invoice_DT.Rows.Add(Product_Name, Product_Price, Quantity, Amount);
                dg_Added_Products.DataSource = Invoice_DT;

                
                txt_Sub_Total.Text = Sub_Total.ToString();
                
            }

            txt_Amount.Text = "£ " + Amount.ToString();

            Txt_Seach_Products.Text = "";
            Txt_Seach_Products.Focus();


        }

        private void Amount_Show()
        {
            if(txt_Quantity.Text == "")
            {
                txt_Amount.Text = "";
            }
            else
            {
                decimal Product_Price = Math.Round(Convert.ToDecimal(txt_Price.Text), 2);
                decimal Quantity = Math.Round(Convert.ToDecimal(txt_Quantity.Text), 2);
                decimal Amount = 0;

                Amount = Product_Price * Quantity;

                txt_Amount.Text = "£ " + Amount.ToString();
            }
        }

        private void Btn_Clear_Product_Click(object sender, EventArgs e)
        {
            Clear_Customer_Details();
            Clear_Product_Details ();
        }

        private void txt_Quantity_TextChanged(object sender, EventArgs e)
        {
            Amount_Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string value = txt_Discount.Text;

            if (value == "")
            {
                MessageBox.Show("Please Add Discount First!! \n\n note: type 0 for No Discount!");
                txt_Grand_Total.Text = "";
            }
            else
            {
                decimal Sub_Total = Math.Round(Convert.ToDecimal(txt_Sub_Total.Text), 2);
                decimal Discount = Math.Round(Convert.ToDecimal(txt_Discount.Text), 2);

                decimal Grand_Total = ((100 - Discount) / 100) * Sub_Total;

                txt_Grand_Total.Text = Grand_Total.ToString();
            }
        }

        

        private void txt_Vat_TextChanged(object sender, EventArgs e)
        {
            string Temp_GT = txt_Grand_Total.Text;
            
            string Check =  txt_Grand_Total.Text;
            string Value_Vat = txt_Vat.Text;
            if (Check == "" || Value_Vat == "") 
            {
                MessageBox.Show("Please Add Discount First!! \n\n note: type 0 for No Discount!\nnote: type 0 for No Vat!");
                txt_Grand_Total.Text = Temp_GT.ToString();
            }
            else
            { 
                decimal temp_Grand_Total = Math.Round(Convert.ToDecimal(txt_Grand_Total.Text),2);
                decimal Vat = Math.Round(Convert.ToDecimal(txt_Vat.Text),2);
                decimal Grand_Total_After_Vat = ((100 + Vat) / 100) * temp_Grand_Total;


                txt_Grand_Total.Text = Grand_Total_After_Vat.ToString();
            }
        }

        private void txt_Paid_Amount_TextChanged(object sender, EventArgs e)
        {

            if (txt_Discount.Text == "" || txt_Vat.Text == "")
            {
                MessageBox.Show("Please Add Discount or VAT First!! \n\n note: type 0 for No Discount!\nnote: type 0 for No Vat!");

            }

            else if (txt_Paid_Amount.Text == "")
            {
                MessageBox.Show("Please Enter Paid Amount!!");
                txt_Return_Amount.Text = "";
            }
            else
            {

                decimal Grand_Total = Math.Round(Convert.ToDecimal(txt_Grand_Total.Text), 2);
                decimal Paid_Amount = Math.Round(Convert.ToDecimal(txt_Paid_Amount.Text), 2);

                decimal Return_Amount = Paid_Amount - Grand_Total;

                txt_Return_Amount.ForeColor = Color.Red;
                txt_Return_Amount.Text = "£ " + Return_Amount.ToString();
            }
        }


        private void Btn_Clear_Click(object sender, EventArgs e)
        {
            Clear_Customer_Details();
            Clear_Product_Details();
            txt_Sub_Total.Text = "0.0";
            txt_Discount.Text = "0";
            txt_Vat.Text = "0";
            txt_Paid_Amount.Text = "0";
            txt_Grand_Total.Text = "";
            txt_Return_Amount.Text = "0";
            dg_Added_Products.DataSource = null;
            dg_Added_Products.Rows.Clear();
            Invoice_DT.Rows.Clear();

        }

        private void Btn_Save_Click(object sender, EventArgs e)
        {
            Invoice_HF IHF = new Invoice_HF();

            string Name = Txt_Customer_Name.Text;

            Customers CBLL = CDAL.Get_Customer_ID_from_Name_in_Invoice_Table(Name);

            IHF.Customer_Id = CBLL.Customer_Id;
            IHF.Grand_Total = Math.Round(Convert.ToDecimal(txt_Grand_Total.Text),2);
            IHF.Invoice_Date = DateTime.Now;
            IHF.Tax = Convert.ToDecimal(txt_Vat.Text);
            IHF.Discount = Convert.ToDecimal(txt_Discount.Text);
            IHF.Added_By = Lbl_Username.Text;

            IHF.Invoice_Details = Invoice_DT;


            bool Success = false;

            using (TransactionScope scope = new TransactionScope()) 
            {
                int Invoice_Id = -1;

                bool w = IHFDAL.Insert(IHF, out Invoice_Id);

                for(int i = 0; i< Invoice_DT.Rows.Count; i++)
                {
                    Invoice_RD IRDBLL = new Invoice_RD();
                    string Product_Name = txt_Product_Name.Text;
                    Products PBLLPN = PDAL.Get_Product_Id_from_Name_in_Invoice_Table(Product_Name);
                    
                    IRDBLL.Product_Id = PBLLPN.Product_Id;
                    IRDBLL.Product_Price = Convert.ToDecimal(Invoice_DT.Rows[i][1].ToString());
                    IRDBLL.Quantity = Convert.ToDecimal(Invoice_DT.Rows[i][2].ToString());
                    IRDBLL.Amount = Convert.ToDecimal(Invoice_DT.Rows[i][3].ToString());
                    IRDBLL.Customer_Id = CBLL.Customer_Id;
                    IRDBLL.Added_Date = DateTime.Now;
                    IRDBLL.Added_By = Lbl_Username.Text;

                    bool y = IRDDAL.Insert_Transaction(IRDBLL);
                    Success = w && y;

                }


                if (Success == true)
                {
                    scope.Complete();
                    MessageBox.Show("Transaction Completed Successfully");
                    Clear_Customer_Details();
                    Clear_Product_Details();
                    txt_Sub_Total.Text = "0.0";
                    txt_Discount.Text = "0";
                    txt_Vat.Text = "0";
                    txt_Paid_Amount.Text = "0";
                    txt_Grand_Total.Text = "";
                    txt_Return_Amount.Text = "0";
                    dg_Added_Products.DataSource = null;
                    dg_Added_Products.Rows.Clear();
                    Invoice_DT.Rows.Clear();
                }
                else
                {

                    MessageBox.Show("Transaction Failed");
                }

            }
        }

        private void Btn_Save_Print_Click(object sender, EventArgs e)
        {

            Invoice_HF IHF = new Invoice_HF();

            string Customer_Name = Txt_Customer_Name.Text;

            Customers CBLL = CDAL.Get_Customer_ID_from_Name_in_Invoice_Table(Customer_Name);

            IHF.Customer_Id = CBLL.Customer_Id;
            IHF.Grand_Total = Math.Round(Convert.ToDecimal(txt_Grand_Total.Text), 2);
            IHF.Invoice_Date = DateTime.Now;
            IHF.Tax = Convert.ToDecimal(txt_Vat.Text);
            IHF.Discount = Convert.ToDecimal(txt_Discount.Text);
            IHF.Added_By = Lbl_Username.Text;

            IHF.Invoice_Details = Invoice_DT;


            bool Success = false;

            using (TransactionScope scope = new TransactionScope())
            {
                int Invoice_Id = -1;

                bool w = IHFDAL.Insert(IHF, out Invoice_Id);

                for (int i = 0; i < Invoice_DT.Rows.Count; i++)
                {
                    Invoice_RD IRDBLL = new Invoice_RD();
                    string Product_Name = txt_Product_Name.Text;
                    Products PBLL = PDAL.Get_Product_Id_from_Name_in_Invoice_Table(Product_Name);

                    IRDBLL.Product_Id = PBLL.Product_Id;
                    IRDBLL.Product_Price = Convert.ToDecimal(Invoice_DT.Rows[i][1].ToString());
                    IRDBLL.Quantity = Convert.ToDecimal(Invoice_DT.Rows[i][2].ToString());
                    IRDBLL.Amount = Convert.ToDecimal(Invoice_DT.Rows[i][3].ToString());
                    IRDBLL.Customer_Id = CBLL.Customer_Id;
                    IRDBLL.Added_Date = DateTime.Now;
                    IRDBLL.Added_By = Lbl_Username.Text;

                    bool y = IRDDAL.Insert_Transaction(IRDBLL);
                    Success = w && y;

                }


                if (Success == true)
                {
                    scope.Complete();

                    

                    MessageBox.Show("Transaction Completed Successfully");
                    Clear_Customer_Details();
                    Clear_Product_Details();
                    txt_Sub_Total.Text = "0.0";
                    txt_Discount.Text = "0";
                    txt_Vat.Text = "0";
                    txt_Paid_Amount.Text = "0";
                    txt_Grand_Total.Text = "";
                    txt_Return_Amount.Text = "0";
                    dg_Added_Products.DataSource = null;
                    dg_Added_Products.Rows.Clear();
                    Invoice_DT.Rows.Clear();
                }
                else
                {

                    MessageBox.Show("Transaction Failed");
                }

            }
        }
    }
}
