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
    internal class Products_DAL
    {
        static string MyConn = ConfigurationManager.ConnectionStrings["Software_Database"].ConnectionString;

        #region Select Data from Database
        public DataTable Select()
        {
            SqlConnection SCONN = new SqlConnection(MyConn);
            DataTable DT = new DataTable();

            try
            {
                string Sql_Query = "Select * From Products_Table";
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

        public bool Insert(Products p)
        {
            bool issuccess = false;
            SqlConnection SCONN = new SqlConnection(MyConn);

            try
            {
                string Sql_Query = "INSERT INTO Products_Table (Product_Name, Product_Category, Product_Price) VALUES (@Product_Name, @Product_Category, @Product_Price)";
                SqlCommand SCMD = new SqlCommand(Sql_Query, SCONN);

                SCMD.Parameters.AddWithValue("@Product_Name", p.Product_Name);
                SCMD.Parameters.AddWithValue("@Product_Category", p.Product_Category);
                SCMD.Parameters.AddWithValue("@Product_Price", p.Product_Price);

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

        public bool Update(Products p)
        {
            bool issuccess = false;

            SqlConnection SCONN = new SqlConnection(MyConn);

            try
            {
                string SQL_Query = "UPDATE Products_Table SET Product_Name = @Product_Name, Product_Category = @Product_Category, Product_Price = @Product_Price WHERE Product_Id = @Product_Id";
                SqlCommand SCMD = new SqlCommand(SQL_Query, SCONN);


                SCMD.Parameters.AddWithValue("@Product_Id", p.Product_Id);
                SCMD.Parameters.AddWithValue("@Product_Name", p.Product_Name);
                SCMD.Parameters.AddWithValue("@Product_Category", p.Product_Category);
                SCMD.Parameters.AddWithValue("@Product_Price", p.Product_Price);

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

        public bool Delete(Products p)
        {
            bool issuccess = false;
            SqlConnection SCONN = new SqlConnection(MyConn);

            try
            {
                string SQL_Query = "DELETE FROM Products_Table WHERE Product_Id = @Product_Id";
                SqlCommand SCMD = new SqlCommand(SQL_Query, SCONN);
                SCMD.Parameters.AddWithValue("@Product_Id", p.Product_Id);
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
                string Sql_Query = "SELECT * FROM Products_Table WHERE Product_Name LIKE '%" + keywords + "%' OR Product_Price LIKE '%"+keywords+"%' OR Product_Category LIKE '%"+keywords+"%' OR Product_Id LIKE '%"+keywords+"%'";
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

        #region Search Products From Invoice
        
        public Products Search_Products_for_Invoice(String keywords)
        {
            Products PBLL = new Products();

            SqlConnection SCONN = new SqlConnection(MyConn);

            DataTable DT = new DataTable();

            try
            {
                string SQL_Query = "SELECT Product_Name, Product_Price FROM Products_Table Where Product_Id Like '%" + keywords + "%' OR Product_Name Like '%" + keywords + "%'";
                SqlCommand SCMD = new SqlCommand(SQL_Query, SCONN);
                SqlDataAdapter SDA = new SqlDataAdapter(SCMD);

                SCONN.Open();

                SDA.Fill(DT);

                if (DT.Rows.Count > 0)
                {
                    PBLL.Product_Name = DT.Rows[0]["Product_Name"].ToString();
                    PBLL.Product_Price = Convert.ToDecimal(DT.Rows[0]["Product_Price"].ToString());
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

            return PBLL;

        }

        #endregion

        #region Method to get Product ID from Invoice Page

        public Products Get_Product_Id_from_Name_in_Invoice_Table(string Product_Name)
        {
            Products PBLL = new Products();

            SqlConnection SCONN = new SqlConnection(MyConn);

            DataTable DT = new DataTable();

            try
            {
                string SQL_Query = "Select Product_Id From Products_Table Where Product_Name Like '%" + Product_Name + "%'";

                SqlCommand SCMD = new SqlCommand(SQL_Query, SCONN);

                SqlDataAdapter SDA = new SqlDataAdapter(SCMD);


                SCONN.Open();
                SDA.Fill(DT);

                if (DT.Rows.Count > 0)
                {
                    PBLL.Product_Id= Convert.ToInt32(DT.Rows[0]["Product_Id"].ToString());
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
            return PBLL;
        }

        #endregion

    }
}
