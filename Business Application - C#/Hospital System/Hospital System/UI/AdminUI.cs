using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital_System.BL;
using Hospital_System.DL;

namespace Hospital_System.UI
{
    class AdminUI : UserUI
    {
        public static int PrintMenu()
        {
            string choice;
            bool isInputCorrect = false;
            while (isInputCorrect == false)
            {
                MiscUI.PrintNewScreen("Admin Menu");
                Console.WriteLine("1.           View my own Record");
                Console.WriteLine("2.           Edit my Credentials");
                Console.WriteLine("3.           Add a new record");
                Console.WriteLine("4.           Remove an old record");
                Console.WriteLine("5.           View records");
                Console.WriteLine("6.           View dispensary inventory");
                Console.WriteLine("7.           Update dispensary inventory");
                Console.WriteLine("8.           View prices of medicines");
                Console.WriteLine("9.           Update prices of medicines");
                Console.WriteLine("10.          View doctors' schedules");
                Console.WriteLine("11.          Update a patient's bill");
                Console.WriteLine("12.          Update a doctor's salary");
                Console.WriteLine("13.          View hospital service reviews");
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
        public static int GetAddRecordChoice()
        {
            string choice;
            bool isInputCorrect = false;
            while (isInputCorrect == false)
            {
                MiscUI.PrintNewScreen("Add a new Record");
                Console.WriteLine();
                Console.WriteLine("Whose record would you like to enter?");
                Console.WriteLine("1.      Doctor");
                Console.WriteLine("2.      Patient");
                Console.WriteLine();
                Console.WriteLine("Enter your choice:   ");
                choice = Console.ReadLine();
                isInputCorrect = MiscLogic.ValidateMenuInput(choice, 1, 2);
                if (isInputCorrect == false)
                {
                    MiscUI.PrintInvalidInputScreen();
                }
                return int.Parse(choice);
            }
            return 0;
        }
        public static Doctor GetNewDoctorRecord()
        {
            MiscUI.PrintNewScreen("Add Doctor's Record");
            string username = GetName();
            string password = GetPassword();
            string role = "Doctor";
            int regNum = UsersCRUD.AssignRegistrationNumber();
            Doctor d = new Doctor(username, password, role, regNum);
            Console.WriteLine();
            Console.WriteLine("Doctor's Record successfully added");
            Console.WriteLine();
            Console.WriteLine("Press any key to continue.....");
            Console.ReadKey();
            return d;
        }
        public static int GetViewRecordChoice()
        {
            string choice;
            bool isInputCorrect = false;
            while (isInputCorrect == false)
            {
                MiscUI.PrintNewScreen("View Record");
                Console.WriteLine();
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("1.      View All Records");
                Console.WriteLine("2.      Search a Particular Record");
                Console.WriteLine();
                Console.WriteLine("Enter your choice:   ");
                choice = Console.ReadLine();
                isInputCorrect = MiscLogic.ValidateMenuInput(choice, 1, 2);
                if (isInputCorrect == false)
                {
                    MiscUI.PrintInvalidInputScreen();
                }
                return int.Parse(choice);
            }
            return 0;
        }
        public static void ViewDispensaryInventory(List<Medicine> medicines)
        {
            if (medicines.Count < 1)
            {
                PrintNoRecordFound();
            }
            else
            {
                foreach (Medicine i in medicines)
                {
                    Console.WriteLine(i.GetName() + " : " + i.GetAmount());
                }
            }
            Console.WriteLine();
            Console.WriteLine("Press any key to continue........");
            Console.ReadKey();
        }
        public static void PrintNoRecordFound()
        {
            // Used to print on the screen that no matching record was found.
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine();
            Console.WriteLine("No Record Found");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static int GetUpdateDispensaryChoice()
        {
            string choice;
            bool isInputCorrect = false;
            while (isInputCorrect == false)
            {
                MiscUI.PrintNewScreen("Update Dispensary Inventory");
                Console.WriteLine();
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("1. Update the amount of a medicine");
                Console.WriteLine("2. Add a new medicine to the inventory");
                Console.WriteLine();
                Console.WriteLine("Enter your choice:   ");
                choice = Console.ReadLine();
                isInputCorrect = MiscLogic.ValidateMenuInput(choice, 1, 2);
                if (isInputCorrect == false)
                {
                    MiscUI.PrintInvalidInputScreen();
                }
                return int.Parse(choice);
            }
            return 0;
        }
        public static string GetMedicineToUpdate(List<Medicine> medicines)
        {
            bool isInputCorrect = false;
            string medicineToUpdate = "-1";
            while (isInputCorrect == false)
            {
                MiscUI.PrintNewScreen("Update Medicine Amount");
                for (int i = 0; i < medicines.Count; i++)
                {
                    Console.WriteLine(i + 1 + ".  " + medicines[i]);
                }
                Console.WriteLine();
                Console.WriteLine("Which medicine to update?     :        ");
                medicineToUpdate = Console.ReadLine();
                isInputCorrect = MiscLogic.ValidateNumericInput(medicineToUpdate);
                if (isInputCorrect == true)
                {
                    isInputCorrect = MiscLogic.ValidateMenuInput(medicineToUpdate, 1, medicines.Count);
                }
                else
                {
                    MiscUI.PrintInvalidInputScreen();
                }
                Console.WriteLine();
            }
            return medicineToUpdate;
        }
        public static int GetUpdatedMedicineAmount(string medicineToUpdate, List<Medicine> medicines)
        {
        // Used to update the amount of a particular medicine in the inventory.
        updateMedicine:
            string UpdatedAmount;
            bool isInputCorrect = true;
            if (medicines.Count >= 1)
            {
                if (isInputCorrect == true)
                {
                    Console.WriteLine("Current number of " + medicines[int.Parse(medicineToUpdate) - 1].GetName() + ":         " + medicines[int.Parse(medicineToUpdate) - 1].GetAmount());
                    Console.WriteLine();
                EnterUpdatedAmount:
                    Console.WriteLine("What is the updated amount of " + medicines[int.Parse(medicineToUpdate) - 1] + "?");
                    UpdatedAmount = Console.ReadLine();
                    isInputCorrect = MiscLogic.ValidateNumericInput(UpdatedAmount);
                    if (isInputCorrect == false)
                    {
                        MiscUI.PrintInvalidInputScreen();
                        Console.WriteLine();
                        Console.WriteLine();
                        goto EnterUpdatedAmount;
                    }
                    Console.WriteLine();
                    return int.Parse(UpdatedAmount);
                }
                else
                {
                    MiscUI.PrintInvalidInputScreen();
                    goto updateMedicine;
                }
            }
            else
            {
                MiscUI.PrintNoRecordFound();
                return -1;
            }
        }

        public static Medicine GetMedicine()
        {
            // Used to add a new medicine to the inventory.
            bool isInputCorrect;
            MiscUI.PrintNewScreen("Add new Medicine");
            Console.WriteLine("Enter the name of the medicine you would like to add:  ");
            string name = Console.ReadLine();
        EnterMedicineAmount:
            Console.WriteLine("Enter the amount of medicine:  ");
            string amount = Console.ReadLine();
            isInputCorrect = MiscLogic.ValidateNumericInput(amount);
            if (isInputCorrect == false)
            {
                MiscUI.PrintInvalidInputScreen();
                Console.WriteLine("\n");
                goto EnterMedicineAmount;
            }
        EnterMedicinePrice:
            Console.WriteLine("Enter the price of the medicine:   ");
            string price = Console.ReadLine();
            isInputCorrect = MiscLogic.ValidateNumericInput(price);
            if (isInputCorrect == false)
            {
                MiscUI.PrintInvalidInputScreen();
                Console.WriteLine("\n");
                goto EnterMedicinePrice;
            }
            Medicine medicine = new Medicine(name, int.Parse(amount), float.Parse(price));
            Console.WriteLine();
            MiscUI.UpdateSuccessScreen();
            Console.WriteLine();
            return medicine;
        }
        public static void ViewMedicinePrices(List<Medicine> medicines)
        {
            // Used to view the prices of all medicines in the inventory.
            foreach (Medicine i in medicines)
            {
                Console.WriteLine(i.GetName() + "   :   Rs. " + i.GetPrice());
            }
            if (medicines.Count <= 0)
            {
                MiscUI.PrintNoRecordFound();
            }
        }
        public static float GetUpdatedMedicinePrice(string medicineToUpdate, List<Medicine> medicines)
        {
        // Used to update the amount of a particular medicine in the inventory.
        updateMedicine:
            string UpdatedPrice;
            bool isInputCorrect = true;
            if (medicines.Count >= 1)
            {
                if (isInputCorrect == true)
                {
                    Console.WriteLine("Current price of " + medicines[int.Parse(medicineToUpdate) - 1].GetName() + ":         " + medicines[int.Parse(medicineToUpdate) - 1].GetPrice());
                    Console.WriteLine();
                EnterUpdatedAmount:
                    Console.WriteLine("What is the updated price of " + medicines[int.Parse(medicineToUpdate) - 1] + "?");
                    UpdatedPrice = Console.ReadLine();
                    isInputCorrect = MiscLogic.ValidateNumericInput(UpdatedPrice);
                    if (isInputCorrect == false)
                    {
                        MiscUI.PrintInvalidInputScreen();
                        Console.WriteLine();
                        Console.WriteLine();
                        goto EnterUpdatedAmount;
                    }
                    Console.WriteLine();
                    return float.Parse(UpdatedPrice);
                }
                else
                {
                    MiscUI.PrintInvalidInputScreen();
                    goto updateMedicine;
                }
            }
            else
            {
                MiscUI.PrintNoRecordFound();
                return -1;
            }
        }
        public static void ViewDoctorSchedules(List<Person> p)
        {
            // Used by admins to view doctors' schedules by an admin.
            foreach (Person i in p)
            {
                if (i.GetRole() == "Doctor")
                {
                    Console.WriteLine();
                    Console.WriteLine("Dr. " + i.GetName() + ":");
                    if (i.GetAppointments() != null)
                    {
                        foreach (Appointment j in i.GetAppointments())
                        {
                            Console.WriteLine();
                            Console.WriteLine("Appointment Date: " + j.toString());
                            Console.WriteLine();
                        }
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("No Appointment Scheduled");
                        Console.WriteLine();
                    }
                }
            }
            Console.WriteLine("Press any key to continue.....");
            Console.ReadKey();
        }
        public static int GetUpdateBillRegNum()
        {
        // Used to update a patient's bill in the database.
        UpdatePatientBill:
            MiscUI.PrintNewScreen("Update Patient's Bill");
            string RegistrationNumber;
            bool isInputCorrect;
            Console.WriteLine("Enter the registration number of the patient: ");
            Console.WriteLine();
            Console.WriteLine("Registration Number:       ");
            RegistrationNumber = Console.ReadLine();
            isInputCorrect = MiscLogic.ValidateNumericInput(RegistrationNumber);
            if (isInputCorrect == false)
            {
                MiscUI.PrintInvalidInputScreen();
                goto UpdatePatientBill;
            }
            Console.WriteLine();
            return int.Parse(RegistrationNumber);
        }
        public static float GetNewBill(List<Person> p, int idx)
        {
            bool isInputCorrect;
            string newBill;
            Console.WriteLine(p[idx].GetName() + "'s Current Bill :   Rs. " + p[idx].GetBill());
            Console.WriteLine();
        EnterNewBill:
            Console.WriteLine("Enter new bill:");
            newBill = Console.ReadLine();
            isInputCorrect = MiscLogic.ValidateNumericInput(newBill);
            if (isInputCorrect == false)
            {
                MiscUI.PrintInvalidInputScreen();
                Console.WriteLine("\n");
                goto EnterNewBill;
            }
            Console.WriteLine();
            Console.WriteLine(p[idx].GetName() + "'s bill has been successfully updated");
            Console.WriteLine();
            Console.WriteLine(p[idx].GetName() + "'s Updated Bill :   Rs. " + newBill);
            Console.WriteLine();
            Console.WriteLine("Press any key to continue........");
            Console.ReadKey();
            return float.Parse(newBill);
        }
        public static int GetUpdateSalaryRegNum()
        {
        // Used to update a patient's bill in the database.
        UpdatePatientBill:
            MiscUI.PrintNewScreen("Update Doctor's Salary");
            string RegistrationNumber;
            bool isInputCorrect;
            Console.WriteLine("Enter the registration number of the doctor: ");
            Console.WriteLine();
            Console.WriteLine("Registration Number:       ");
            RegistrationNumber = Console.ReadLine();
            isInputCorrect = MiscLogic.ValidateNumericInput(RegistrationNumber);
            if (isInputCorrect == false)
            {
                MiscUI.PrintInvalidInputScreen();
                goto UpdatePatientBill;
            }
            Console.WriteLine();
            return int.Parse(RegistrationNumber);
        }
        public static float GetNewSalary(List<Person> p, int idx)
        {
            bool isInputCorrect;
            string newSalary;
            Console.WriteLine(p[idx].GetName() + "'s Current Salary :   Rs. " + p[idx].GetSalary());
            Console.WriteLine();
        EnterNewBill:
            Console.WriteLine("Enter new salary:");
            newSalary = Console.ReadLine();
            isInputCorrect = MiscLogic.ValidateNumericInput(newSalary);
            if (isInputCorrect == false)
            {
                MiscUI.PrintInvalidInputScreen();
                Console.WriteLine("\n");
                goto EnterNewBill;
            }
            Console.WriteLine();
            Console.WriteLine(p[idx].GetName() + "'s salary has been successfully updated");
            Console.WriteLine();
            Console.WriteLine(p[idx].GetName() + "'s Updated Salary :   Rs. " + newSalary);
            Console.WriteLine();
            Console.WriteLine("Press any key to continue........");
            Console.ReadKey();
            return float.Parse(newSalary);
        }
        public static void ViewHospitalServiceReviews(List<Person> p)
        {
            // Used by the admin to view the reviews on hospital services given by doctors and patients.
            bool reviewFound = false;
            foreach (Person i in p)
            {
                if (i.GetRole() == "Doctor" || i.GetRole() == "Patient")
                {
                    reviewFound = true;
                    Console.WriteLine(i.GetName() + "(" + i.GetRole() + "):");
                    Review r = i.GetReview();
                    if (r.GetStars() >= 1)
                    {
                        Console.WriteLine(r.GetStars() + " Stars");
                        Console.WriteLine("\"" + r.GetRemarks() + "\"");
                    }
                    else
                    {
                        Console.WriteLine("No Review Added Yet");
                    }
                    Console.WriteLine();
                }
            }
            if (reviewFound == false)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine();
                Console.WriteLine("No Review Found");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.WriteLine("Press any key to continue.....");
            Console.ReadKey();
        }
    }
}
