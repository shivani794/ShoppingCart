using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;



namespace miniproject
{
    public class Display
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["shivani"].ConnectionString;

        public static void DisplayProducts()
        {
            List<Product> products = new List<Product>();//generic class 

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_ProductList", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
              

                try
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Product product = new Product
                        {
                            ProductID = Convert.ToInt32(reader["ProductID"]),
                          
                            ProductName = reader["ProductName"].ToString(),
                            Price = Convert.ToDecimal(reader["Price"]),
                            Quantity = Convert.ToInt32(reader["Quantity"])
                        };

                        products.Add(product);
                    }

                    
                    Console.WriteLine("\nProductID\tProductName\tPrice\tQuantity");//represents tabular headers
                    Console.WriteLine("-------------------------------------------------");
                    foreach (var prod in products)
                    {

                        Console.WriteLine($"{prod.ProductID}    {prod.ProductName.PadRight(20)}   {prod.Price}   {prod.Quantity}");
                        Console.WriteLine("-------------------------------------------------");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
    }
}


