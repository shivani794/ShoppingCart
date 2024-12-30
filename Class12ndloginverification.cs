using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miniproject
{
    class Class12ndloginverification
    {
        public static void Start()
        {
                Console.WriteLine("Welcome to Shopping");
                Console.WriteLine("Do you have an account already? (yes/no)");
                string enter = Console.ReadLine().Trim().ToLower();

                if (enter == "yes")
                {
                    Class1login.Login();

                    while (Class1login.IsLoginSuccessful == false)        // until true it keeps on calling
                    {
                        Console.WriteLine("Invalid login, please try again.");
                        Class1login.Login();
                    }
                }
                else if (enter == "no")
                {
                    Console.WriteLine("You need to register.");
                    Class1register.Register();
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter 'yes' or 'no'.");
                }
        }
    }
}