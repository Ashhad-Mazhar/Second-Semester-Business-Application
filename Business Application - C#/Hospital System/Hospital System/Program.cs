using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital_System.BL;
using Hospital_System.DL;
using Hospital_System.UI;

namespace Hospital_System
{
    class Program
    {
        static void Main(string[] args)
        {
            UsersCRUD UsersList = new UsersCRUD();
            MedicineCRUD DispensaryList = new MedicineCRUD();
            Person p;
            do
            {
                p = MiscUI.PrintLoginScreen();
                if (p.GetRole() == "Admin")
                {
                    string nextStep;
                    do
                    {
                        int menuChoice = PatientUI.PrintMenu();
                        nextStep = p.ExecuteFunction(menuChoice);
                    } while (nextStep == "menuScreen");
                }
                else if (p.GetRole() == "Doctor")
                {
                    string nextStep;
                    do
                    {
                        int menuChoice = PatientUI.PrintMenu();
                        nextStep = p.ExecuteFunction(menuChoice);
                    } while (nextStep == "menuScreen");
                }
                else if (p.GetRole() == "Patient")
                {
                    string nextStep;
                    do
                    {
                        int menuChoice = PatientUI.PrintMenu();
                        nextStep = p.ExecuteFunction(menuChoice);
                    } while (nextStep == "menuScreen");
                }
            } while (p == null);
        }
    }
}
