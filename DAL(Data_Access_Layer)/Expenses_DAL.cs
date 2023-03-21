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
    internal class Expenses_DAL
    {
        static string MyConn = ConfigurationManager.ConnectionStrings["Software_Database"].ConnectionString;

        #region Select Data from Database
        public DataTable Select()
        {
            SqlConnection SCONN = new SqlConnection(MyConn);
            DataTable DT = new DataTable();

            try
            {
                string Sql_Query = "Select * From Expense_Table";
                SqlCommand SCMD = new SqlCommand(Sql_Query, SCONN);
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

        #region Insert Data from Database

        public bool Insert(Expenses E)
        {
            bool issuccess = false;
            SqlConnection SCONN = new SqlConnection(MyConn);

            try
            {
                string Sql_Query = "INSERT INTO Expense_Table (Expense_Description, Expense_Category, Expense_Amount, Authorised_By) VALUES (@Expense_Description, @Expense_Category, @Expense_Amount, @Authorised_By)";
                SqlCommand SCMD = new SqlCommand(Sql_Query, SCONN);

                SCMD.Parameters.AddWithValue("@Expense_Description", E.Expense_Description);
                SCMD.Parameters.AddWithValue("@Expense_Category", E.Expense_Category);
                SCMD.Parameters.AddWithValue("@Expense_Amount", E.Expense_Amount);
                SCMD.Parameters.AddWithValue("@Authorised_By",E.Authorised_By);

                SCONN.Open();

                int rows = SCMD.ExecuteNonQuery();

                if (rows > 0)
                {
                    issuccess = true;
                }
                else
                {
                    issuccess = false;
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
            return issuccess;
        }


        #endregion

        #region Update Data in Database

        public bool Update(Expenses E)
        {
            bool issuccess = false;

            SqlConnection SCONN = new SqlConnection(MyConn);

            try
            {
                string SQL_Query = "UPDATE Expense_Table SET Expense_Description = @Expense_Description, Expense_Category = @Expense_Category, Expense_Amount=  @Expense_Amount, Authorised_By = @Authorised_By WHERE Expense_Id = @Expense_Id";
                SqlCommand SCMD = new SqlCommand(SQL_Query, SCONN);


                SCMD.Parameters.AddWithValue("@Expense_Id", E.Expense_Id);
                SCMD.Parameters.AddWithValue("@Expense_Description", E.Expense_Description);
                SCMD.Parameters.AddWithValue("@Expense_Category", E.Expense_Category);
                SCMD.Parameters.AddWithValue("@Expense_Amount", E.Expense_Amount);
                SCMD.Parameters.AddWithValue("@Authorised_By", E.Authorised_By);

                SCONN.Open();

                int rows = SCMD.ExecuteNonQuery();

                if (rows > 0)
                {
                    issuccess = true;
                }
                else
                {
                    issuccess = false;
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

            return issuccess;
        }

        #endregion

        #region Delete Data from Database

        public bool Delete(Expenses E)
        {
            bool issuccess = false;
            SqlConnection SCONN = new SqlConnection(MyConn);

            try
            {
                string SQL_Query = "DELETE FROM Expense_Table WHERE Expense_Id = @Expense_Id";
                SqlCommand SCMD = new SqlCommand(SQL_Query, SCONN);
                SCMD.Parameters.AddWithValue("@Expense_Id", E.Expense_Id);
                SCONN.Open();

                int rows = SCMD.ExecuteNonQuery();
                if (rows > 0)
                {
                    issuccess = true;
                }
                else
                {
                    issuccess = false;
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

            return issuccess;


        }

        #endregion

        #region Search Data From Database

        public DataTable Search(string keywords)
        {
            SqlConnection SCONN = new SqlConnection(MyConn);
            DataTable DT = new DataTable();

            try
            {
                string Sql_Query = "SELECT * FROM Expense_Table WHERE Expense_Description LIKE '%" + keywords + "%' OR Expense_Amount LIKE '%" + keywords + "%' OR Expense_Category LIKE '%" + keywords + "%' OR Expense_Id LIKE '%" + keywords + "%'";
                SqlCommand SCMD = new SqlCommand(Sql_Query, SCONN);
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
    }
}
