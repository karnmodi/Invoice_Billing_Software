using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Invoice_Billing_Software.BLL_Business_Logic_Layer_;
using Invoice_Billing_Software.DAL_Data_Access_Layer_;

namespace Invoice_Billing_Software
{
    public partial class Customers_Page : Form
    {
        public Customers_Page()
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

            txt_Customer_Id.ForeColor = Color.Red;

            Lbl_Username.ForeColor = TextColour;
        }

        public static string User_Type;
        Customers C = new Customers();
        Customers_DAL CD = new Customers_DAL();
        private void Customers_Page_Load(object sender, EventArgs e)
        {
            Lbl_Username.Text = User_Type;

            DataTable DT = CD.Select();
            dg_Customers_Database.DataSource = DT;
        }

        private void Btn_Logout_Click(object sender, EventArgs e)
        {
            Login_Page LP = new Login_Page();
            LP.Show();
            this.Close();
        }

        private void Btn_Reports_Click(object sender, EventArgs e)
        {
            Business_Page RP = new Business_Page();
            RP.Show();
            this.Close();
        }

        private void Btn_Staff_Click(object sender, EventArgs e)
        {
            Staff_Page SP = new Staff_Page();
            SP.Show();
            this.Close();
        }

        private void Btn_Customers_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Customers Page is Already Opened !!");
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

        private void Clear()
        {
            txt_Customer_First_Name.Text = "";
            txt_Last_Name.Text = "";
            txt_Customer_Contact_No.Text = "";
            txt_Customer_Email_Address.Text = "";
            txt_Customer_Address.Text = "";
            txt_Customer_Id.Text = "Inserted Automatically";
            txt_Customer_Id.ForeColor = Color.Red;

        }

        private void Btn_Add_Click(object sender, EventArgs e)
        {
            C.Customer_First_Name = txt_Customer_First_Name.Text;
            C.Customer_Last_Name = txt_Last_Name.Text;
            C.Customer_Mobile_Number = txt_Customer_Contact_No.Text;
            C.Customer_Email_Address = txt_Customer_Email_Address.Text;
            C.Customer_Address = txt_Customer_Address.Text;

            bool success = CD.Insert(C);
            if (success)
            {
                MessageBox.Show("Customer Added Successfully", "Data Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Clear();
                DataTable DT = CD.Select();
                dg_Customers_Database.DataSource = DT;
            }
            else
            {
                MessageBox.Show("Process Failed\nTry Again!!", "Invalid Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dg_Customers_Database_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;
            txt_Customer_Id.Text = dg_Customers_Database.Rows[rowIndex].Cells[0].Value.ToString();
            txt_Customer_First_Name.Text = dg_Customers_Database.Rows[rowIndex].Cells[1].Value.ToString();
            txt_Last_Name.Text = dg_Customers_Database.Rows[rowIndex].Cells[2].Value.ToString();
            txt_Customer_Contact_No.Text = dg_Customers_Database.Rows[rowIndex].Cells[3].Value.ToString();
            txt_Customer_Email_Address.Text = dg_Customers_Database.Rows[rowIndex].Cells[4].Value.ToString();
            txt_Customer_Address.Text = dg_Customers_Database.Rows[rowIndex].Cells[5].Value.ToString();
        }

        private void Btn_Delete_Click(object sender, EventArgs e)
        {
            C.Customer_Id = Convert.ToInt32(txt_Customer_Id.Text);
            bool success = CD.Delete(C);
            if (success == true)
            {
                MessageBox.Show("Customer Record Deleted Successfully", "Data Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Clear();
                DataTable DT = CD.Select();
                dg_Customers_Database.DataSource = DT;
            }
            else
            {
                MessageBox.Show("Process Failed\nTry Again!!", "Invalid Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Btn_Update_Click(object sender, EventArgs e)
        {
            C.Customer_Id = Convert.ToInt32(txt_Customer_Id.Text);
            C.Customer_First_Name = txt_Customer_First_Name.Text;
            C.Customer_Last_Name = txt_Last_Name.Text;
            C.Customer_Mobile_Number = txt_Customer_Contact_No.Text;
            C.Customer_Email_Address = txt_Customer_Email_Address.Text;
            C.Customer_Address = txt_Customer_Address.Text;

            bool Success = CD.Update(C);
            if(Success) 
            {
                MessageBox.Show("Customer Updated Successfully", "Data Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Clear();
                DataTable DT = CD.Select();
                dg_Customers_Database.DataSource = DT;
            }
            else
            {
                MessageBox.Show("Process Failed\nTry Again!!", "Invalid Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txt_Search_TextChanged(object sender, EventArgs e)
        {
            string keywords = txt_Search.Text;

            if (keywords != null)
            {
                DataTable DT = CD.Search(keywords);
                dg_Customers_Database.DataSource = DT;
            }
            else
            {
                DataTable DT = CD.Select();
                dg_Customers_Database.DataSource = DT;
            }
        }
    }
}
