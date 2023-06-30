using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital_System.BL;
using Hospital_System.DL;

namespace Hospital_System.UI
{
    class PatientUI : UserUI
    {
        public static int PrintMenu()
        {
            string choice;
            bool isInputCorrect = false;
            while (isInputCorrect == false)
            {
                MiscUI.PrintNewScreen("Patient Menu");
                Console.WriteLine("1.           View my record");
                Console.WriteLine("2.           Edit my personal details");
                Console.WriteLine("3.           View my diagnosis");
                Console.WriteLine("4.           View my prescriptions");
                Console.WriteLine("5.           View my recommended tests");
                Console.WriteLine("6.           View the details of my appointment");
                Console.WriteLine("7.           View my bill");
                Console.WriteLine("8.           Give a review on hospital services");
                Console.WriteLine("9.           View test result");
                Console.WriteLine("10.          Logout\n");
                Console.Write("Enter your choice:   ");
                choice = Console.ReadLine();
                isInputCorrect = MiscLogic.ValidateMenuInput(choice, 1, 10);
                if (isInputCorrect == false)
                {
                    MiscUI.PrintInvalidInputScreen();
                }
                return int.Parse(choice);
            }
            return 0;
        }
        public static void ViewDiseases(List<string> diseases)
        {
            foreach(string i in diseases)
            {
                Console.WriteLine("Disease :     " + i);
            }
            Console.ReadKey();
        }
        public static void ViewPrescriptions(List<Medicine> p)
        {
            foreach(Medicine i in p)
            {
                Console.WriteLine(i.GetName() + " :     x" + i.GetAmount());
                Console.WriteLine();
            }
            Console.ReadKey();
        }
        public static void ViewRecommendedTests(List<Test> t)
        {
            foreach (Test i in t)
            {
                Console.WriteLine(i.GetName());
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
