using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_System.BL
{
    class Person
    {
        protected string name;
        protected string password;
        protected string role;
        protected int registrationNumber;
        public Person ()
        {

        }
        public Person (string name, string password, string role, int registrationNumber)
        {
            this.name = name;
            this.password = password;
            this.role = role;
            this.registrationNumber = registrationNumber;
        }
        public bool ValidateLogin(string n, string p)
        {
            bool result = false;
            if (this.name == n && this.password == p)
            {
                result = true;
            }
            return result;
        }
        public bool ValidatePassword(string p)
        {
            bool result = false;
            if (this.password == p)
            {
                result = true;
            }
            return result;
        }
        public string GetName()
        {
            return name;
        }
        public bool SetName(string n)
        {
            bool condition = true;
            for(int i = 0; i < n.Length; i++)
            {
                if(!((int)n[i] >= 65 && (int)n[i] <= 90) || ((int)n[i] >= 97 && (int)n[i] <= 122))
                {
                    condition = false;
                }
            }
            if (condition)
            {
                this.name = n;
            }
            return condition;
        }
        public string GetPassword()
        {
            return password;
        }
        public bool SetPassword(string p)
        {
            if (p.Length >= 8 && p.Length >= 16)
            {
                this.password = p;
                return true;
            }
            return false;
        }
        public string GetRole()
        {
            return role;
        }
        public bool SetRole(string r)
        {
            if (r.ToLower() == "admin" || r.ToLower() == "doctor" || r.ToLower() == "patient")
            {
                this.role = r;
                return true;
            }
            return false;
        }
        public int GetRegistrationNumber()
        {
            return registrationNumber;
        }
        public bool SetRegistrationNumber(int r)
        {
            if (r >= 1)
            {
                this.registrationNumber = r;
                return true;
            }
            return false;
        }
        public virtual string toString()
        {
            string result = "Person[name=" + name + ",password=" + password + ",role=" + role + ",RegNum=" + registrationNumber + "]";
            return result;
        }
        public virtual string ExecuteFunction(int choice)
        {
            return null;
        }
        public virtual float GetSalary()
        {
            return 0;
        }
        public virtual float GetBill()
        {
            return 0;
        }
        public virtual List<Test> GetTests()
        {
            return null;
        }
        public virtual List<string> GetDiseases()
        {
            return null;
        }
        public virtual List<Medicine> GetMedicines()
        {
            return null;
        }
        public virtual List<Appointment> GetAppointments()
        {
            return null;
        }
        public virtual bool SetBill(float bill)
        {
            return false;
        }
        public virtual bool SetSalary(float salary)
        {
            return false;
        }
        public virtual Review GetReview()
        {
            return null;
        }
    }
}
