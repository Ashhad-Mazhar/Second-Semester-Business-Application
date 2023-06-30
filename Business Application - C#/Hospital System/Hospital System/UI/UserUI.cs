using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital_System.BL;
using Hospital_System.DL;

namespace Hospital_System.UI
{
    class UserUI
    {
        public static string GetNewName()
        {
            // Used to edit the username of the logged in user.
            bool isInputCorrect = false;
            string Username = "Null";
            while (isInputCorrect == false)
            {
                MiscUI.PrintNewScreen("Edit Username");
                Console.WriteLine("Enter your new username: ");
                Username = Console.ReadLine();
                isInputCorrect = MiscLogic.ValidateTextInput(Username);
                if (isInputCorrect == false)
                {
                    MiscUI.PrintInvalidInputScreen();
                }
            }
            return Username;
        }
        public static string GetName()
        {
            bool isInputCorrect = false;
            string Username = "Null";
            while (isInputCorrect == false)
            {
                Console.WriteLine("Enter your new username: ");
                Username = Console.ReadLine();
                isInputCorrect = MiscLogic.ValidateTextInput(Username);
                if (isInputCorrect == false)
                {
                    MiscUI.PrintInvalidInputScreen();
                }
            }
            return Username;
        }
        public static string GetNewPassword()
        {
            string Password = "Null";
            MiscUI.PrintNewScreen("Edit Password");
            Password = GetPassword();
            return Password;
        }
        public static string GetPassword()
        {
            Console.WriteLine("Enter your new password: ");
            string Password = Console.ReadLine();
            return Password;
        }
        public static string GetOldPassword()
        {
            string Password;
            MiscUI.PrintNewScreen("Edit Password");
            Console.WriteLine("Enter your old password: ");
            Password = Console.ReadLine();
            return Password;
        }
        public static void ViewOwnRecord(Person p)
        {
            MiscUI.PrintNewScreen("View Own Record");
            ViewRecord(p);
        }
        public static void ViewRecord(Person p)
        {
            if (p.GetRole() == "Admin")
            {
                Console.WriteLine();
                Console.WriteLine("Username            :  " + p.GetName());
                Console.WriteLine("User Role           :  " + p.GetRole());
                Console.WriteLine("Registration Number :  " + p.GetRegistrationNumber());
                Console.WriteLine();
            }
            if (p.GetRole() == "Doctor")
            {
                Console.WriteLine();
                Console.WriteLine("Username            :  " + p.GetName());
                Console.WriteLine("User Role           :  " + p.GetRole());
                Console.WriteLine("Salary              :  " + p.GetSalary());
                Console.WriteLine("Registration Number :  " + p.GetRegistrationNumber());
                Console.WriteLine();
            }
            if (p.GetRole() == "Patient")
            {
                Console.WriteLine();
                Console.WriteLine("Username            :  " + p.GetName());
                Console.WriteLine("User Role           :  " + p.GetRole());
                Console.WriteLine("Total Bill          :  " + p.GetBill());
                Console.WriteLine("Registration Number :  " + p.GetRegistrationNumber());
                foreach(Test i in p.GetTests())
                {
                    Console.WriteLine("Test Ordered        :  " + i.GetName());
                    Console.WriteLine("Test Result         :  " + i.GetResult());
                }
                foreach(string i in p.GetDiseases())
                {
                    Console.WriteLine("Disease             :  " + i);
                }
                foreach(Medicine i in p.GetMedicines())
                {
                    Console.Write("Medicine Prescribed :  " + i.GetName()); ;
                    Console.WriteLine("    x" + i.GetAmount());
                }
                Console.WriteLine();
            }
        }
        public static int GetPersonalDetailsChoice()
        {
            bool isInputCorrect = true;
            while (isInputCorrect)
            {
                MiscUI.PrintNewScreen("Edit my Personal Details");
                Console.WriteLine("What would you like to edit?");
                Console.WriteLine();
                Console.WriteLine("1.           Username");
                Console.WriteLine("2.           Password");
                Console.WriteLine();
                Console.Write("Enter your choice:    ");
                string choice = Console.ReadLine();
                isInputCorrect = MiscLogic.ValidateMenuInput(choice, 1, 2);
                if (isInputCorrect == false)
                {
                    MiscUI.PrintInvalidInputScreen();
                }
                return int.Parse(choice);
            }
            return 0;
        }
        public static Patient GetNewPatientRecord()
        {
            MiscUI.PrintNewScreen("Add Patient's Record");
            string username = GetName();
            string password = GetPassword();
            string role = "Patient";
            int regNum = UsersCRUD.AssignRegistrationNumber();
            Patient p = new Patient(username, password, role, regNum);
            Console.WriteLine();
            Console.WriteLine("Patient's Record successfully added");
            Console.WriteLine();
            Console.WriteLine("Press any key to continue.....");
            Console.ReadKey();
            return p;
        }
        public static int GetRegistrationNumber()
        {
            bool isInputCorrect = false;
            string RegNum = "Null";
            while (isInputCorrect == false)
            {
                Console.WriteLine("Enter registration number: ");
                RegNum = Console.ReadLine();
                isInputCorrect = MiscLogic.ValidateNumericInput(RegNum);
                if (isInputCorrect == false)
                {
                    MiscUI.PrintInvalidInputScreen();
                }
            }
            return int.Parse(RegNum);
        }
        public static int InputLogoutChoice()
        {
            bool isInputCorrect = true;
            while (isInputCorrect)
            {
                MiscUI.PrintNewScreen("Logout");
                Console.WriteLine("Would you like to login again or terminate the application?");
                Console.WriteLine();
                Console.WriteLine("1.           Login again");
                Console.WriteLine("2.           Terminate the application");
                Console.WriteLine();
                Console.Write("Enter your choice:    ");
                string choice = Console.ReadLine();
                isInputCorrect = MiscLogic.ValidateMenuInput(choice, 1, 2);
                if (isInputCorrect == false)
                {
                    MiscUI.PrintInvalidInputScreen();
                }
                return int.Parse(choice);
            }
            return 0;
        }
        public static string PrintSessionEndScreen(int logoutChoice)
        {
            // Used to print goodbye screen at the end of a user's session.
            string nextStep = "loginScreen";
            Console.WriteLine("Thank you for using the application");
            Console.WriteLine();
            if (logoutChoice == 1)
            {
                Console.WriteLine("You have been successfully logged out");
                Console.WriteLine();
                Console.WriteLine("Press any key to continue.....");
                Console.ReadKey();
            }
            else if (logoutChoice == 2)
            {
                Console.WriteLine("The program has been terminated");
                Console.WriteLine();
                Console.WriteLine("Press any key to continue.....");
                nextStep = "endProgram";
                Console.ReadKey();
            }
            return nextStep;
        }
    }
}
