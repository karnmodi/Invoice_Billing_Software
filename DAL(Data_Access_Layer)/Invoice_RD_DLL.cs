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
    internal class Invoice_RD_DLL
    {
        static string Myconn = ConfigurationManager.ConnectionStrings["Software_Database"].ConnectionString;
        

        #region Insert DATA
        
        public bool Insert_Transaction(Invoice_RD IRD)
        {
            bool isSuccess = false;
            SqlConnection SCONN = new SqlConnection(Myconn);

            try
            {
                string SQL_QUERY = "INSERT INTO Invoice_Row_Data_Table(Product_Id, Product_Price, Quantity, Amount, Customer_Id, Added_Date, Added_By) VALUES (@Product_Id, @Product_Price, @Quantity, @Amount, @Customer_Id, @Added_Date, @Added_By)";
                SqlCommand SCMD = new SqlCommand(SQL_QUERY, SCONN);

                SCMD.Parameters.AddWithValue("@Product_Id", IRD.Product_Id);
                SCMD.Parameters.AddWithValue("@Product_Price", IRD.Product_Price);
                SCMD.Parameters.AddWithValue("@Quantity", IRD.Quantity);
                SCMD.Parameters.AddWithValue("@Amount", IRD.Amount);
                SCMD.Parameters.AddWithValue("@Customer_Id", IRD.Customer_Id);
                SCMD.Parameters.AddWithValue("@Added_Date", IRD.Added_Date);
                SCMD.Parameters.AddWithValue("@Added_By", IRD.Added_By);

                SCONN.Open();

                int rows = SCMD.ExecuteNonQuery();
                if(rows > 0)
                {
                    isSuccess= true;
                }
                else
                {
                    isSuccess = false;
                }
            }
            catch (Exception ex)
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
