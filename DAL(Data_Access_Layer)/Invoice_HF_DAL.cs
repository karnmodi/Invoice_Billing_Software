using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Invoice_Billing_Software.BLL_Business_Logic_Layer_;

namespace Invoice_Billing_Software.DAL_Data_Access_Layer_
{
    internal class Invoice_HF_DAL
    {
        static string MyConn = ConfigurationManager.ConnectionStrings["Software_Database"].ConnectionString;


        #region INSERT Invoice 

        public bool Insert(Invoice_HF IHF, out int Invoice_Id)
        {
            bool isSuccess = false;

            SqlConnection SCONN = new SqlConnection(MyConn);
            Invoice_Id = -1;

            try
            {
                string SQL_QUERY = "INSERT INTO Invoice_Header_Footer_Table (Customer_Id, Grand_Total, Invoice_Date, Tax, Discount, Added_By) VALUES (@Customer_Id, @Grand_Total, @Invoice_Date, @Tax, @Discount, @Added_By); SELECT @@IDENTITY;" ;
                SqlCommand SCMD = new SqlCommand(SQL_QUERY, SCONN);
                SCMD.Parameters.AddWithValue("@Customer_Id", IHF.Customer_Id);
                SCMD.Parameters.AddWithValue("@Grand_Total", IHF.Grand_Total);
                SCMD.Parameters.AddWithValue("@Invoice_Date", IHF.Invoice_Date);
                SCMD.Parameters.AddWithValue("@Tax", IHF.Tax);
                SCMD.Parameters.AddWithValue("@Discount", IHF.Discount);
                SCMD.Parameters.AddWithValue("@Added_By", IHF.Added_By);

                SCONN.Open();

                Object O = SCMD.ExecuteScalar();

                if(O != null)
                {
                    Invoice_Id =Convert.ToInt32(O.ToString());
                    isSuccess= true;
                }
                else
                {
                    isSuccess= false;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                SCONN.Close();
            }
            
            return isSuccess;
        }

        #endregion
    }
}
