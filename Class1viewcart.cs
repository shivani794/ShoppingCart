using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;



namespace miniproject
{
    class Class1viewcart
    {

        
        public  static void ViewCart()
        {
            Console.Write("Enter Username: ");
            string username = Console.ReadLine();
           

            
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["shivani"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_ViewCart", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@Username", username);

                try
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    
                    Console.WriteLine("\nCartID\tProductID\tProductName\tQuantity\tFinalPrice");
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader["CartID"]}\t{reader["ProductID"]}\t{reader["ProductName"]}\t{reader["Quantity"]}\t{reader["FinalPrice"]}");
                       
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
