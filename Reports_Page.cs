using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Invoice_Billing_Software
{
    public partial class Reports_Page : Form
    {
        public Reports_Page()
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

            Btn_Reports.FlatStyle = FlatStyle.Flat;
            Btn_Reports.FlatAppearance.BorderSize = 0;
            Btn_Reports.ForeColor = TextColour;

            Btn_Logout.FlatStyle = FlatStyle.Flat;
            Btn_Logout.FlatAppearance.BorderSize = 0;

            Lbl_Username.ForeColor = TextColour;
        }

        public static string User_Type;
        private void Reports_Page_Load(object sender, EventArgs e)
        {
            Lbl_Username.Text = User_Type;
        }

        private void Btn_Logout_Click(object sender, EventArgs e)
        {
            Login_Page LP = new Login_Page();
            LP.Show();
            this.Close();
        }

        private void Btn_Reports_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Reports Section is Already Opened !!");
        }

        private void Btn_Staff_Click(object sender, EventArgs e)
        {
            Staff_Page SP = new Staff_Page();
            SP.Show();
            this.Close();
        }

        private void Btn_Customers_Click(object sender, EventArgs e)
        {
            Customers_Page CP = new Customers_Page();
            CP.Show();
            this.Close();
        }

        private void Btn_Expenses_Click(object sender, EventArgs e)
        {
            Expenses_Page EP = new Expenses_Page();
            EP.Show();
            this.Close();
        }

        private void Btn_Products_Click(object sender, EventArgs e)
        {
            Products_Page PP = new Products_Page();
            PP.Show();
            this.Close();
        }

        private void Btn_Invoice_Click(object sender, EventArgs e)
        {
            Invoice_Page IP = new Invoice_Page();
            IP.Show();
            this.Close();
        }

        private void Btn_Dashboard_Click(object sender, EventArgs e)
        {
            Home_Page HP = new Home_Page();
            HP.Show();
            this.Close();
        }
    }
}
