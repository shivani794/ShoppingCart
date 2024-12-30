using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;


namespace miniproject
{
      class Class1login
    {
        public static bool IsLoginSuccessful = false;

        public static  void Login()
        {
            Console.Write("Enter Username: ");
            string username = Console.ReadLine();
            Console.Write("Enter Password: ");
            string password = Console.ReadLine();


            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["shivani"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_Login", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", password);

                try
                {
                    con.Open();
                    int userExists = (int)cmd.ExecuteScalar();

                   

                    if (userExists > 0)
                    {
                        IsLoginSuccessful = true;
                        Console.WriteLine("Login successful.");
                    }
                    else
                    {
                        IsLoginSuccessful = false;
                        Console.WriteLine("Invalid credentials.");
                       // Shopp 
                        return;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    IsLoginSuccessful = false;
                }
            }
        }

    }
}
