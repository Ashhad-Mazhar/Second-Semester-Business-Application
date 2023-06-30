using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital_System.DL;
using Hospital_System.UI;

namespace Hospital_System.BL
{
    class Patient : Person
    {
        private float bill;
        private List<string> diseases;
        private Review serviceReview;
        private List<Medicine> medicines;
        private List<Test> tests;
        private List<Appointment> appointments;
        public Patient (string name, string password, string role, int registrationNumber) : base (name, password, role, registrationNumber)
        {
            medicines = new List<Medicine>();
            diseases = new List<string>();
            appointments = new List<Appointment>();
            bill = 0;
        }
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
                MiscUI.PrintNewScreen("View Diagnosis");
                PatientUI.ViewDiseases(diseases);
            }
            else if (menuChoice == 4)
            {
                MiscUI.PrintNewScreen("View my Prescriptions");
                PatientUI.ViewPrescriptions(medicines);
            }
            else if (menuChoice == 5)
            {
                MiscUI.PrintNewScreen("View my Recommended Tests");
                PatientUI.ViewRecommendedTests(tests);
            }
            else if (menuChoice == 6)
            {
                logoutChoice = UserUI.InputLogoutChoice();
                MiscUI.PrintNewScreen("Logout");
                nextStep = PatientUI.PrintSessionEndScreen(logoutChoice);
            }
            return nextStep;
        }
        public override float GetBill()
        {
            return bill;
        }
        public override bool SetBill(float bill)
        {
            if (bill >= 0)
            {
                this.bill = bill;
                return true;
            }
            return false;
        }
        public override List<string> GetDiseases()
        {
            return diseases;
        }
        public void SetDiseases(List<string> diseases)
        {
            this.diseases = diseases;
        }
        public override Review GetReview()
        {
            return serviceReview;
        }
        public void SetReview(Review serviceReview)
        {
            this.serviceReview = serviceReview;
        }
        public override List<Medicine> GetMedicines()
        {
            return medicines;
        }
        public void SetMedicines(List<Medicine> medicines)
        {
            this.medicines = medicines;
        }
        public void AddMedicine(Medicine m)
        {
            medicines.Add(m);
        }
        public void RemoveTest(Medicine m)
        {
            medicines.Remove(m);
        }
        public override List<Test> GetTests()
        {
            return tests;
        }
        public void SetTests(List<Test> tests)
        {
            this.tests = tests;
        }
        public void AddTest(Test t)
        {
            tests.Add(t);
        }
        public void RemoveTest(Test t)
        {
            tests.Remove(t);
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
            result += ",bill=" + bill + ",disease=" + disease + "," + serviceReview.toString() + "]";
            return result;
        }
    }
}
