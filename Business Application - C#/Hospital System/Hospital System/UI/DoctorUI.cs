using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital_System.BL;
using Hospital_System.DL;

namespace Hospital_System.UI
{
    class DoctorUI : UserUI
    {
        public static int PrintMenu()
        {
            string choice;
            bool isInputCorrect = false;
            while (isInputCorrect == false)
            {
                MiscUI.PrintNewScreen("Doctor Menu");
                Console.WriteLine("1.           View my own Record");
                Console.WriteLine("2.           Edit my Credentials");
                Console.WriteLine("3.           View patient's records");
                Console.WriteLine("4.           Diagnose patient");
                Console.WriteLine("5.           Prescribe medicine to patients");
                Console.WriteLine("6.           View schedule");
                Console.WriteLine("7.           Give review on hospital services");
                Console.WriteLine("8.           Order test for patient");
                Console.WriteLine("9.           View test result of patients");
                Console.WriteLine("10.          Add test result of patients");
                Console.WriteLine("11.          Schedule an appointment");
                Console.WriteLine("12.          Cancel an appointment");
                Console.WriteLine("13.          Change an appointment date");
                Console.WriteLine("14.          Logout\n");
                Console.Write("Enter your choice:   ");
                choice = Console.ReadLine();
                isInputCorrect = MiscLogic.ValidateMenuInput(choice, 1, 14);
                if (isInputCorrect == false)
                {
                    MiscUI.PrintInvalidInputScreen();
                }
                return int.Parse(choice);
            }
            return 0;
        }
        public static string GetDisease(List<Person> p, int idx)
        {
            Console.WriteLine("Enter the patient's disease:   ");
            string disease = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine(p[idx].GetName() + " successfully diagnosed with " + disease);
            Console.WriteLine();
            Console.WriteLine("Press any key to continue........");
            Console.ReadKey();
            return disease;
        }
    }
}
