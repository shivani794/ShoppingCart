using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace miniproject
{
    class Shopp
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["shivani"].ConnectionString;

        static void Main(string[] args)
        {
           
            Class12ndloginverification.Start();

            while (true)                                              

                {
                Console.WriteLine("What do you want to view?");
                Console.WriteLine("1. View Products");
                Console.WriteLine("2. Add to Cart");
                Console.WriteLine("3. View Cart");
                Console.WriteLine("4. Place Order");
                Console.WriteLine("5. Exit");
                    Console.WriteLine("Enter your choice (1-5):");
                    int selection = Convert.ToInt32(Console.ReadLine());
                    if (selection < 1 || selection > 5)
                    {
                        Console.WriteLine("Invalid input. Please enter a number between 1 and 5.");

                    }
                    switch (selection)
                    {
                        case 1:
                        Display.DisplayProducts();
                        break;
                        case 2:
                            Class1addtocart objac = new Class1addtocart();
                            objac.AddToCart();
                            break;
                        case 3:
                        Class1viewcart.ViewCart();
                        break;
                        case 4:
                            Class1placeorder.PlaceOrder();
                            break;
                        case 5:
                            Console.WriteLine("Exiting the application. Goodbye!");
                            return; 
                        default:
                            Console.WriteLine("Invalid option. Please try again.");
                            break;
                    }
                }
            }
        }
    }

