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
    class Class1register
    {
        public static void Register()
        {
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Username: ");
            string username = Console.ReadLine();

            Console.Write("Enter Password: ");
            string password = Console.ReadLine();

            Console.Write("Enter Mobile Number: ");
            string mobileNumber = Console.ReadLine();

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["shivani"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_RegisterUser", con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", password);
                cmd.Parameters.AddWithValue("@MobileNumber", mobileNumber);
            
                try
                {
                    con.Open();
                //    int result = (int)cmd.ExecuteScalar();   
                //unboxing
                int result = Convert.ToInt32(cmd.ExecuteScalar());

                    if (result == 1)
                    {
                        Console.WriteLine("This username already exists. Please try another one.");

                    }
                    else
                    {
                        Console.WriteLine("Registration successful.");
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


       