using Invoice_Billing_Software.BLL_Business_Logic_Layer_;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Invoice_Billing_Software.BLL_Business_Logic_Layer_;

namespace Invoice_Billing_Software.DAL_Data_Access_Layer_
{
    internal class Staff_DAL
    {
        static string MyConn = ConfigurationManager.ConnectionStrings["Software_Database"].ConnectionString;

        #region Select Staff Data from Database

        public DataTable Select()
        {
            SqlConnection SCONN = new SqlConnection(MyConn);
            DataTable DT1 = new DataTable();
            DataTable DT2 = new DataTable();
            Staff SBAL = new Staff();

            try
            {
               
                string SQL_Query = @"SELECT 
                                Staff_Table.Staff_Id, 
                                Staff_Table.Staff_Name, 
                                Staff_Table.Staff_Contact_Number,  
                                Staff_Table.Staff_Salary,
                                Login_Table.Username,
                                Login_Table.Password, 
                                Login_Table.User_Type 
                             FROM 
                                Staff_Table 
                             INNER JOIN 
                                Login_Table 
                             ON 
                                Staff_Table.Staff_Id = Login_Table.Login_Id";
                SqlCommand SCMD1 = new SqlCommand(SQL_Query, SCONN);
                
                SqlDataAdapter SDA1 = new SqlDataAdapter(SCMD1);
                
                SCONN.Open();
                SDA1.Fill(DT1);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                SCONN.Close();
            }

            return DT1;


        }

        #endregion

        #region Insert Staff to Database

        public bool Insert(Staff S)
        {
            bool isSuccess = false;
            SqlConnection SCONN = new SqlConnection(MyConn);

            try
            {
                string SQL_Query1 = "INSERT INTO Staff_Table(Staff_Name, Staff_Contact_Number, Staff_Salary) VALUES (@Staff_Name, @Staff_Contact_Number, @Staff_Salary)";
                string SQL_Query2 = "INSERT INTO Login_Table(Username, Password, User_Type) VALUES (@Username, @Password, @User_Type)";

                SqlCommand SCMD1 = new SqlCommand(SQL_Query1, SCONN);
                SqlCommand SCMD2 = new SqlCommand(SQL_Query2, SCONN);
                SCMD1.Parameters.AddWithValue("@Staff_Name", S.Staff_Name);
                SCMD1.Parameters.AddWithValue("@Staff_Contact_Number", S.Staff_Contact_Number);
                //SCMD1.Parameters.AddWithValue("@Staff_Joining_Date", S.Staff_Joining_Date);
                SCMD1.Parameters.AddWithValue("@Staff_Salary", S.Staff_Salary);
                SCMD2.Parameters.AddWithValue("@Username", S.Username);
                SCMD2.Parameters.AddWithValue("@Password", S.Password);
                SCMD2.Parameters.AddWithValue("@User_Type", S.User_Type);

                SCONN.Open();

                
                int rows1 = SCMD1.ExecuteNonQuery();
                int rows2 = SCMD2.ExecuteNonQuery();

                if (rows1 > 0 && rows2 > 0)
                {
                    isSuccess = true;
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

        #region Update Staff in Database

        public bool Update(Staff S)
        {
            bool isSuccess = false;
            SqlConnection SCONN = new SqlConnection(MyConn);

            try
            {
                string SQL_Query1 = "UPDATE Staff_Table SET Staff_Name = @Staff_Name, Staff_Contact_Number = @Staff_Contact_Number, Staff_Salary = @Staff_Salary WHERE Staff_Id = @Staff_Id";
                string SQL_Query2 = "UPDATE Login_Table SET Username = @Username, Password= @Password, User_Type= @User_Type WHERE Login_Id = @Staff_Id";
                SqlCommand SCMD1 = new SqlCommand(SQL_Query1, SCONN);
                SqlCommand SCMD2 = new SqlCommand(SQL_Query2, SCONN);

                SCMD1.Parameters.AddWithValue("@Staff_Id", S.Staff_Id);
                SCMD1.Parameters.AddWithValue("@Staff_Name", S.Staff_Name);
                SCMD1.Parameters.AddWithValue("@Staff_Contact_Number", S.Staff_Contact_Number);
                //SCMD1.Parameters.AddWithValue("@Staff_Joining_Date", S.Staff_Joining_Date);
                SCMD1.Parameters.AddWithValue("@Staff_Salary", S.Staff_Salary);
                SCMD2.Parameters.AddWithValue("@Staff_Id", S.Staff_Id);
                SCMD2.Parameters.AddWithValue("@Username", S.Username);
                SCMD2.Parameters.AddWithValue("@Password", S.Password);
                SCMD2.Parameters.AddWithValue("@User_Type", S.User_Type);

                SCONN.Open();

                int rows1 = SCMD1.ExecuteNonQuery();
                int rows2 = SCMD2.ExecuteNonQuery();
                if (rows1 > 0 && rows2>0)
                {
                    isSuccess = true;
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

        #region Delete Customers from Database

        public bool Delete(Staff S)
        {
            bool isSuccess = false;
            SqlConnection SCONN = new SqlConnection(MyConn);

            try
            {
                string SQL_Query1 = "DELETE From Staff_Table WHERE Staff_Id = @Staff_Id";
                string SQL_Query2 = "DELETE From Login_Table WHERE Login_Id = @Staff_Id";
                SqlCommand SCMD1 = new SqlCommand(SQL_Query1, SCONN);
                SqlCommand SCMD2 = new SqlCommand(SQL_Query2, SCONN);

                SCMD1.Parameters.AddWithValue("@Staff_Id", S.Staff_Id);
                SCMD2.Parameters.AddWithValue("@Staff_Id", S.Staff_Id);
                SCONN.Open();

                int rows1 = SCMD1.ExecuteNonQuery();
                int rows2 = SCMD2.ExecuteNonQuery();

                if (rows1 > 0 && rows2 > 0)
                {
                    isSuccess = true;
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

        #region Search Staff from Database

        public DataTable Search(string keywords)
        {
            SqlConnection SCONN = new SqlConnection(MyConn);
            DataTable DT = new DataTable();

            try
            {
                string SQL_QUERY1 = "SELECT * FROM Staff_Table Where Staff_Name Like '%" + keywords + "%' OR Staff_Contact_Number Like '%" + keywords + "%' OR Staff_Salary Like '%" + keywords + "%' OR Staff_Id Like '%" + keywords + "%' ";
                string SQL_QUERY2 = "SELECT * FROM Login_Table Where Login_Id like '%" + keywords + "%' ";
                SqlCommand SCMD2 = new SqlCommand(SQL_QUERY2, SCONN);
                SqlCommand SCMD1 = new SqlCommand(SQL_QUERY1, SCONN);
                SqlDataAdapter SDA1 = new SqlDataAdapter(SCMD1);
                SqlDataAdapter SDA2 = new SqlDataAdapter(SCMD2);
                SCONN.Open();
                SDA1.Fill(DT);
                SDA2.Fill(DT);


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
    }
}
