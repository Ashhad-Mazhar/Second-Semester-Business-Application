using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_System.BL
{
    class Medicine
    {
        private string name;
        private int amount;
        private float price;
        public Medicine(string name, int amount, float price)
        {
            this.name = name;
            this.amount = amount;
            this.price = price;
        }
        public string GetName()
        {
            return name;
        }
        public void SetName(string name)
        {
            this.name = name;
        }
        public int GetAmount()
        {
            return amount;
        }
        public bool SetAmount(int amount)
        {
            if (amount >= 0)
            {
                this.amount = amount;
                return true;
            }
            return false;
        }
        public float GetPrice()
        {
            return this.price;
        }
        public bool SetPrice(float price)
        {
            if (price >= 0)
            {
                this.price = price;
                return true;
            }
            return false;
        }
        public string toString()
        {
            return "Medicine[name=" + name + ",amount=" + amount + ",price=" + price + "]";
        }
    }
}
