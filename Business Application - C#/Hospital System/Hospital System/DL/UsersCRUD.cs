using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital_System.BL;

namespace Hospital_System.DL
{
    class UsersCRUD
    {
        private static List<Person> UsersList;
        
        public UsersCRUD()
        {
            UsersList = new List<Person>();
        }
        public static void AddUser(Person p)
        {
            UsersList.Add(p);
        }
        public static void RemoveUser(int rn)
        {
            UsersList.Remove(SearchRecord(rn));
        }
        public static List<Person> GetUsersList()
        {
            return UsersList;
        }
        public static void SetUsersList(List<Person> p)
        {
            UsersList = p;
        }
        public static Person ValidateLogin(string n, string p)
        {
            foreach(Admin i in UsersList)
            {
                if(i.GetName() == n && i.GetPassword() == p)
                {
                    return i;
                }
            }
            return null;
        }
        public static int GetIndex(int rn)
        {
            for(int i = 0; i < UsersList.Count; i++)
            {
                if(rn == UsersList[i].GetRegistrationNumber())
                {
                    return i;
                }
            }
            return -1;
        }
        public static Person SearchRecord(int rn)
        {
            foreach (Person p in UsersList)
            {
                if(p.GetRegistrationNumber() == rn)
                {
                    return p;
                }
            }
            return null;
        }
        public static int AssignRegistrationNumber()
        {
            // Used to assign a registration number to a new user by clculating the greatest registration number already in use.
            int greatest = -1;
            foreach (Person i in UsersList)
            {
                if (i.GetRegistrationNumber() > greatest)
                {
                    greatest = i.GetRegistrationNumber();
                }
            }
            return greatest + 1;
        }
    }
}
