using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital_System.DL;
using Hospital_System.UI;

namespace Hospital_System.BL
{
    class Doctor : Person
    {
        private float salary;
        private Review serviceReview;
        private List<Appointment> appointments;
        public Doctor(string name, string password, string role, int registrationNumber) : base(name, password, role, registrationNumber)
        {
            this.salary = 0;
            appointments = new List<Appointment>();
        }
        public Doctor(string name, string password, string role, int registrationNumber, float salary) : base(name, password, role, registrationNumber)
        {
            this.salary = salary;
            appointments = new List<Appointment>();
        }
        public override string ExecuteFunction(int menuChoice)
        {
            // Used to choose which admin function is to be executed.
            string nextStep = "menuScreen";
            int logoutChoice;
            if (menuChoice == 1)
            {
                DoctorUI.ViewOwnRecord(this);
            }
            if (menuChoice == 2)
            {
                int choice = DoctorUI.GetPersonalDetailsChoice();
                if (choice == 1)
                {
                    string name = DoctorUI.GetNewName();
                    this.name = name;
                    MiscUI.UpdateSuccessScreen();
                }
                else if (choice == 2)
                {
                    string password;
                    bool isPasswordCorrect = false;
                    while (isPasswordCorrect == false)
                    {
                        password = DoctorUI.GetOldPassword();
                        isPasswordCorrect = ValidatePassword(password);
                    }
                    password = DoctorUI.GetNewPassword();
                    this.password = password;
                    MiscUI.UpdateSuccessScreen();
                }
            }
            if (menuChoice == 3)
            {
                int choice = DoctorUI.GetViewRecordChoice();
                if (choice == 1)
                {
                    MiscUI.PrintNewScreen("Show Patient Records");
                    List<Person> UserList = UsersCRUD.GetUsersList();
                    foreach (Person i in UserList)
                    {
                        if (i.GetRole() == "Patient")
                        {
                            UserUI.ViewRecord(i);
                        }
                    }
                }
                else if (choice == 2)
                {
                    Person p = null;
                    int regNum;
                    while (p == null)
                    {
                        MiscUI.PrintNewScreen("Search Record");
                        regNum = DoctorUI.GetRegistrationNumber();
                        p = UsersCRUD.SearchRecord(regNum);
                    }
                }
            }
            else if (menuChoice == 4)
            {
                List<Person> p = UsersCRUD.GetUsersList();
                MiscUI.PrintNewScreen("Diagnose Patient");
                int regNum = DoctorUI.GetRegistrationNumber();
                int idx = UsersCRUD.GetIndex(regNum);
                p[idx].AddDisease(DoctorUI.GetDisease()); 
            }
            else if (menuChoice == 5)
            {
                int choice = DoctorUI.GetViewRecordChoice();
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
                        regNum = DoctorUI.GetRegistrationNumber();
                        p = UsersCRUD.SearchRecord(regNum);
                    }
                }
            }
            else if (menuChoice == 6)
            {
                MiscUI.PrintNewScreen("View Dispensary Inventory");
                List<Medicine> medicines = MedicineCRUD.GetDispensaryList();
                DoctorUI.ViewDispensaryInventory(medicines);
            }
            else if (menuChoice == 7)
            {
                int choice = DoctorUI.GetUpdateDispensaryChoice();
                if (choice == 1)
                {
                    List<Medicine> m = MedicineCRUD.GetDispensaryList();
                    string index = DoctorUI.GetMedicineToUpdate(m);
                    int amount = DoctorUI.GetUpdatedMedicineAmount(index, m);
                    m[int.Parse(index)].SetAmount(amount);
                }
                else if (choice == 2)
                {
                    Medicine m = DoctorUI.GetMedicine();
                    MedicineCRUD.AddMedicine(m);
                }
            }
            else if (menuChoice == 8)
            {
                List<Medicine> m = MedicineCRUD.GetDispensaryList();
                MiscUI.PrintNewScreen("View Medicine Prices");
                DoctorUI.ViewMedicinePrices(m);
            }
            else if (menuChoice == 9)
            {
                List<Medicine> m = MedicineCRUD.GetDispensaryList();
                string index = DoctorUI.GetMedicineToUpdate(m);
                float price = DoctorUI.GetUpdatedMedicinePrice(index, m);
                m[int.Parse(index)].SetPrice(price);
            }
            else if (menuChoice == 10)
            {
                List<Person> p = UsersCRUD.GetUsersList();
                MiscUI.PrintNewScreen("View Doctors' Schedules");
                DoctorUI.ViewDoctorSchedules(p);
            }
            else if (menuChoice == 11)
            {
                List<Person> p = UsersCRUD.GetUsersList();
                int regNum = DoctorUI.GetUpdateBillRegNum();
                int idx = UsersCRUD.GetIndex(regNum);
                float bill = DoctorUI.GetNewBill(p, idx);
                bool i = p[idx].SetBill(bill);
                UsersCRUD.SetUsersList(p);
            }
            else if (menuChoice == 12)
            {
                List<Person> p = UsersCRUD.GetUsersList();
                MiscUI.PrintNewScreen("View Hospital Service Reviews");
            }
            else if (menuChoice == 13)
            {
                logoutChoice = UserUI.InputLogoutChoice();
                MiscUI.PrintNewScreen("Logout");
                nextStep = DoctorUI.PrintSessionEndScreen(logoutChoice);
            }
            return nextStep;
        }
        public override float GetSalary()
        {
            return salary;
        }
        public override bool SetSalary (float salary)
        {
            if (salary >= 0)
            {
                this.salary = salary;
                return true;
            }
            return false;
        }
        public override Review GetReview()
        {
            return serviceReview;
        }
        public void SetReview(Review serviceReview)
        {
            this.serviceReview = serviceReview;
        }
        public override List<Appointment> GetAppointments()
        {
            return appointments;
        }
        public void SetAppointments(List<Appointment> a)
        {
            this.appointments = a;
        }
        public void AddAppointment(Appointment a)
        {
            appointments.Add(a);
        }
        public void RemoveAppointment(Appointment a)
        {
            appointments.Remove(a);
        }
        public override string toString()
        {
            string result = "Doctor[";
            result = "Person[name=" + name + ",password=" + password + ",role=" + role + ",RegNum=" + registrationNumber + ",Review=" + serviceReview + "]";
            result += ",salary=" + salary + "," + serviceReview.toString() + "]";
            return result;
        }
    }
}
