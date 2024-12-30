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
    class Class1placeorder
    {
      public  static void PlaceOrder()
        {
            Console.Write("Enter Username: ");
            string username = Console.ReadLine();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["shivani"].ConnectionString))

            {
                SqlCommand cmd = new SqlCommand("usp_PlaceOrder", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@Username", username);

                try
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        Console.WriteLine($"\nThanks for shopping with us! Your total cost is: {reader["TotalCost"]}");
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

    