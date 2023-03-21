using Invoice_Billing_Software.BLL_Business_Logic_Layer_;
using Invoice_Billing_Software.DAL_Data_Access_Layer_;
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

namespace Invoice_Billing_Software
{
    public partial class Expenses_Page : Form
    {
        public Expenses_Page()
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

            Lbl_Expenses.ForeColor = TextColour;
            //Lbl_Date_TIme.ForeColor = TextColour;
            Lbl_Expense_Details.ForeColor = TextColour;
            Lbl_Username1.ForeColor = TextColour;

            txt_Authorised_By.Text = User_Type;

            //timer2.Start();
        }
        public static string User_Type;
        Expenses E = new Expenses();
        Expenses_DAL ED = new Expenses_DAL();
        
        private void Expenses_Page_Load(object sender, EventArgs e)
        {
            Lbl_Username1.Text = User_Type;


            DataTable DT = ED.Select();
            dg_Expense_Database.DataSource = DT;

            this.dg_Expense_Database.Columns["Expense_Amount"].DefaultCellStyle.Format = "c2";
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
            MessageBox.Show("Expense Page is Already Opened!!");
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
            Home_Page HP = new Home_Page();
            HP.Show();
            Visible = false;
        }

        private void Btn_Add_Click(object sender, EventArgs e)
        {
            E.Expense_Description = txt_Expense_Description.Text;

            E.Expense_Category = txt_Expense_Category.Text;

            E.Expense_Amount = Convert.ToDecimal(txt_Amount.Text);

            E.Authorised_By = Lbl_Username1.Text;

            //Inserting
            bool success = ED.Insert(E);
            if (success)
            {
                MessageBox.Show("Expense Added Successfully", "Data Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Clear();
                DataTable DT = ED.Select();
                dg_Expense_Database.DataSource = DT;
            }
            else
            {
                MessageBox.Show("Process Failed\nTry Again!!", "Invalid Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Clear()
        {
            txt_Expense_Description.Text = "";
            txt_Expense_Category.Text = "";
            txt_Amount.Text = "";
            txt_Authorised_By.Text = Lbl_Username1.Text;
            txt_Expense_Id.Text = "Automatically Inserted";
        }

        private void Btn_Update_Click(object sender, EventArgs e)
        {
            E.Expense_Id = Convert.ToInt32(txt_Expense_Id.Text);
            E.Expense_Description = txt_Expense_Description.Text;
            E.Expense_Category = txt_Expense_Category.Text;
            E.Expense_Amount = Convert.ToDecimal(txt_Amount.Text);
            E.Authorised_By= (Lbl_Username.Text);


            bool success = ED.Update(E);
            if (success)
            {
                MessageBox.Show("Expense Updated Successfully", "Data Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Clear();
                DataTable DT = ED.Select();
                dg_Expense_Database.DataSource = DT;
            }
            else
            {
                MessageBox.Show("Process Failed\nTry Again!!", "Invalid Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Btn_Delete_Click(object sender, EventArgs e)
        {
            E.Expense_Id = Convert.ToInt32(txt_Expense_Id.Text);

            bool success = ED.Delete(E);
            if (success == true)
            {
                MessageBox.Show("Expense Deleted Successfully", "Data Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Clear();
                DataTable DT = ED.Select();
                dg_Expense_Database.DataSource = DT;
            }
            else
            {
                MessageBox.Show("Process Failed\nTry Again!!", "Invalid Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dg_Expense_Database_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;
            txt_Expense_Id.Text = dg_Expense_Database.Rows[rowIndex].Cells[0].Value.ToString();
            txt_Expense_Description.Text = dg_Expense_Database.Rows[rowIndex].Cells[1].Value.ToString();
            txt_Expense_Category.Text = dg_Expense_Database.Rows[rowIndex].Cells[2].Value.ToString();
            txt_Amount.Text = dg_Expense_Database.Rows[rowIndex].Cells[3].Value.ToString();
            txt_Authorised_By.Text = dg_Expense_Database.Rows[rowIndex].Cells[4].Value.ToString();
        }

        private void txt_Search_TextChanged(object sender, EventArgs e)
        {
            string keywords = txt_Search.Text;

            if (keywords != null)
            {
                DataTable DT = ED.Search(keywords);
                dg_Expense_Database.DataSource = DT;
            }
            else
            {
                DataTable DT = ED.Select();
                dg_Expense_Database.DataSource = DT;
            }
        }

        private void dg_Expense_Database_RowHeaderMouseClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;
            txt_Expense_Id.Text = dg_Expense_Database.Rows[rowIndex].Cells[0].Value.ToString();
            txt_Expense_Description.Text = dg_Expense_Database.Rows[rowIndex].Cells[1].Value.ToString();
            txt_Expense_Category.Text = dg_Expense_Database.Rows[rowIndex].Cells[2].Value.ToString();
            txt_Amount.Text = dg_Expense_Database.Rows[rowIndex].Cells[3].Value.ToString();
            txt_Authorised_By.Text = dg_Expense_Database.Rows[rowIndex].Cells[4].Value.ToString();
        }
    }
}