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
    public partial class Staff_Page : Form
    {
        public Staff_Page()
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

            Lbl_Username.ForeColor = TextColour;
        }

        public static string User_Type;
        Staff S = new Staff();
        Staff_DAL SD = new Staff_DAL();

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
            MessageBox.Show("Staff Page is Already Opened!!");
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

        private void Staff_Page_Load(object sender, EventArgs e)
        {
            Lbl_Username.Text = User_Type;
            DataTable DT = SD.Select();
            dg_Staff_Database.DataSource = DT;

            this.dg_Staff_Database.Columns["Staff_Salary"].DefaultCellStyle.Format = "c2";
        }

        private void Clear()
        {
            txt_Staff_Name.Text = "";
            txt_Staff_Mobile_Number.Text = "";
            //Txt_Staff_Joining_Date.Text = "";
            txt_Salary.Text = "";
            txt_User_Type.Text = "";
            txt_Staff_Id.Text = "Inserted Automatically";
            txt_Password.Text = "";
            txt_Username.Text = "";
        }

        private void Btn_Add_Click(object sender, EventArgs e /*DataTable staff_Joining_Date*/)
        {
            S.Staff_Name = txt_Staff_Name.Text;
            S.Staff_Contact_Number = txt_Staff_Mobile_Number.Text;
            //S.Staff_Joining_Date = staff_Joining_Date;
            S.Staff_Salary = Convert.ToDecimal(txt_Salary.Text);
            S.Username = txt_Username.Text;
            S.Password = txt_Password.Text;
            S.User_Type = txt_User_Type.Text;

            bool success = SD.Insert(S);
            if (success)
            {
                MessageBox.Show("Staff Added Successfully", "Data Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Clear();
                DataTable DT = SD.Select();
                dg_Staff_Database.DataSource = DT;
            }
            else
            {
                MessageBox.Show("Process Failed\nTry Again!!", "Invalid Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dg_Staff_Database_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;
            txt_Staff_Id.Text = dg_Staff_Database.Rows[rowIndex].Cells[0].Value.ToString();
            txt_Staff_Name.Text = dg_Staff_Database.Rows[rowIndex].Cells[1].Value.ToString();
            txt_Staff_Mobile_Number.Text = dg_Staff_Database.Rows[rowIndex].Cells[2].Value.ToString();
            txt_Salary.Text = dg_Staff_Database.Rows[rowIndex].Cells[3].Value.ToString();
            txt_Username.Text = dg_Staff_Database.Rows[rowIndex].Cells[4].Value.ToString();
            txt_Password.Text = dg_Staff_Database.Rows[rowIndex].Cells[5].Value.ToString();
            txt_User_Type.Text = dg_Staff_Database.Rows[rowIndex].Cells[6].Value.ToString();
        }

        private void Btn_Delete_Click(object sender, EventArgs e)
        {
            S.Staff_Id = Convert.ToInt32(txt_Staff_Id.Text);
            bool success = SD.Delete(S);
            if (success == true)
            {
                MessageBox.Show("Customer Record Deleted Successfully", "Data Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Clear();
                DataTable DT = SD.Select();
                dg_Staff_Database.DataSource = DT;
            }
            else
            {
                MessageBox.Show("Process Failed\nTry Again!!", "Invalid Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Btn_Update_Click(object sender, EventArgs e)
        {
            S.Staff_Id = Convert.ToInt32(txt_Staff_Id.Text);
            S.Staff_Name = txt_Staff_Name.Text;
            S.Staff_Contact_Number = txt_Staff_Mobile_Number.Text;
            S.Staff_Salary = Math.Round(Convert.ToDecimal(txt_Salary.Text),2);
            S.Username = txt_Username.Text;
            S.Password = txt_Password.Text;
            S.User_Type= txt_User_Type.Text;

            bool Success = SD.Update(S);
            if (Success)
            {
                MessageBox.Show("Customer Updated Successfully", "Data Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Clear();
                DataTable DT = SD.Select();
                dg_Staff_Database.DataSource = DT;
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
                DataTable DT = SD.Search(keywords);
                dg_Staff_Database.DataSource = DT;
            }
            else
            {
                DataTable DT = SD.Select();
                dg_Staff_Database.DataSource = DT;
            }
        }
    }
}
