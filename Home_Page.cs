using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Reflection.Emit;
using System.Configuration;
using System.Data.SqlClient;
using static Bunifu.Framework.License;
using System.IO;

namespace Invoice_Billing_Software
{
    public partial class Home_Page : Form
    {


        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // height of ellipse
            int nHeightEllipse // width of ellipse
        );
        public Home_Page()
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

            Quick_Info_Text.ForeColor = TextColour;
            Quick_Info_Text.BorderStyle = BorderStyle.None;

            Date_Label.Text = DateTime.Now.ToShortDateString();
            Date_Label.ForeColor = TextColour;

            Time_Label.ForeColor = TextColour;
            Time_Text_Box.ForeColor = TextColour;
            Gross_Sale_Ractangle.BackColor = TextColour;
            Cash_Received_Rectangle.BackColor = TextColour;
            Expense_Quick_Info_Rectangel.BackColor = TextColour;

            Gross_Sale_Text.BackColor = TextColour;
            Todays_SaleText.BackColor = TextColour;
            Total_Expenses_Text.BackColor = TextColour;

            Lbl_Username.ForeColor = TextColour;
            Lbl_Gross_Sale.ForeColor = Color.White;
            Lbl_Todays_Sale.ForeColor = Color.White;
            Lbl_Total_Expeses.ForeColor = Color.White;

            /*btn_New_Customer.BackColor = TextColour;
            btn_New_Expense.BackColor = TextColour;
            btn_New_Invoice.BackColor = TextColour;
            btn_New_Staff.BackColor = TextColour;

            btn_New_Customer.ForeColor = Color.White;
            btn_New_Expense.ForeColor = Color.White;
            btn_New_Invoice.ForeColor = Color.White;
            btn_New_Staff.ForeColor = Color.White;*/


            Lbl_Dashboard.ForeColor = TextColour;


            timer1.Start();


        }

        static string MyConn = ConfigurationManager.ConnectionStrings["Software_Database"].ConnectionString;
        public static string User_Type;

        private void Home_Page_Load(object sender, EventArgs e)
        {
            Lbl_Username.Text = User_Type;

            SqlConnection SCONN = new SqlConnection(MyConn);

            string SQL_Query_FOR_GROSS_SALE = "SELECT SUM(Grand_Total) FROM Invoice_Header_Footer_Table";
            string SQL_Query_FOR_Todays_SALE = "SELECT SUM(Grand_Total) FROM Invoice_Header_Footer_Table WHERE CONVERT(DATE, Invoice_Date) = CONVERT(DATE, GETDATE())";
            string SQL_Query_FOR_Total_Expenses = "SELECT SUM(Expense_Amount) FROM Expense_Table";

            SqlCommand SCMD1 = new SqlCommand(SQL_Query_FOR_GROSS_SALE, SCONN);
            SqlCommand SCMD2 = new SqlCommand(SQL_Query_FOR_Todays_SALE, SCONN);
            SqlCommand SCMD3 = new SqlCommand(SQL_Query_FOR_Total_Expenses, SCONN);
            SqlDataAdapter SDA1 = new SqlDataAdapter(SCMD1);
            SqlDataAdapter SDA2 = new SqlDataAdapter(SCMD2);
            SqlDataAdapter SDA3 = new SqlDataAdapter(SCMD3);
            SCONN.Open();
            DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();
            DataTable dt3 = new DataTable();
            SDA1.Fill(dt1);
            SDA2.Fill(dt2);
            SDA3.Fill(dt3);
            Lbl_Gross_Sale.Text = "£ " + dt1.Rows[0][0].ToString();
            Lbl_Todays_Sale.Text = "£ " + dt2.Rows[0][0].ToString();
            Lbl_Total_Expeses.Text = "£ " + dt3.Rows[0][0].ToString();

           
        }

        private void User_Panel_Load(object sender, EventArgs e)
        {

            this.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Time_Label.Text = DateTime.Now.ToString("T");
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
            Visible = false;
        }

        private void Btn_Staff_Click(object sender, EventArgs e)
        {
            Staff_Page SP = new Staff_Page();
            SP.Show();
            Visible = false;
        }

        private void Btn_Customers_Click(object sender, EventArgs e)
        {
            Customers_Page CP = new Customers_Page();
            CP.Show();
            Visible = false;
        }
        private void Btn_Expenses_Click(object sender, EventArgs e)
        {
            Expenses_Page EP = new Expenses_Page();
            EP.Show();
            Visible = false;
        }
        private void Btn_Products_Click(object sender, EventArgs e)
        {
            Products_Page PP = new Products_Page();
            PP.Show();
            Visible = false;
        }
        private void Btn_Invoice_Click(object sender, EventArgs e)
        {
            Invoice_Page IP = new Invoice_Page();
            IP.Show();
            Visible = false;
        }

        private void Btn_Dashboard_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Dashboard is Already Opened!!");
        }

        private void btn_New_Invoice_Click(object sender, EventArgs e)
        {
            Invoice_Page IP = new Invoice_Page();
            IP.Show();
            this.Close();
        }

        private void btn_New_Expense_Click(object sender, EventArgs e)
        {
            Expenses_Page EP = new Expenses_Page();
            EP.Show();
            this.Close();
        }

        private void btn_New_Staff_Click(object sender, EventArgs e)
        {
            Staff_Page SP = new Staff_Page();
            SP.Show();
            this.Close();

        }

        private void btn_New_Customer_Click(object sender, EventArgs e)
        {
            Customers_Page CP = new Customers_Page();
            CP.Show();
            this.Close();

        }
    }

}