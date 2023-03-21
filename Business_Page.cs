using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using Invoice_Billing_Software.BLL_Business_Logic_Layer_;
using Invoice_Billing_Software.DAL_Data_Access_Layer_;

namespace Invoice_Billing_Software
{
    public partial class Business_Page : Form
    {
        public Business_Page()
        {
            InitializeComponent();
            string hexColor = "#375AAB";
            Color TextColour = System.Drawing.ColorTranslator.FromHtml(hexColor);

            Lbl_Business_Page.ForeColor= TextColour;
        }

        private string imagePath;

        private void btn_Browse_Image_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Load the image into the PictureBox control
                ptb_Business_logo.Image = Image.FromFile(openFileDialog.FileName);
                ptb_Business_logo.SizeMode = PictureBoxSizeMode.Zoom;

                // Save the image file path to the string variable
                imagePath = openFileDialog.FileName;
            }

        }

        private void btn_Save_Click(object sender, EventArgs e)
        {

            string businessName = txt_Business_Name.Text;
            string businessAddress = txt_Businness_Address.Text;
            string businessContact1 = txt_Contact_Number.Text;
            string businessContact2 = txt_Conatct_Number_2.Text;
            string businessEmail = txt_Email_Address.Text;
            string businessWebsite = txt_Website.Text;


            string MyConn = ConfigurationManager.ConnectionStrings["Software_Database"].ConnectionString;
            using (SqlConnection SCONN = new SqlConnection(MyConn))
            {
                SCONN.Open();

                using (SqlCommand command = new SqlCommand("INSERT INTO Business_Details (Business_Name, Business_Address, Business_Contact_1, Business_Contact_2, Business_Email_Address, Business_Website, Business_Logo) VALUES (@Business_Name, @Business_Address, @Business_Contact_1, @Business_Contact_2, @Business_Email_Address, @Business_Website, @Business_Logo)", SCONN))
                {
                    command.Parameters.AddWithValue("@Business_Name", businessName);
                    command.Parameters.AddWithValue("@Business_Address", businessAddress);
                    command.Parameters.AddWithValue("@Business_Contact_1", businessContact1);
                    command.Parameters.AddWithValue("@Business_Contact_2", businessContact2);
                    command.Parameters.AddWithValue("@Business_Email_Address", businessEmail);
                    command.Parameters.AddWithValue("@Business_Website", businessWebsite);
                    command.Parameters.AddWithValue("@Business_Logo", File.ReadAllBytes(imagePath));

                    command.ExecuteNonQuery();
                }
            }

            

            MessageBox.Show("Record saved successfully.");
        
        }

        private void Clear()
        {
            txt_Business_Name.Text = "";
            txt_Businness_Address.Text = "";
            txt_Contact_Number.Text = "";
            txt_Conatct_Number_2.Text = "";
            txt_Email_Address.Text = "";
            txt_Website.Text = "";
            ptb_Business_logo.Image = null;
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Home_Page HP = new Home_Page();
            HP.Show();
            this.Close();
        }
    }
}
