using Hospital_System.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_System.DL
{
    class MedicineCRUD
    {
        private static List<Medicine> DispensaryList;
        public MedicineCRUD()
        {
            DispensaryList = new List<Medicine>();
        }
        public static void AddMedicine(Medicine m)
        {
            DispensaryList.Add(m);
        }
        public static void RemoveMedicine(string n)
        {
            DispensaryList.Remove(SearchRecord(n));
        }
        public static Medicine SearchRecord(string n)
        {
            foreach (Medicine p in DispensaryList)
            {
                if (p.GetName() == n)
                {
                    return p;
                }
            }
            return null;
        }
        public static List<Medicine> GetDispensaryList()
        {
            return DispensaryList;
        }
    }
}
