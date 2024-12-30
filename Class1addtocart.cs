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
   
class Class1addtocart
    {
        public void AddToCart()
        {
            Console.Write("Enter ProductID: ");
            int productId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Username: ");
            string username = Console.ReadLine();
            Console.Write("Enter Quantity: ");
         
            int quantity = Convert.ToInt32(Console.ReadLine());
            
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["shivani"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_AddToCart", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@ProductID", productId);
              cmd.Parameters.AddWithValue("@Quantity", quantity);
                cmd.Parameters.AddWithValue("@Username", username);

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Product added to cart.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }

    }
}


