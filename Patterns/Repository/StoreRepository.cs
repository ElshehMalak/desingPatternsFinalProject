using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DeliverySystem.Patterns.Creational;
using desingPatternsFinalProject.Patterns.Creational; 

public class StoreRepository
{
    public List<Store> GetStoresByCategory(string categoryFilter)
    {
        List<Store> list = new List<Store>();

        using (SqlConnection conn = DatabaseManager.GetConnection())
        {
            string query = "";

            if (categoryFilter == "Mix")
            {
                query = "SELECT * FROM Places WHERE Category IN ('Restaurant', 'Cafe' )";
            }
            else
            {
                query = "SELECT * FROM Places WHERE Category = @Cat";
            }

            SqlCommand cmd = new SqlCommand(query, conn);

            if (categoryFilter != "Mix")
            {
                cmd.Parameters.AddWithValue("@Cat", categoryFilter);
            }

            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Store s = new Store();

                    s.ID = Convert.ToInt32(reader["StoreID"]);
                    s.Name = reader["Name"].ToString();

                    // نقرأ التصنيف كنص ونحطوه في String Category
                    s.Category = reader["Category"].ToString();

                    s.Rating = Convert.ToDecimal(reader["Rating"]);
                    s.DeliveryFee = Convert.ToDecimal(reader["DeliveryFee"]);
                    /*
                    if (reader["ImagePath"] != DBNull.Value)
                        s.ImagePath = reader["ImagePath"].ToString();
                    */

                    list.Add(s);
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error: " + ex.Message);
            }
        }
        return list;
    }
    public List<Product> GetProductsByStore(int storeId)
    {
        List<Product> products = new List<Product>();

        using (SqlConnection conn = DatabaseManager.GetConnection())
        {
            string query = "SELECT Name, Price FROM Products WHERE StoreID = @PID";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@PID", storeId);

            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Product p = new Product();
                    p.Name = reader["Name"].ToString();
                    p.Price = Convert.ToDecimal(reader["Price"]);
                    products.Add(p);
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }
        return products;
    }
}
