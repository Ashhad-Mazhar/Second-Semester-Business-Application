using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_System.BL
{
    class Appointment
    {
        private int date;
        private int month;
        private int year;
        public Appointment(int date, int month, int year)
        {
            this.date = date;
            this.month = month;
            this.year = year;
        }
        public int GetDate()
        {
            return date;
        }
        public bool SetDate(int date)
        {
            if (date >= 1 && date <= 31)
            {
                this.date = date;
                return true;
            }
            return false;
        }
        public int GetMonth()
        {
            return month;
        }
        public bool SetMonth(int month)
        {
            if (month >= 1 && month <= 12)
            {
                this.month = month;
                return true;
            }
            return false;
        }
        public int GetYear()
        {
            return year;
        }
        public bool SetYear(int year)
        {
            if (year >= 23 && year <= 99)
            {
                this.year = year;
                return true;
            }
            return false;
        }
        public string toString()
        {
            return date + "/" + month + "/" + year;
        }
    }
}
