using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Invoice_Billing_Software
{
    public partial class Login_Page : Form
    {
        public Login_Page()
        {
            InitializeComponent();

            string hexColor = "#375AAB";
            Color TextColour = System.Drawing.ColorTranslator.FromHtml(hexColor);

            Date_Label.Text = DateTime.Now.ToShortDateString();
            Lbl_Login.ForeColor = TextColour;
            Btn_Login.ForeColor = TextColour;

            timer1.Start();
        }

        static string MyConn = ConfigurationManager.ConnectionStrings["Software_Database"].ConnectionString;
        public static string User_Type;

        private void timer1_Tick(object sender, EventArgs e)
        {
            Time_Label.Text = DateTime.Now.ToString("T");
        }

        private void Btn_Login_Click(object sender, EventArgs e)
        {


            if (txt_UserName.Text == "")
            {
                MessageBox.Show("Please Enter Username!!", "Empty Username", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return;
            }
            else if (txt_Password.Text == "")
            {
                MessageBox.Show("Please Enter Password!!", "Empty Password", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return;
            }
            try
            {
                SqlConnection SCONN = new SqlConnection(MyConn);
                SqlDataAdapter SDA = new SqlDataAdapter("Select * From Login_Table Where Username Like'" + txt_UserName.Text.ToString() + "' COLLATE SQL_Latin1_General_CP1_CS_AS and password = '" + txt_Password.Text.ToString() + "' ", SCONN);
                DataTable DT = new DataTable();
                SDA.Fill(DT);
                if (DT.Rows.Count == 1)
                {
                    User_Type = DT.Rows[0]["User_Type"].ToString();
                    if (User_Type == "Admin")
                    {
                        MessageBox.Show("Welcome Admin", "Login Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Home_Page.User_Type = txt_UserName.Text + " !!";
                        Invoice_Page.User_Type = txt_UserName.Text + " !!";
                        Products_Page.User_Type = txt_UserName.Text + " !!";
                        Expenses_Page.User_Type = txt_UserName.Text + " !!";
                        Customers_Page.User_Type = txt_UserName.Text + " !!";
                        Staff_Page.User_Type = txt_UserName.Text + " !!";
                        Reports_Page.User_Type = txt_UserName.Text + " !!"; ;
                    }
                    else if (User_Type == "User")
                    {
                        MessageBox.Show("Welcome User", "Login Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Home_Page.User_Type = txt_UserName.Text + " !!";
                        Invoice_Page.User_Type = txt_UserName.Text + " !!";
                        Products_Page.User_Type = txt_UserName.Text + " !!";
                        Expenses_Page.User_Type = txt_UserName.Text + " !!";
                        Customers_Page.User_Type = txt_UserName.Text + " !!";
                        Staff_Page.User_Type = txt_UserName.Text + " !!";
                        Reports_Page.User_Type = txt_UserName.Text + " !!"; ;
                    }
                    Home_Page HM = new Home_Page();
                    HM.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Username or Password is Incorrect. \nPlease Re-Enter it!!", "Invalid Credentials", MessageBoxButtons.OKCancel, MessageBoxIcon.Hand);
                    txt_UserName.Text = "";
                    txt_Password.Text = "";
                    txt_UserName.Focus();
                }
            }
            catch (Exception ex)
            {
                    MessageBox.Show(ex.Message);
            }
            

        }
    }
}
