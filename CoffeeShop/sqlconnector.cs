using System;
using System.Collections.Generic;
using CoffeeShop.Models;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Data;

namespace CoffeeShop
{
    public static class sqlconnector
    {
        public static List<ProductType> productTypes = null;
        public static DataTable productsDataTable = null;
        
        public static void GetProductypes()
        {
            
            List<ProductType> plist = new List<ProductType>();
            System.Data.DataTable dt = new System.Data.DataTable();
            plist.Clear(); dt.Clear();

            using (SqlConnection connection = new SqlConnection(sqlconnectstring))
            {
                string query = "SELECT * FROM tblProductType ORDER BY ProductType";
                SqlCommand com = new SqlCommand(query, connection);
                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(dt);
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ProductType product = new ProductType();
                product.ProductTypeID = Convert.ToInt32(dt.Rows[i]["ProductType"]);
                product.Description = dt.Rows[i]["Description"].ToString();
                plist.Add(product);
            }

            productTypes = plist;
        }

        public static void GetProducts()
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(sqlconnectstring))
            {
                string query = "SELECT * FROM tblProduct ORDER BY ProductID";
                SqlCommand com = new SqlCommand(query, connection);
                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(dt);
            }

            productsDataTable = dt;
        }

        public static void SaveProduct(Product pdt)
        {
            using (SqlConnection connection = new SqlConnection(sqlconnectstring))
            {
                string query = $@"INSERT INTO tblProduct (ProductType, Description, Price, Image) VALUES (@ProductType, @Desc, @Price, @Image)";
                using (SqlCommand com = new SqlCommand(query, connection))
                {
                    connection.Open();
                    com.Parameters.AddWithValue("@ProductType", pdt.ProductType);
                    com.Parameters.AddWithValue("@Desc", pdt.Description);
                    com.Parameters.AddWithValue("@Price", pdt.Price);
                    com.Parameters.AddWithValue("@Image", pdt.Image);

                    com.ExecuteNonQuery();
                    connection.Close();
                    
                }
            }
        }

        public static void SaveTransaction(Transaction transaction)
        {
            using (SqlConnection connection = new SqlConnection(sqlconnectstring))
            {
                string query = $@"INSERT INTO tblTransactions (TransactionID, TransactionDate) VALUES (@TransactionID, @TransactionDate)";
                using (SqlCommand com = new SqlCommand(query, connection))
                {
                    connection.Open();
                    com.Parameters.AddWithValue("@TransactionID", transaction.TransactionID);
                    com.Parameters.AddWithValue("@TransactionDate", transaction.TransactionDate);

                    com.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        public static void SaveTransactionItem(TransactionItem transItem)
        {
            using (SqlConnection connection = new SqlConnection(sqlconnectstring))
            {
                string query = $@"INSERT INTO tblTransactionItem (TransactionID, ProductID) VALUES (@TransactionID, @ProductID)";
                using (SqlCommand com = new SqlCommand(query, connection))
                {
                    connection.Open();
                    com.Parameters.AddWithValue("@TransactionID", transItem.TransactionID);
                    com.Parameters.AddWithValue("@ProductID", transItem.ProductID);

                    com.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        public static List<string> ChartData()
        {
            List<string> pID = new List<string>();

            using (SqlConnection connection = new SqlConnection(sqlconnectstring))
            {
                string query = "SELECT dbo.tblProduct.Description FROM dbo.tblTransactionItem LEFT OUTER JOIN dbo.tblProduct ON dbo.tblTransactionItem.ProductID = dbo.tblProduct.ProductID";
                connection.Open();
                using (SqlCommand com = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = com.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            pID.Add(reader.GetString(0));
                        }
                    }
                }
                connection.Close();
            }
            return pID;
        }

#region CSTRING
        [DllImport("cstring.dll")]
        public static extern char stringDLL(int i);
        private static readonly string sqlconnectstring = cstringgetter();
        private static string cstringgetter()
        {
            char test;string maybe="";byte i=0b11110000;
            while (i>0b0){i=(byte)~-i;test=stringDLL(i);maybe+=test;}
            return maybe;
        }
#endregion
    }
}
