using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Invoice_Billing_Software.BLL_Business_Logic_Layer_;

namespace Invoice_Billing_Software.DAL_Data_Access_Layer_
{
    internal class Customers_DAL
    {
        static string MyConn = ConfigurationManager.ConnectionStrings["Software_Database"].ConnectionString;

        #region Select Customers Data from Database
        
        public DataTable Select()
        {
            SqlConnection SCONN = new SqlConnection(MyConn);
            DataTable DT = new DataTable();

            try
            {
                string SQL_Query = "SELECT * FROM Customer_Table";
                SqlCommand SCMD = new SqlCommand(SQL_Query, SCONN);
                SqlDataAdapter SDA = new SqlDataAdapter(SCMD);
                SCONN.Open();
                SDA.Fill(DT);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                SCONN.Close();
            }

            return DT;


        }

        #endregion

        #region Insert Customers to Database

        public bool Insert(Customers C)
        {
            bool isSuccess = false;
            SqlConnection SCONN = new SqlConnection(MyConn);

            try
            {
                string SQL_Query = "INSERT INTO Customer_Table(Customer_First_Name, Customer_Last_Name, Customer_Mobile_Number, Customer_Email_Address, Customer_Address) VALUES (@Customer_First_Name, @Customer_Last_Name, @Customer_Mobile_Number, @Customer_Email_Address, @Customer_Address)";
                SqlCommand SCMD = new SqlCommand(SQL_Query, SCONN);
                SCMD.Parameters.AddWithValue("@Customer_First_Name", C.Customer_First_Name);
                SCMD.Parameters.AddWithValue("@Customer_Last_Name", C.Customer_Last_Name);
                SCMD.Parameters.AddWithValue("@Customer_Mobile_Number", C.Customer_Mobile_Number);
                SCMD.Parameters.AddWithValue("@Customer_Email_Address", C.Customer_Email_Address);
                SCMD.Parameters.AddWithValue("@Customer_Address", C.Customer_Address);

                SCONN.Open();

                int rows = SCMD.ExecuteNonQuery();
                if(rows > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess= false;
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

        #region Update Customers in Database
        
        public bool Update(Customers C)
        {
            bool isSuccess = false;
            SqlConnection SCONN = new SqlConnection(MyConn);

            try
            {
                string SQL_Query = "UPDATE Customer_Table SET Customer_First_Name = @Customer_First_Name, Customer_Last_Name = @Customer_Last_Name, Customer_Mobile_Number = @Customer_Mobile_Number, Customer_Email_Address = @Customer_Email_Address, Customer_Address = @Customer_Address WHERE Customer_Id = @Customer_Id";
                SqlCommand SCMD = new SqlCommand(SQL_Query, SCONN );

                SCMD.Parameters.AddWithValue("@Customer_Id", C.Customer_Id);
                SCMD.Parameters.AddWithValue("@Customer_First_Name", C.Customer_First_Name);
                SCMD.Parameters.AddWithValue("@Customer_Last_Name", C.Customer_Last_Name);
                SCMD.Parameters.AddWithValue("@Customer_Mobile_Number", C.Customer_Mobile_Number);
                SCMD.Parameters.AddWithValue("@Customer_Email_Address", C.Customer_Email_Address);
                SCMD.Parameters.AddWithValue("@Customer_Address", C.Customer_Address);
                
                SCONN.Open() ;

                int rows = SCMD.ExecuteNonQuery();
                if(rows > 0)
                {
                    isSuccess= true;
                }
                else
                {
                    isSuccess= false;
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

        #region Delete Customers from Database
        
        public bool Delete(Customers C)
        {
            bool isSuccess = false;
            SqlConnection SCONN = new SqlConnection(MyConn);

            try
            {
                string SQL_Query = "DELETE From Customer_Table WHERE Customer_Id = @Customer_Id";
                SqlCommand SCMD = new SqlCommand(SQL_Query, SCONN );

                SCMD.Parameters.AddWithValue("@Customer_Id", C.Customer_Id);
                SCONN.Open();

                int rows = SCMD.ExecuteNonQuery();
                if(rows > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess= false;
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

        #region Search Customer from Database
        
        public DataTable Search(string keywords)
        {
            SqlConnection SCONN = new SqlConnection(MyConn);
            DataTable DT = new DataTable();

            try
            {
                string SQL_QUERY = "SELECT * FROM Customer_Table Where Customer_First_Name Like '%" + keywords + "%' OR Customer_Last_Name Like '%" + keywords + "%' OR Customer_Mobile_Number Like '%" + keywords + "%' OR Customer_Email_Address Like '%" + keywords + "%' OR Customer_Address Like '%" + keywords + "%' ";
                SqlCommand SCMD = new SqlCommand(SQL_QUERY, SCONN);
                SqlDataAdapter SDA = new SqlDataAdapter(SCMD);
                SCONN.Open();
                SDA.Fill(DT);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                SCONN.Close();
            }
            return DT;
            
        }

        #endregion

        #region Search Customer Name form Invoice Page
        
        public Customers Search_Customers_details_For_Invoice(string keywords)
        {
            Customers CBLL = new Customers();

            SqlConnection SCONN = new SqlConnection(MyConn);

            DataTable DT = new DataTable();

            try
            {
                string SQL_Query = "SELECT Customer_First_Name, Customer_Last_Name, Customer_Mobile_Number FROM Customer_Table WHERE Customer_First_Name Like '%"+ keywords + "%' OR Customer_Last_Name Like '%"+ keywords+"%' OR Customer_Mobile_Number Like '%" + keywords + "%' ";
                SqlCommand SCMD = new SqlCommand(SQL_Query, SCONN);

                SqlDataAdapter SDA =new SqlDataAdapter(SCMD);
                 
                SCONN.Open();

                SDA.Fill(DT);


                if (DT.Rows.Count > 0)
                {
                    CBLL.Customer_First_Name = DT.Rows[0]["Customer_First_Name"].ToString();
                    CBLL.Customer_Last_Name = DT.Rows[0]["Customer_Last_Name"].ToString();
                    CBLL.Customer_Mobile_Number = DT.Rows[0]["Customer_Mobile_Number"].ToString();
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

            return CBLL;
        }

        #endregion

        #region Method to get Customer ID from Invoice Page
        
         public Customers Get_Customer_ID_from_Name_in_Invoice_Table(string Name)
         {
            Customers CBLL = new Customers();

            SqlConnection SCONN = new SqlConnection(MyConn);

            DataTable DT = new DataTable();

            try
            {
                string SQL_Query = "Select Customer_ID From Customer_Table Where Customer_First_Name Like '%" + Name + "%'";

                SqlCommand SCMD = new SqlCommand(SQL_Query, SCONN);

                SqlDataAdapter SDA =new SqlDataAdapter(SCMD);


                SCONN.Open();
                SDA.Fill(DT);

                if(DT.Rows.Count > 0)
                {
                    CBLL.Customer_Id = Convert.ToInt32(DT.Rows[0]["Customer_ID"].ToString());
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
            return CBLL;
         }
        
        #endregion


    }
}
