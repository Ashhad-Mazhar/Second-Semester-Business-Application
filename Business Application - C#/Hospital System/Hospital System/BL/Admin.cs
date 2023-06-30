using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital_System.DL;
using Hospital_System.UI;

namespace Hospital_System.BL
{
    class Admin : Person
    {
        public override string ExecuteFunction(int menuChoice) 
        {
            // Used to choose which admin function is to be executed.
            string nextStep = "menuScreen";
            int logoutChoice;
            if (menuChoice == 1)
            {
                PatientUI.ViewOwnRecord(this);
            }
            if (menuChoice == 2)
            {
                int choice = PatientUI.GetPersonalDetailsChoice();
                if (choice == 1)
                {
                    string name = PatientUI.GetNewName();
                    this.name = name;
                    MiscUI.UpdateSuccessScreen();
                }
                else if (choice == 2)
                {
                    string password;
                    bool isPasswordCorrect = false;
                    while (isPasswordCorrect == false)
                    {
                        password = PatientUI.GetOldPassword();
                        isPasswordCorrect = ValidatePassword(password);
                    }
                    password = PatientUI.GetNewPassword();
                    this.password = password;
                    MiscUI.UpdateSuccessScreen();
                }
            }
            if (menuChoice == 3)
            {
                int choice = PatientUI.GetAddRecordChoice();
                if (choice == 1)
                {
                    Person p = PatientUI.GetNewDoctorRecord();
                    UsersCRUD.AddUser(p);
                }
                else if (choice == 2)
                {
                    Person p = PatientUI.GetNewPatientRecord();
                    UsersCRUD.AddUser(p);
                }
            }
            else if (menuChoice == 4)
            {
                Person p = null;
                int regNum;
                while (p == null)
                {
                    MiscUI.PrintNewScreen("Remove Record");
                    regNum = PatientUI.GetRegistrationNumber();
                    p = UsersCRUD.SearchRecord(regNum);
                    if (p != null)
                    {
                        UsersCRUD.RemoveUser(regNum);
                    }
                }
            }
            else if (menuChoice == 5)
            {
                int choice = PatientUI.GetViewRecordChoice();
                if (choice == 1)
                {
                    MiscUI.PrintNewScreen("Show All Records");
                    List<Person> UserList = UsersCRUD.GetUsersList();
                    foreach (Person i in UserList)
                    {
                        UserUI.ViewRecord(i);
                    }
                }
                else if (choice == 2)
                {
                    Person p = null;
                    int regNum;
                    while (p == null)
                    {
                        MiscUI.PrintNewScreen("Search Record");
                        regNum = PatientUI.GetRegistrationNumber();
                        p = UsersCRUD.SearchRecord(regNum);
                    }
                }
            }
            else if (menuChoice == 6)
            {
                MiscUI.PrintNewScreen("View Dispensary Inventory");
                List<Medicine> medicines = MedicineCRUD.GetDispensaryList();
                PatientUI.ViewDispensaryInventory(medicines);
            }
            else if (menuChoice == 7)
            {
                int choice = PatientUI.GetUpdateDispensaryChoice();
                if (choice == 1)
                {
                    List<Medicine> m = MedicineCRUD.GetDispensaryList();
                    string index = PatientUI.GetMedicineToUpdate(m);
                    int amount = PatientUI.GetUpdatedMedicineAmount(index, m);
                    m[int.Parse(index)].SetAmount(amount);
                }
                else if (choice == 2)
                {
                    Medicine m = PatientUI.GetMedicine();
                    MedicineCRUD.AddMedicine(m);
                }
            }
            else if (menuChoice == 8)
            {
                List<Medicine> m = MedicineCRUD.GetDispensaryList();
                MiscUI.PrintNewScreen("View Medicine Prices");
                PatientUI.ViewMedicinePrices(m);
            }
            else if (menuChoice == 9)
            {
                List<Medicine> m = MedicineCRUD.GetDispensaryList();
                string index = PatientUI.GetMedicineToUpdate(m);
                float price = PatientUI.GetUpdatedMedicinePrice(index, m);
                m[int.Parse(index)].SetPrice(price);
            }
            else if (menuChoice == 10)
            {
                List<Person> p = UsersCRUD.GetUsersList();
                MiscUI.PrintNewScreen("View Doctors' Schedules");
                PatientUI.ViewDoctorSchedules(p);
            }
            else if (menuChoice == 11)
            {
                List<Person> p = UsersCRUD.GetUsersList();
                int regNum = PatientUI.GetUpdateBillRegNum();
                int idx = UsersCRUD.GetIndex(regNum);
                float bill = PatientUI.GetNewBill(p, idx);
                bool i = p[idx].SetBill(bill);
                UsersCRUD.SetUsersList(p);
            }
            else if (menuChoice == 12)
            {
                List<Person> p = UsersCRUD.GetUsersList();
                int regNum = PatientUI.GetUpdateSalaryRegNum();
                int idx = UsersCRUD.GetIndex(regNum);
                float salary = PatientUI.GetNewSalary(p, idx);
                bool i = p[idx].SetSalary(salary);
                UsersCRUD.SetUsersList(p);
            }
            else if (menuChoice == 13)
            {
                List<Person> p = UsersCRUD.GetUsersList();
                MiscUI.PrintNewScreen("View Hospital Service Reviews");
            }
            else if (menuChoice == 14)
            {
                logoutChoice = UserUI.InputLogoutChoice();
                MiscUI.PrintNewScreen("Logout");
                nextStep = PatientUI.PrintSessionEndScreen(logoutChoice);
            }
            return nextStep;
        }
    }
}
