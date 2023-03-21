
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Invoice_Billing_Software.BLL_Business_Logic_Layer_;
using Invoice_Billing_Software.DAL_Data_Access_Layer_;

namespace Invoice_Billing_Software
{
    public partial class Products_Page : Form
    {
        public Products_Page()
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

            Lbl_Products.ForeColor = TextColour;

            Lbl_Username.ForeColor = TextColour;



        }

        public static string User_Type;
        Products p = new Products();
        Products_DAL PD = new Products_DAL();


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
            MessageBox.Show("Products Page is Already Opened!!");
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


            p.Product_Name= txt_Product_Name.Text;

            p.Product_Category = txt_Product_Category.Text;

            p.Product_Price = Convert.ToDecimal(txt_Product_Price.Text);

            bool success = PD.Insert(p);
            if(success)
            {
                MessageBox.Show("Product Added Successfully", "Data Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Clear();
                DataTable DT = PD.Select();
                dg_Products_Database.DataSource = DT;
            }
            else
            {
                MessageBox.Show("Process Failed\nTry Again!!", "Invalid Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void Products_Page_Load(object sender, EventArgs e)
        {
            Lbl_Username.Text = User_Type;

            DataTable DT = PD.Select();
            dg_Products_Database.DataSource = DT;

            this.dg_Products_Database.Columns["Product_Price"].DefaultCellStyle.Format = "c2";
   

        }

        private void Clear()
        {
            txt_Product_Name.Text = "";
            txt_Product_Category.Text = "";
            txt_Product_Price.Text = "";
            txt_Product_Id.Text = "Inserted Automatically";
        }


        private void dg_Products_Database_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;
            txt_Product_Id.Text = dg_Products_Database.Rows[rowIndex].Cells[0].Value.ToString();
            txt_Product_Name.Text = dg_Products_Database.Rows[rowIndex].Cells[1].Value.ToString();
            txt_Product_Category.Text = dg_Products_Database.Rows[rowIndex].Cells[2].Value.ToString();
            txt_Product_Price.Text = dg_Products_Database.Rows[rowIndex].Cells[3].Value.ToString();

            
        }

        private void Btn_Update_Click(object sender, EventArgs e)
        {
            p.Product_Id = Convert.ToInt32(txt_Product_Id.Text);
            p.Product_Name = txt_Product_Name.Text;
            p.Product_Category= txt_Product_Category.Text;
            p.Product_Price = Convert.ToDecimal(txt_Product_Price.Text);


            bool success = PD.Update(p);
            if (success)
            {
                MessageBox.Show("Product Updated Successfully", "Data Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Clear();
                DataTable DT = PD.Select();
                dg_Products_Database.DataSource = DT;
            }
            else
            {
                MessageBox.Show("Process Failed\nTry Again!!", "Invalid Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Btn_Delete_Click(object sender, EventArgs e)
        {
            p.Product_Id = Convert.ToInt32(txt_Product_Id.Text);

            bool success = PD.Delete(p);
            if (success == true)
            {
                MessageBox.Show("Product Deleted Successfully", "Data Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Clear();
                DataTable DT = PD.Select();
                dg_Products_Database.DataSource = DT;
            }
            else
            {
                MessageBox.Show("Process Failed\nTry Again!!", "Invalid Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txt_Search_TextChanged(object sender, EventArgs e)
        {
            string keywords = txt_Search.Text;

            if (keywords != null )
            {
                DataTable DT = PD.Search(keywords);
                dg_Products_Database.DataSource = DT;
            }
            else 
            {
                DataTable DT = PD.Select();
                dg_Products_Database.DataSource = DT;
            }
        }
    }
}
