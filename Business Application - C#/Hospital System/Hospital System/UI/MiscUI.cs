using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital_System.BL;
using Hospital_System.DL;

namespace Hospital_System.UI
{
    class MiscUI
    {
        private static void PrintHeader()
        {
            // Used to print the header of the application.
            Console.Write("\n");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("************************************************************************************************************************");
            Console.Write("\n");
            Console.Write("********************************************** ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Hospital Management System ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("**********************************************");
            Console.Write("\n");
            Console.Write("************************************************************************************************************************");
            Console.Write("\n\n");
            Console.ForegroundColor = ConsoleColor.White;
        }
        private static void PrintSubHeader(string heading)
        {
            // Used to print the subheader of the application.
            Console.Write(heading);
            Console.Write("\n");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("------------------------------------------------------------------------------------------------------------------------");
            Console.Write("\n\n");
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void PrintNewScreen(string subHeader)
        {
            // Used to print the header and subheader of a new screen.
            Console.Clear();
            PrintHeader();
            PrintSubHeader(subHeader);
        }
        public static void PrintInvalidInputScreen()
        {
            // Used to show on the screen that the given input is invalid.
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("\nInvalid Input\n");
            Console.Write("Please try again.\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\nPress any key to continue");
            Console.ReadKey();
        }
        public static Person PrintLoginScreen()
        {
            // Used to print the login screen of the application.
            string Username, Password;
            Person p = new Person();
            while (p == null)
            {
                PrintNewScreen("Login Screen");
                Console.WriteLine("Test Account:");
                Console.WriteLine();
                Console.Write("Enter username: ");
                Username = Console.ReadLine(); ;
                Console.WriteLine("Enter password: ");
                Password = Console.ReadLine();
                p = UsersCRUD.ValidateLogin(Username, Password);
                if (p == null)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("\n");
                    Console.Write("Invalid Username or Password\n");
                    Console.Write("Please Try Again\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("\n");
                    Console.Write("Press any key to continue.....\n");
                    Console.ReadKey();
                }
            }
            return p;
        }
        public static void UpdateSuccessScreen()
        {
            Console.WriteLine();
            Console.WriteLine("Data Successfully Updated");
            Console.WriteLine();
            Console.WriteLine("Press any key to continue.....");
            Console.ReadKey();
        }
        public static void PrintNoRecordFound()
        {
            // Used to show on the screen that the given input is invalid.
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("\nNo Record Found\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\nPress any key to continue");
            Console.ReadKey();
        }
    }
}
